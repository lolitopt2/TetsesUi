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
                e.Handled = true; // Reject the input
            }
        }

        private void UtNum_Enter(object sender, EventArgs e)
        {

        }

        private void UtNum_Leave(object sender, EventArgs e)
        {

        }
        private bool VerifyLogin(string username, string password)
        {
            try
            {
                // Conectar ao banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // Abre a conexão

                    // Consultar se o nome de usuário e a senha correspondem
                    string query = "SELECT COUNT(*) FROM utentes WHERE ccNum = @ccNum AND Password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ccNum", username);
                        cmd.Parameters.AddWithValue("@Password", password); // A senha aqui está em texto simples (não recomendado para produção)

                        int count = Convert.ToInt32(cmd.ExecuteScalar()); // Executa a consulta e obtém o número de registros

                        return count > 0; // Se count for maior que 0, as credenciais são válidas
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
            string utNum = UtNum.Text.Trim(); // Pega o nome de usuário
            string password = PassTxt.Text.Trim(); // Pega a senha

            // Verifica se os campos não estão vazios
            if (string.IsNullOrWhiteSpace(utNum) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica o login
            if (VerifyLogin(utNum, password))
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
    }
}
