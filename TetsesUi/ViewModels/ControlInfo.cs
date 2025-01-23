using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetsesUi.ViewModels
{

    public partial class ControlInfo : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        public ControlInfo()
        {
            InitializeComponent();
            PreencherLoggedUser();
            MostrarInfoUtente();
        }


        public void CarregarDadosEditUtente(DadosEdit dadosEdit)
        {
            // Limpa o painel e adiciona o controle de edição
            panel1.Controls.Clear();
            panel1.Controls.Add(dadosEdit);
            dadosEdit.Dock = DockStyle.Fill;

            // Registra o evento para recarregar informações quando os dados forem atualizados
            dadosEdit.DadosAtualizados += RecarregarInformacoesUt;
        }

        private void PreencherLoggedUser()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Nome, Email, Telefone, Morada FROM UTENTES WHERE UtenteId = @UtenteID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UtenteID", LoggedUser.UtenteId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LoggedUser.UtenteName = reader["Nome"].ToString();
                                LoggedUser.UtenteEmail = reader["Email"].ToString();
                                LoggedUser.UtenteTele = reader["Telefone"].ToString();
                                LoggedUser.UtenteMorada = reader["Morada"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Utente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void MostrarInfoUtente()
        {
            if (LoggedUser.UtenteId > 0)
            {
                lblNome.Text = $"Nome: {LoggedUser.UtenteName}";
                lblMorada.Text = $"Morada: {LoggedUser.UtenteMorada}";
                lblTele.Text = $"Telefone:  {LoggedUser.UtenteTele}";
                lblEmail.Text = $"Email:  {LoggedUser.UtenteEmail}";
            }
            else
            {
                MessageBox.Show("Nenhum utente está logado ou informações inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblNome.Text = "Nome: ";
                lblMorada.Text = "Morada: ";
                lblTele.Text = "Telefone: ";
                lblEmail.Text = "Email: ";
            }
        }

        private void RecarregarInformacoesUt()
        {
            PreencherLoggedUser(); // Atualiza os dados em ProClass
            MostrarInfoUtente(); // Atualiza a interface com os novos dados 
        }  
    }
}
