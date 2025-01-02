using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetsesUi.ViewModels
{
    public partial class SysB : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";


        public SysB()
        {
            InitializeComponent();
            CarregarDados();
            if (dataGridView1.Columns["DeleteButton"] == null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "DeleteButton";
                btnDelete.HeaderText = "Eliminar";
                btnDelete.Text = "Excluir";
                btnDelete.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnDelete);
            }
        }


        private void CarregarDados()
        {

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    {
                        string query = $"SELECT * FROM baixas";

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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
        dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                try
                {
                   
                    if (dataGridView1.Rows[e.RowIndex].Cells["BaixaID"].Value is int id)
                    {
                    
                        DialogResult confirmation = MessageBox.Show(
                            "É para apagar?",
                            "Confirmar Exclusão",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (confirmation == DialogResult.Yes)
                        {
                          
                            string query = "DELETE FROM baixas WHERE BaixaID = @BaixaID";

                        
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                using (MySqlCommand command = new MySqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@BaixaID", id);
                                    command.ExecuteNonQuery();
                                }
                            }

                         
                            dataGridView1.Rows.RemoveAt(e.RowIndex);

                            MessageBox.Show("Item eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o ID do item selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show($"Erro ao eliminar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
