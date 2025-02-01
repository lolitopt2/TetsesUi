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

namespace TetsesUi.ViewModels
{
    public partial class Sys : Form
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        

        public Sys()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textNome.Text;
            string password = textPass.Text;

            bool isLoggedIn = ValidateLogin(nome, password);

            if (isLoggedIn)
            {
           
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
                SysView mainForm = new SysView();
                mainForm.Show();
                this.Hide();  
            }
            else
            {
                MessageBox.Show("Nome ou senha inválidos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private bool ValidateLogin(string nome, string password)
        {
            

            string query = "SELECT * FROM system WHERE Nome = @Nome AND Password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Password", password);

                  
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                              
                                SistemaU.SystemID = reader.GetInt32("SystemID");
                                SistemaU.Nome = reader.GetString("Nome");

                                return true;  
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false; 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Opening mainForm = new Opening();
            mainForm.Show();
            this.Hide();
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
