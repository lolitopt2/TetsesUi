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
        public UtenteView()
        {
            InitializeComponent();
            SetDefaultView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utente newForm = new Utente();
            newForm.Show(); // Open the new form
            this.Hide();
        }
        private void SwitchView(UserControl newView)
        {
            panelUtente.Controls.Clear(); // Remove o conteúdo atual do painel
            panelUtente.Controls.Add(newView); // Adiciona o novo UserControl
            newView.Dock = DockStyle.Fill; // Faz com que o controle ocupe o painel
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixa()); // Carrega a view
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlStan()); // Carrega a view
        }
        private void LoadView(UserControl view)
        {
            panelUtente.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panelUtente.Controls.Add(view); // Adiciona a nova View ao painel
        }
        private void SetDefaultView()
        {
            ControlStan homeView = new ControlStan(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixa()); // Carrega a view
        }
    }
}
