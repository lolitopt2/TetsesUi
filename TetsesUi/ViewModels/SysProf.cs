using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetsesUi.ViewModels
{
    public partial class SysProf : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public SysProf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEspe.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTele.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
              
                string query = @"INSERT INTO medicos (Nome, Especialidade, Email, Telefone, Password) 
                                 VALUES (@Nome, @Especialidade, @Email, @Telefone, @Password)";


                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                  
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                     
                        command.Parameters.AddWithValue("@Nome", txtNome.Text);
                        command.Parameters.AddWithValue("@Especialidade", txtEspe.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Telefone", txtTele.Text);
                        command.Parameters.AddWithValue("@Password", txtPass.Text);

                  
                        int rowsAffected = command.ExecuteNonQuery();

                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Utilizador registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao registar o utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtEspe.Clear();
            txtEmail.Clear();
            txtTele.Clear();
            txtPass.Clear();
        }
        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
            string email = txtEmail.Text.Trim();

           
            if (!IsEmailValid(email))
            {
             
                MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
                e.Cancel = true;
            }
        }

     
        private bool IsEmailValid(string email)
        {
           
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }
    }
}

