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

namespace TetsesUi
{
    public partial class DadosEditMed : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public DadosEditMed()
        {
            InitializeComponent();
        }

        // Método para atualizar os dados do médico
        private void AtualizarDadosMedico()
        {
            string novoEmail = txtEspecialidade.Text.Trim();
            string novaEspecialidade = txtEspecialidade.Text.Trim();
            string novoTelefone = txtTelefone.Text.Trim();

            // Verificar se pelo menos um campo foi preenchido
            if (string.IsNullOrEmpty(novoEmail) && string.IsNullOrEmpty(novaEspecialidade) && string.IsNullOrEmpty(novoTelefone))
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
                    if (!string.IsNullOrEmpty(novaEspecialidade)) camposParaAtualizar.Add("Especialidade = @Especialidade");
                    if (!string.IsNullOrEmpty(novoTelefone)) camposParaAtualizar.Add("Telefone = @Telefone");

                    // Montar a query final
                    string query = $"UPDATE Medicos SET {string.Join(", ", camposParaAtualizar)} WHERE MedicoID = @MedicoID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Adicionar parâmetros apenas para os campos preenchidos
                        if (!string.IsNullOrEmpty(novoEmail)) cmd.Parameters.AddWithValue("@Email", novoEmail);
                        if (!string.IsNullOrEmpty(novaEspecialidade)) cmd.Parameters.AddWithValue("@Especialidade", novaEspecialidade);
                        if (!string.IsNullOrEmpty(novoTelefone)) cmd.Parameters.AddWithValue("@Telefone", novoTelefone);

                        cmd.Parameters.AddWithValue("@MedicoID", ProClass.MedicoID); // ID do médico logado

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

        // Previne a cópia e colagem em campos numéricos
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Control && e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // Bloqueia a ação sem exibir a mensagem
            }
        }

        // Restringe o campo de telefone a apenas números
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Rejeita a entrada
            }
        }

        // Evento para o botão de salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AtualizarDadosMedico();  // Chama o método para atualizar os dados
        }
    }
}
