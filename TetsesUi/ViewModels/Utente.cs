using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TetsesUi.ViewModels
{
    public partial class Utente : Form
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public Utente()
        {
            InitializeComponent();
        }

        private void UtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

      

        private bool VerifyLogin(string ccNum, string password)
        {
            try
            {
              
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); 

                  
                    string query = "SELECT UtenteID,Nome,Morada,Telefone,Email FROM utentes WHERE ccNum = @ccNum AND Password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ccNum", ccNum);
                        cmd.Parameters.AddWithValue("@Password", password); 

                        using (MySqlDataReader reader = cmd.ExecuteReader()) 
                        {
                            if (reader.Read()) 
                            {
                               
                                LoggedUser.UtenteId = Convert.ToInt32(reader["UtenteID"]);
                                LoggedUser.UtenteName = reader["Nome"].ToString();
                                LoggedUser.UtenteMorada = reader["Morada"].ToString();
                                LoggedUser.UtenteTele = reader["Telefone"].ToString();
                                LoggedUser.UtenteEmail = reader["Email"].ToString();


                                return true; 
                            }
                            else
                            {
                                return false; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void LogUten_Click(object sender, EventArgs e)
        {
            string username = UtNum.Text.Trim(); 
            string password = PassTxt.Text.Trim(); 

        
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerifyLogin(username, password))
            {
              
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

         
                UtenteView form = new UtenteView();

            
                form.Show();

                
                this.Hide();

            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Opening open = new Opening();


            open.Show();


            this.Hide();
        }
    }
}


