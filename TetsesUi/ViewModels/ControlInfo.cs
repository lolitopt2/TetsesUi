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
        private string connectionString2 = "Server=localhost;Database=sns;Uid=root;Pwd=;";


        public ControlInfo()
        {
            InitializeComponent();
            MostrarInfoUtente();
            SetDefaultView();
           // MostrarIdENomeUtente();
        }
        private void SetDefaultView()
        {
            DadosEdit homeView = new DadosEdit(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }
        private void LoadView(UserControl view)
        {
            panel1.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panel1.Controls.Add(view); // Adiciona a nova View ao painel
        }
        private void MostrarInfoUtente()
        {
            if (LoggedUser.UtenteId > 0)
            {
                // Atribuindo os valores às Labels
                lblNome.Text = $"Nome: {LoggedUser.UtenteName}";
                lblMorada.Text = $"Morada: {LoggedUser.UtenteMorada}";
                lblEmail.Text = $"Email: {LoggedUser.UtenteEmail}";
                lblTele.Text = $"Telefone: {LoggedUser.UtenteTele}";
            }
            else
            {
                MessageBox.Show("Nenhum utente está logado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarIdENomeUtente()
        {
            // Verifica se o UtenteId está disponível
            if (LoggedUser.UtenteId > 0)
            {
                // Verifica se o nome do utente está disponível
                if (!string.IsNullOrEmpty(LoggedUser.UtenteName))
                {
                    // Exibe o ID e o nome do Utente em uma MessageBox
                    MessageBox.Show($"O ID do Utente logado é: {LoggedUser.UtenteId}\nNome: {LoggedUser.UtenteName}\nEmail: {LoggedUser.UtenteEmail}\nMorada:{LoggedUser.UtenteMorada}",
                                    "Informações do Utente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("O nome do utente não foi encontrado.",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // Se o UtenteId não estiver disponível, exibe uma mensagem de erro
                MessageBox.Show("Nenhum utente está logado.",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            MostrarInfoUtente();
        }
    }
}
