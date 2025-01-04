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

        // Método para preencher os dados de ProClass a partir do banco de dados
        private void PreencherProClass()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta para pegar os dados do médico, usando o MedicoID
                    string query = "SELECT Nome, Especialidade, Telefone, Email FROM Medicos WHERE MedicoID = @MedicoID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicoID", ProClass.MedicoID); // Assegura que o MedicoID está configurado

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Se um médico for encontrado
                            {
                                // Preenche as propriedades de ProClass com os dados do banco
                                ProClass.Nome = reader["Nome"].ToString();
                                ProClass.Especialidade = reader["Especialidade"].ToString();
                                ProClass.Telefone = Convert.ToInt32(reader["Telefone"]);
                                ProClass.Email = reader["Email"].ToString();

                                // Log para verificar se os dados foram carregados corretamente
                                Console.WriteLine($"Dados do médico preenchidos: Nome = {ProClass.Nome}, Especialidade = {ProClass.Especialidade}, Telefone = {ProClass.Telefone}, Email = {ProClass.Email}");
                            }
                            else
                            {
                                // Se o médico não for encontrado, exibe mensagem de erro
                                MessageBox.Show("Médico não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Caso haja erro ao acessar o banco de dados
                MessageBox.Show($"Erro ao buscar dados do médico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para exibir as informações do médico nas labels
        private void MostrarInfoMedico()
        {
            // Verifica se os dados do médico estão carregados corretamente
            if (ProClass.MedicoID > 0)
            {
                // Log para verificar os valores antes de exibir
                Console.WriteLine($"Nome: {ProClass.Nome}, Especialidade: {ProClass.Especialidade}, Telefone: {ProClass.Telefone}, Email: {ProClass.Email}");

                // Atribui os valores nas labels
                lblNome2.Text = $"Nome: {ProClass.Nome}";
                lblEspecialidade.Text = $"Especialidade: {ProClass.Especialidade}";
                lblTel2.Text = $"Telefone: {ProClass.Telefone}";
                lblEmail2.Text = $"Email: {ProClass.Email}";
            }
            else
            {
                // Caso não tenha informações disponíveis
                MessageBox.Show("Nenhum médico está logado ou informações inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpa os valores das Labels
                lblNome2.Text = "Nome: ";
                lblEspecialidade.Text = "Especialidade: ";
                lblTel2.Text = "Telefone: ";
                lblEmail2.Text = "Email: ";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
