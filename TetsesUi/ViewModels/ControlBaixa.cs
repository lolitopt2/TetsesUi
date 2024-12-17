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

namespace TetsesUi.ViewModels
{
    public partial class ControlBaixa : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        public ControlBaixa()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            // Conexão com o banco de dados

            string query = $"SELECT * FROM baixas WHERE UtenteID = {LoggedUser.UtenteId}";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Associa os dados ao DataGridView
                dataGridView1.DataSource = table;
            }
        }
    }
}
