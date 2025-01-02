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

        private void button1_Click(object sender, EventArgs e)
        {
            string email = ProNum.Text;
            string password = PassTxt.Text;

            bool isLoggedIn = ValidateLogin(email, password); // Método para validar o login

            if (isLoggedIn)
            {
                // Caso o login seja válido, redireciona para a tela principal
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirecionar para o formulário principal
                AdmView mainForm = new AdmView();
                mainForm.Show();
                this.Hide();  // Esconde o formulário de login
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que valida o login e armazena os dados do usuário logado na classe SistemaU
        private bool ValidateLogin(string email, string password)
        {


            string query = "SELECT * FROM medicos WHERE Nome = @Email AND Password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", email);
                        command.Parameters.AddWithValue("@Password", password);

                        // Executa a consulta e verifica se retornou algum registro
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Armazena os dados do usuário logado na classe SistemaU (propriedades estáticas)
                                SistemaU.SystemID = reader.GetInt32("SystemID");
                                SistemaU.Nome = reader.GetString("Nome");

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
        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Obtem o texto inserido na TextBox
            string vale = ProNum.Text.Trim();

            // Chama o método para verificar se o e-mail é válido
            if (!IsEmailValid(vale))
            {
                // Exibe uma mensagem de erro caso não seja um e-mail válido
                MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Cancela o evento para manter o foco na TextBox
                e.Cancel = true;
            }
        }

        // Método para verificar se o e-mail é válido
        private bool IsEmailValid(string vale)
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
    }
}


