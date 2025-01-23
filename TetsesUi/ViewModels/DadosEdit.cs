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

        // Evento para notificar sobre atualizações
        public event Action DadosAtualizados;
        public DadosEdit()
        {
            InitializeComponent();
            CarregarDadosUtente();
            LimparCampos();
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            txtEmail.Clear();
            txtMorada.Clear();
            txtTele.Clear();
        }

        // Método para carregar os dados do utente
        public void CarregarDadosUtente()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Nome, Email, Telefone, Morada FROM UTENTES WHERE UtenteId = @UtenteID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UtenteID", LoggedUser.UtenteId); // ID do utente logado

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmail.Text = reader["Email"].ToString();
                                txtMorada.Text = reader["Morada"].ToString();
                                txtTele.Text = reader["Telefone"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDadosUtente()
        {
            string novoEmail = txtEmail.Text.Trim();
            string novaMorada = txtMorada.Text.Trim();
            string novoTelefone = txtTele.Text.Trim();

            if (string.IsNullOrEmpty(novoEmail) && string.IsNullOrEmpty(novaMorada) && string.IsNullOrEmpty(novoTelefone))
            {
                MessageBox.Show("Por favor, preencha pelo menos um campo para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    List<string> camposParaAtualizar = new List<string>();
                    if (!string.IsNullOrEmpty(novoEmail)) camposParaAtualizar.Add("Email = @Email");
                    if (!string.IsNullOrEmpty(novaMorada)) camposParaAtualizar.Add("Morada = @Morada");
                    if (!string.IsNullOrEmpty(novoTelefone)) camposParaAtualizar.Add("Telefone = @Telefone");

                    string query = $"UPDATE utentes SET {string.Join(", ", camposParaAtualizar)} WHERE UtenteId = @UtenteID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(novoEmail)) cmd.Parameters.AddWithValue("@Email", novoEmail);
                        if (!string.IsNullOrEmpty(novaMorada)) cmd.Parameters.AddWithValue("@Morada", novaMorada);
                        if (!string.IsNullOrEmpty(novoTelefone)) cmd.Parameters.AddWithValue("@Telefone", novoTelefone);

                        cmd.Parameters.AddWithValue("@UtenteID", LoggedUser.UtenteId);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Dispara o evento de atualização
                            DadosAtualizados?.Invoke();
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
        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarDadosUtente();
            txtEmail.Clear();
            txtTele.Clear();
            txtMorada.Clear();
        }
    }
}
