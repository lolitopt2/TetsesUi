using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetsesUi.ViewModels.Admin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

       
        private bool ValidateLogin(string email, string password)
        {


            string query = "SELECT * FROM medicos WHERE CCnum = @CCnum AND Password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CCnum", email);
                        command.Parameters.AddWithValue("@Password", password);

                    
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                ProClass.MedicoID = Convert.ToInt32(reader["MedicoID"]);  // ID do médico
                                ProClass.Email = reader["Nome"].ToString();  // O nome do médico
                                ProClass.Password = reader["Email"].ToString();  // O email do médico
                                ProClass.CCnum = Convert.ToInt32(reader["CCnum"]); // CCnum do médico

                                return true;  // Login válido
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false; // Login inválido
        }
        private void txtCCnum_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
 
            string vale = ProNum.Text.Trim();

           
            if (!IsCCnumlValid(vale))
            {
          
                MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Cancel = true;
            }
        }

        // Método para verificar se o e-mail é válido
        private bool IsCCnumlValid(string vale)
        {
            // Expressão regular para validar e-mails
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(vale, emailRegex);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Opening mainForm = new Opening();
            mainForm.Show();
            this.Hide();
        }

        private void LogUten_Click(object sender, EventArgs e)
        {
            string cc = ProNum.Text;
            string password = PassTxt.Text;

            bool isLoggedIn = ValidateLogin(cc, password); // Método para validar o login

            if (isLoggedIn)
            {
                
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                AdmView mainForm = new AdmView();
                mainForm.Show();
                this.Hide();  
            }
            else
            {
                MessageBox.Show("Número de CC ou senha inválidos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



