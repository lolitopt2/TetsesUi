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
    public partial class Sysusers : UserControl
    {
        public Sysusers()
        {
            InitializeComponent();
            SetDefaultView();
            SetDefaultView2();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void SwitchView(UserControl newView)
        {
            panel1.Controls.Clear(); 
            panel1.Controls.Add(newView); 
            newView.Dock = DockStyle.Fill; 
        }
      

      
        private void LoadView(UserControl view)
        {
            panel1.Controls.Clear(); 
            view.Dock = DockStyle.Fill; 
            panel1.Controls.Add(view); 
        }
      
        private void SetDefaultView()
        {
            SysProf homeView = new SysProf(); 
            LoadView(homeView);
        }

        private void LoadView2(UserControl view)
        {
            panel2.Controls.Clear(); 
            view.Dock = DockStyle.Fill; 
            panel2.Controls.Add(view); 
        }

        private void SetDefaultView2()
        {
            SysUtentes homeView = new SysUtentes();
            LoadView2(homeView); 
        }

    
    }
}
