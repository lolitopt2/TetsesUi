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

    public partial class UtenteView : Form
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";

        public UtenteView()
        {

            InitializeComponent();
            SetDefaultView();
            IniciarCheckBaixasComDelay();

        }
        private async void IniciarCheckBaixasComDelay()
        {
         
            await Task.Delay(5000); 

  
            CheckBaixas();
        }
        public void SwitchView(UserControl newView)
        {
            panelUtente.Controls.Clear(); 
            panelUtente.Controls.Add(newView); 
            newView.Dock = DockStyle.Fill; 
        }
        private void button2_Click(object sender, EventArgs e)
        {
   
            var controlInfo = new ControlInfo();
            SwitchView(controlInfo);

        
            var dadosEdit = new DadosEdit();
            controlInfo.CarregarDadosEditUtente(dadosEdit);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SwitchView(new PanelView_VisaoUTENTE()); 
        }
        private void LoadView(UserControl view)
        {
            panelUtente.Controls.Clear(); 
            view.Dock = DockStyle.Fill; 
            panelUtente.Controls.Add(view);
        }
        private void SetDefaultView()
        {
            PanelView_VisaoUTENTE homeView = new PanelView_VisaoUTENTE(); 
            LoadView(homeView); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchView(new ControlBaixa());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggedUser.UtenteId = 0;  

          
            MessageBox.Show("Você foi desconectado com sucesso.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Opening open = new Opening(); 
            open.Show();
            this.Hide();  
        }
        private void CheckBaixas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string query = @"
                SELECT DataFim 
                FROM Baixas 
                WHERE UtenteId = @UtenteId 
                  AND DataFim <= @DataFim 
                  AND Estado != 'Inválida';";




                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@UtenteId", LoggedUser.UtenteId);
                        cmd.Parameters.AddWithValue("@DataFim", DateTime.Today.AddDays(3));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               
                               
                                DateTime dataFim = Convert.ToDateTime(reader["DataFim"]);

                                MessageBox.Show(
                                    $"A baixa  está prestes a chegar ao fim  {dataFim:dd/MM/yyyy}.",
                                    "Alerta de Baixa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
                MessageBox.Show(
                    $"Erro ao buscar os dados: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

}

            
