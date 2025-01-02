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
    public partial class SysView : Form
    {
        public SysView()
        {
            InitializeComponent();
            SetDefaultView();
        }
        private void SwitchView(UserControl newView)
        {
            panelSys.Controls.Clear(); // Remove o conteúdo atual do painel
            panelSys.Controls.Add(newView); // Adiciona o novo UserControl
            newView.Dock = DockStyle.Fill; // Faz com que o controle ocupe o painel
        }
   

       
        private void LoadView(UserControl view)
        {
            panelSys.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panelSys.Controls.Add(view); // Adiciona a nova View ao painel
        }
        private void SetDefaultView()
        {
            PanelView_VisaoSistema_Stretched homeView = new PanelView_VisaoSistema_Stretched(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SistemaU.SystemID = 0;  // Resetando o ID do Utente

            // Exibir uma mensagem confirmando o logout
            MessageBox.Show("Você foi desconectado com sucesso.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

          
            Opening open = new Opening(); // Supondo que LoginForm seja o formulário de login
            open.Show();
            this.Hide();  // Oculta o formulário atual (opcional)
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            SwitchView(new Sysusers());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SwitchView(new SysB());
        }
    }
}
