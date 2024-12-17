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
    public partial class DadosEdit : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        public DadosEdit()
        {
            InitializeComponent();
          

        }
       
        private void AtualizarDadosUtente()
        {
            string novoEmail = txtEmail.Text.Trim();
            string novaMorada = txtMorada.Text.Trim();
            string novoTelefone = txtTele.Text.Trim();

            // Verificar se pelo menos um campo foi preenchido
            if (string.IsNullOrEmpty(novoEmail) && string.IsNullOrEmpty(novaMorada) && string.IsNullOrEmpty(novoTelefone))
            {
                MessageBox.Show("Por favor, preencha pelo menos um campo para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Conexão com o banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Construir a query dinamicamente
                    List<string> camposParaAtualizar = new List<string>();
                    if (!string.IsNullOrEmpty(novoEmail)) camposParaAtualizar.Add("Email = @Email");
                    if (!string.IsNullOrEmpty(novaMorada)) camposParaAtualizar.Add("Morada = @Morada");
                    if (!string.IsNullOrEmpty(novoTelefone)) camposParaAtualizar.Add("Telefone = @Telefone");

                    // Montar a query final
                    string query = $"UPDATE utentes SET {string.Join(", ", camposParaAtualizar)} WHERE UtenteID = @UtenteID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Adicionar parâmetros apenas para os campos preenchidos
                        if (!string.IsNullOrEmpty(novoEmail)) cmd.Parameters.AddWithValue("@Email", novoEmail);
                        if (!string.IsNullOrEmpty(novaMorada)) cmd.Parameters.AddWithValue("@Morada", novaMorada);
                        if (!string.IsNullOrEmpty(novoTelefone)) cmd.Parameters.AddWithValue("@Telefone", novoTelefone);

                        cmd.Parameters.AddWithValue("@UtenteID", LoggedUser.UtenteId); // ID do usuário logado

                        // Executar o comando SQL
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado foi atualizado. Verifique os valores.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Control && e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // Bloqueia a ação sem exibir a mensagem
            }
        }
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Rejeita a entrada
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarDadosUtente();
        }
    }
}
