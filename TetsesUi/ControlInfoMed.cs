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
            PreencherProClass();  
            MostrarInfoMedico(); 
        }

        public void CarregarDadosEditMed(DadosEditMed dadosEditMed)
        {
           
            panel1.Controls.Clear();
            panel1.Controls.Add(dadosEditMed);
            dadosEditMed.Dock = DockStyle.Fill;

    
            dadosEditMed.DadosAtualizados += RecarregarInformacoes;
        }


        private void PreencherProClass()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Nome, Especialidade, Telefone, Email, Instituicao FROM Medicos WHERE MedicoID = @MedicoID";
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
                                ProClass.Instituicao = reader["Instituicao"].ToString();
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


        private void MostrarInfoMedico()
        {
            if (ProClass.MedicoID > 0)
            {
                lblNome2.Text = $"Nome: {ProClass.Nome}";
                lblEspecialidade.Text = $"Especialidade: {ProClass.Especialidade}";
                lblTel2.Text = $"Telefone: {ProClass.Telefone}";
                lblEmail2.Text = $"Email: {ProClass.Email}";
                lblInst.Text = $"Instituição: {ProClass.Instituicao}";

            }
            else
            {
                MessageBox.Show("Nenhum médico está logado ou informações inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblNome2.Text = "Nome: ";
                lblEspecialidade.Text = "Especialidade: ";
                lblTel2.Text = "Telefone: ";
                lblEmail2.Text = "Email: ";
                lblInst.Text = "Instituição:";
            }
        }


        private void RecarregarInformacoes()
        {
            PreencherProClass(); 
            MostrarInfoMedico(); 
        }

        private void ControlInfoMed_Load(object sender, EventArgs e)
        {

        }
    }
}
