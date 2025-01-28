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
    public partial class AdmView : Form
    {
        public AdmView()
        {
            InitializeComponent();
            SetDefaultView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggedUser.UtenteId = 0;


            MessageBox.Show("Você foi desconectado com sucesso.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Opening open = new Opening();
            open.Show();
            this.Hide();
        }

        private void SwitchView(UserControl newView)
        {
            panelMedico.Controls.Clear();
            panelMedico.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instancia o ControlInfoMed
            ControlInfoMed controlInfoMed = new ControlInfoMed();

            // Instancia o DadosEditMed e passa para o painel do ControlInfoMed
            DadosEditMed dadosEditMed = new DadosEditMed(); // Instancia o UserControl DadosEditMed

            // Carrega a view ControlInfoMed e o UserControl DadosEditMed no painel
            SwitchView(controlInfoMed);

            // Agora, dentro da ControlInfoMed, queremos carregar o DadosEditMed no painel.
            controlInfoMed.CarregarDadosEditMed(dadosEditMed);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SwitchView(new PanelVIEW_VisaoSistema());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixaMed());
        }

        private void LoadView(UserControl view)
        {
            panelMedico.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panelMedico.Controls.Add(view); // Adiciona a nova View ao painel
        }
        private void SetDefaultView()
        {
            PanelVIEW_VisaoSistema homeView = new PanelVIEW_VisaoSistema(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }
    }
}
