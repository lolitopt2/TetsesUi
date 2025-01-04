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
            panelMedico.Controls.Clear(); // Remove o conteúdo atual do painel
            panelMedico.Controls.Add(newView); // Adiciona o novo UserControl
            newView.Dock = DockStyle.Fill; // Faz com que o controle ocupe o painel
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlInfoMed()); // Carrega a view
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SwitchView(new PanelView_VisaoUTENTE());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixaMed());
        }
    }
}
