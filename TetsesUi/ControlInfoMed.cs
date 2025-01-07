using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TetsesUi
{
    public partial class ControlInfoMed : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public ControlInfoMed()
        {
            InitializeComponent();
            PreencherProClass();  // Preenche as informações do médico
            MostrarInfoMedico();  // Exibe as informações preenchidas
        }

        public void CarregarDadosEditMed(DadosEditMed dadosEditMed)
        {
            // Limpa o painel e adiciona o controle de edição
            panel1.Controls.Clear();
            panel1.Controls.Add(dadosEditMed);
            dadosEditMed.Dock = DockStyle.Fill;

            // Registra o evento para recarregar informações quando os dados forem atualizados
            dadosEditMed.DadosAtualizados += RecarregarInformacoes;
        }

        // Método para preencher os dados de ProClass a partir do banco de dados
        private void PreencherProClass()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Nome, Especialidade, Telefone, Email FROM Medicos WHERE MedicoID = @MedicoID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicoID", ProClass.MedicoID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ProClass.Nome = reader["Nome"].ToString();
                                ProClass.Especialidade = reader["Especialidade"].ToString();
                                ProClass.Telefone = Convert.ToInt32(reader["Telefone"]);
                                ProClass.Email = reader["Email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Médico não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar dados do médico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para exibir as informações do médico nas labels
        private void MostrarInfoMedico()
        {
            if (ProClass.MedicoID > 0)
            {
                lblNome2.Text = $"Nome: {ProClass.Nome}";
                lblEspecialidade.Text = $"Especialidade: {ProClass.Especialidade}";
                lblTel2.Text = $"Telefone: {ProClass.Telefone}";
                lblEmail2.Text = $"Email: {ProClass.Email}";
            }
            else
            {
                MessageBox.Show("Nenhum médico está logado ou informações inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblNome2.Text = "Nome: ";
                lblEspecialidade.Text = "Especialidade: ";
                lblTel2.Text = "Telefone: ";
                lblEmail2.Text = "Email: ";
            }
        }

        // Método para recarregar informações após atualização
        private void RecarregarInformacoes()
        {
            PreencherProClass(); // Atualiza os dados em ProClass
            MostrarInfoMedico(); // Atualiza a interface com os novos dados 
        }
    }
}
