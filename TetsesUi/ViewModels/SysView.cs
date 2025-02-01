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
            panelSys.Controls.Clear(); 
            panelSys.Controls.Add(newView); 
            newView.Dock = DockStyle.Fill; 
        }
   

       
        private void LoadView(UserControl view)
        {
            panelSys.Controls.Clear(); 
            view.Dock = DockStyle.Fill; 
            panelSys.Controls.Add(view);
        }
        private void SetDefaultView()
        {
            PanelView_VisaoSistema_Stretched homeView = new PanelView_VisaoSistema_Stretched(); 
            LoadView(homeView); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SistemaU.SystemID = 0;  

         
            MessageBox.Show("Você foi desconectado com sucesso.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

          
            Opening open = new Opening(); 
            open.Show();
            this.Hide(); 
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
