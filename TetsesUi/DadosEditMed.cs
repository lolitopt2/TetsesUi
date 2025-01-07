using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TetsesUi
{
    public partial class DadosEditMed : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        // Evento para notificar sobre atualizações
        public event Action DadosAtualizados;

        public DadosEditMed()
        {
            InitializeComponent();
            LimparCampos(); // Inicializar com campos vazios
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            txtEmail.Clear();
            txtEspecialidade.Clear();
            txtTelefone.Clear();
        }

        // Método para carregar os dados do médico
        public void CarregarDadosMedico()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Email, Especialidade, Telefone FROM Medicos WHERE MedicoID = @MedicoID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicoID", ProClass.MedicoID); // ID do médico logado

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmail.Text = reader["Email"].ToString();
                                txtEspecialidade.Text = reader["Especialidade"].ToString();
                                txtTelefone.Text = reader["Telefone"].ToString();
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

        // Método para atualizar os dados do médico
        private void AtualizarDadosMedico()
        {
            string novoEmail = txtEmail.Text.Trim();
            string novaEspecialidade = txtEspecialidade.Text.Trim();
            string novoTelefone = txtTelefone.Text.Trim();

            if (string.IsNullOrEmpty(novoEmail) && string.IsNullOrEmpty(novaEspecialidade) && string.IsNullOrEmpty(novoTelefone))
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
                    if (!string.IsNullOrEmpty(novaEspecialidade)) camposParaAtualizar.Add("Especialidade = @Especialidade");
                    if (!string.IsNullOrEmpty(novoTelefone)) camposParaAtualizar.Add("Telefone = @Telefone");

                    string query = $"UPDATE Medicos SET {string.Join(", ", camposParaAtualizar)} WHERE MedicoID = @MedicoID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(novoEmail)) cmd.Parameters.AddWithValue("@Email", novoEmail);
                        if (!string.IsNullOrEmpty(novaEspecialidade)) cmd.Parameters.AddWithValue("@Especialidade", novaEspecialidade);
                        if (!string.IsNullOrEmpty(novoTelefone)) cmd.Parameters.AddWithValue("@Telefone", novoTelefone);

                        cmd.Parameters.AddWithValue("@MedicoID", ProClass.MedicoID);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DadosAtualizados?.Invoke(); // Disparar evento para notificar atualização
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

        // Evento do botão para salvar
        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarDadosMedico();
            txtEspecialidade.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
        }
    }
}
