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
using TetsesUi.ViewModels;
using TetsesUi.ViewModels.Admin;

namespace TetsesUi
{
    public partial class Opening : Form
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
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
            Admin admin = new Admin();
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
        public bool VerifyConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // Attempt to open the connection
                    MessageBox.Show("Conectado", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true; // Connection is successful
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligaçao com erros" + ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Connection failed
            }
        }
        private void dbload_Click(object sender, EventArgs e)
        {
            Opening dbHelper = new Opening();

            if (dbHelper.VerifyConnection())
            {
                // Proceed with other actions if the connection is successful
                MessageBox.Show("Siga para o 20 KappA", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Handle any actions if the connection failed
                MessageBox.Show("Confirma tudo denovo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
