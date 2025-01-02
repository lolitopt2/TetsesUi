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

    public partial class UtenteView : Form
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public UtenteView()
        {
         
            InitializeComponent();
            SetDefaultView();

        }
        private void SwitchView(UserControl newView)
        {
            panelUtente.Controls.Clear(); // Remove o conteúdo atual do painel
            panelUtente.Controls.Add(newView); // Adiciona o novo UserControl
            newView.Dock = DockStyle.Fill; // Faz com que o controle ocupe o painel
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlInfo()); // Carrega a view
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SwitchView(new PanelView_VisaoUTENTE()); // Carrega a view
        }
        private void LoadView(UserControl view)
        {
            panelUtente.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panelUtente.Controls.Add(view); // Adiciona a nova View ao painel
        }
        private void SetDefaultView()
        {
            PanelView_VisaoUTENTE homeView = new PanelView_VisaoUTENTE(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixa()); // Carrega a view
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggedUser.UtenteId = 0;  // Resetando o ID do Utente

            // Exibir uma mensagem confirmando o logout
            MessageBox.Show("Você foi desconectado com sucesso.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Redirecionar para a tela de login ou fechar o formulário atual
            // Para redirecionar para o formulário de login:
            Opening open = new Opening(); // Supondo que LoginForm seja o formulário de login
            open.Show();
            this.Hide();  // Oculta o formulário atual (opcional)
        }
    }
}
