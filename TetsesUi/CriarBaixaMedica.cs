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

namespace TetsesUi
{
    public partial class CriarBaixaMedica : Form
    {

        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        int medicoId = ProClass.MedicoID;
        public event EventHandler BaixaCriada;

        public CriarBaixaMedica()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
     
            if (!int.TryParse(txtIDutente.Text.Trim(), out int utenteID))
            {
                MessageBox.Show("Por favor, insira um ID de paciente válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!PacienteExiste(utenteID))
            {
                MessageBox.Show("Paciente não encontrado. Verifique o ID inserido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            if (txtDataInicio.Value > txtDataFim.Value)
            {
                MessageBox.Show("A data de início não pode ser posterior à data de fim!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
            
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO baixas (MedicoID, UtenteID, DataInicio, DataFim, Motivo, Observacoes)
                                 VALUES (@MedicoID, @UtenteID, @DataInicio, @DataFim, @Motivo, @Observacoes)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicoID", medicoId);
                        cmd.Parameters.AddWithValue("@UtenteID", utenteID);
                        cmd.Parameters.AddWithValue("@DataInicio", txtDataInicio.Value);
                        cmd.Parameters.AddWithValue("@DataFim", txtDataFim.Value);
                        cmd.Parameters.AddWithValue("@Motivo", txtMotivoBaixa.Text.Trim());
                        cmd.Parameters.AddWithValue("@Observacoes", txtObservacoes.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Baixa criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar baixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                BaixaCriada?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a baixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private bool PacienteExiste(int utenteID)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Utentes WHERE UtenteID = @UtenteID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UtenteID", utenteID);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar o paciente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
