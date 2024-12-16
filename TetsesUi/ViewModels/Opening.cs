using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetsesUi.ViewModels;
using TetsesUi.ViewModels.Admin;

namespace TetsesUi
{
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }

        private void Opening_Load(object sender, EventArgs e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ProButton_Click(object sender, EventArgs e)
        {
            Admin admin= new Admin();
            admin.Show();
            this.Hide();
        }

        private void UtButton_Click(object sender, EventArgs e)
        {

           Utente utente = new Utente();
            utente.Show();
            this.Hide();
        }

        private void SysButton_Click(object sender, EventArgs e)
        {
            Sys sys = new Sys();
            sys.Show();
            this.Hide();
        }
    }
}
