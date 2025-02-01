using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TetsesUi.ViewModels
{
    public partial class ControlBaixaMed : UserControl
    {
        
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public ControlBaixaMed()
        {
            InitializeComponent();
            LoadData(); 
        }

   
        private void LoadData()
        {
            string query = $"SELECT * FROM baixas WHERE MedicoID = {ProClass.MedicoID}";

            try
            {
           
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table; 
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void GerarPDFPorID(int baixaID)
        {
            int MedicoID = ProClass.MedicoID;

           
            DataRow dadosBaixa = ObterDadosBaixaDoBanco(baixaID);

            if (dadosBaixa == null)
            {
               
                MessageBox.Show("Nenhuma baixa encontrada com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            if ((int)dadosBaixa["MedicoID"] != MedicoID)
            {
                MessageBox.Show("O ID do Médico não corresponde ao ID da Baixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

     
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string pastaEscolhida = folderBrowserDialog.SelectedPath;
                string caminhoPDF = Path.Combine(pastaEscolhida, $"Baixa_{baixaID}.pdf");

            
                if (File.Exists(caminhoPDF))
                {
                    var overwrite = MessageBox.Show("O arquivo já existe. Deseja sobrescrevê-lo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (overwrite == DialogResult.No)
                    {
                        return;
                    }
                }

                Document documento = new Document();
                try
                {
           
                    PdfWriter.GetInstance(documento, new FileStream(caminhoPDF, FileMode.Create));
                    documento.Open();

             
                    documento.Add(new Paragraph($"Relatório da Baixa - ID {baixaID}")
                    {
                        Alignment = Element.ALIGN_CENTER,
                        Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)
                    });

                    documento.Add(new Paragraph("\n"));

               
                    documento.Add(new Paragraph($"BaixaID: {dadosBaixa["BaixaID"]}"));
                    documento.Add(new Paragraph($"MedicoID: {dadosBaixa["MedicoID"]}"));
                    documento.Add(new Paragraph($"UtenteID: {dadosBaixa["UtenteID"]}"));
                    documento.Add(new Paragraph($"DataInicio: {dadosBaixa["DataInicio"]}"));
                    documento.Add(new Paragraph($"DataFim: {dadosBaixa["DataFim"]}"));
                    documento.Add(new Paragraph($"Motivo: {dadosBaixa["Motivo"]}"));
                    documento.Add(new Paragraph($"Observacoes: {dadosBaixa["Observacoes"]}"));

                    documento.Add(new Paragraph("\n"));

                  
                    MessageBox.Show($"PDF gerado com sucesso!\nCaminho: {caminhoPDF}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    documento.Close();
                }
            }
            else
            {
                
                MessageBox.Show("Nenhuma pasta foi selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    
        private DataRow ObterDadosBaixaDoBanco(int baixaID)
        {
            string query = "SELECT * FROM baixas WHERE BaixaID = @BaixaID";

            DataTable tabela = new DataTable();

            try
            {
           
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BaixaID", baixaID);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
                MessageBox.Show($"Erro ao selecionar dados do banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
            return tabela.Rows.Count > 0 ? tabela.Rows[0] : null;
        }

  
        private void button_Criarbaixa_Click(object sender, EventArgs e)
        {
            CriarBaixaMedica form = new CriarBaixaMedica();
            form.BaixaCriada += Form_BaixaCriada;
            form.ShowDialog();
        }


        private void Form_BaixaCriada(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtBaixaID.Text, out int baixaID))
            {
                GerarPDFPorID(baixaID); 
            }
            else
            {
           
                MessageBox.Show("Por favor, insira um ID de Baixa válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
