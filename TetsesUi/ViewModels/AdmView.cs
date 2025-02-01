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
       
            ControlInfoMed controlInfoMed = new ControlInfoMed();

   
            DadosEditMed dadosEditMed = new DadosEditMed(); 
       
            SwitchView(controlInfoMed);

         
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
            panelMedico.Controls.Clear(); 
            view.Dock = DockStyle.Fill; 
            panelMedico.Controls.Add(view); 
        }
        private void SetDefaultView()
        {
            PanelVIEW_VisaoSistema homeView = new PanelVIEW_VisaoSistema(); 
            LoadView(homeView); 
        }
    }
}
