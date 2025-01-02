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
            panel1.Controls.Clear(); // Remove o conteúdo atual do painel
            panel1.Controls.Add(newView); // Adiciona o novo UserControl
            newView.Dock = DockStyle.Fill; // Faz com que o controle ocupe o painel
        }
      

      
        private void LoadView(UserControl view)
        {
            panel1.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panel1.Controls.Add(view); // Adiciona a nova View ao painel
        }
      
        private void SetDefaultView()
        {
            SysProf homeView = new SysProf(); // Instancia a View padrão
            LoadView(homeView); // Carrega a View padrão no painel
        }

        private void LoadView2(UserControl view)
        {
            panel2.Controls.Clear(); // Limpa o conteúdo atual do painel
            view.Dock = DockStyle.Fill; // Faz com que a View preencha o painel
            panel2.Controls.Add(view); // Adiciona a nova View ao painel
        }

        private void SetDefaultView2()
        {
            SysUtentes homeView = new SysUtentes(); // Instancia a View padrão
            LoadView2(homeView); // Carrega a View padrão no painel
        }

    
    }
}
