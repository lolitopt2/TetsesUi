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
        // Definição da string de conexão com o banco de dados
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public ControlBaixaMed()
        {
            InitializeComponent();
            LoadData(); // Carrega os dados ao iniciar o controlo
        }

        // Método para carregar os dados das baixas na DataGridView
        private void LoadData()
        {
            string query = $"SELECT * FROM baixas WHERE MedicoID = {ProClass.MedicoID}";

            try
            {
                // Conexão ao banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table; // Atribui os dados à DataGridView
                }
            }
            catch (Exception ex)
            {
                // Caso ocorra erro, exibe uma mensagem
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para gerar o PDF com base no ID da baixa
        private void GerarPDFPorID(int baixaID)
        {
            int MedicoID = ProClass.MedicoID;

            // Obtém os dados da baixa a partir do banco de dados
            DataRow dadosBaixa = ObterDadosBaixaDoBanco(baixaID);

            if (dadosBaixa == null)
            {
                // Caso os dados não sejam encontrados, exibe uma mensagem
                MessageBox.Show("Nenhuma baixa encontrada com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o ID do médico corresponde ao médico logado
            if ((int)dadosBaixa["MedicoID"] != MedicoID)
            {
                MessageBox.Show("O ID do Médico não corresponde ao ID da Baixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostra a janela para escolher a pasta onde o PDF será salvo
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string pastaEscolhida = folderBrowserDialog.SelectedPath;
                string caminhoPDF = Path.Combine(pastaEscolhida, $"Baixa_{baixaID}.pdf");

                // Verifica se o arquivo já existe e pergunta se deve sobrescrever
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
                    // Criação do arquivo PDF
                    PdfWriter.GetInstance(documento, new FileStream(caminhoPDF, FileMode.Create));
                    documento.Open();

                    // Adiciona o título ao PDF
                    documento.Add(new Paragraph($"Relatório da Baixa - ID {baixaID}")
                    {
                        Alignment = Element.ALIGN_CENTER,
                        Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)
                    });

                    documento.Add(new Paragraph("\n"));

                    // Adiciona os dados da baixa ao PDF
                    documento.Add(new Paragraph($"BaixaID: {dadosBaixa["BaixaID"]}"));
                    documento.Add(new Paragraph($"MedicoID: {dadosBaixa["MedicoID"]}"));
                    documento.Add(new Paragraph($"UtenteID: {dadosBaixa["UtenteID"]}"));
                    documento.Add(new Paragraph($"DataInicio: {dadosBaixa["DataInicio"]}"));
                    documento.Add(new Paragraph($"DataFim: {dadosBaixa["DataFim"]}"));
                    documento.Add(new Paragraph($"Motivo: {dadosBaixa["Motivo"]}"));
                    documento.Add(new Paragraph($"Observacoes: {dadosBaixa["Observacoes"]}"));

                    documento.Add(new Paragraph("\n"));

                    // Exibe uma mensagem de sucesso quando o PDF for gerado corretamente
                    MessageBox.Show($"PDF gerado com sucesso!\nCaminho: {caminhoPDF}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Caso ocorra um erro ao gerar o PDF, exibe uma mensagem de erro
                    MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    documento.Close(); // Fecha o documento PDF
                }
            }
            else
            {
                // Caso nenhuma pasta seja selecionada, exibe uma mensagem
                MessageBox.Show("Nenhuma pasta foi selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para obter os dados da baixa no banco de dados
        private DataRow ObterDadosBaixaDoBanco(int baixaID)
        {
            string query = "SELECT * FROM baixas WHERE BaixaID = @BaixaID";

            DataTable tabela = new DataTable();

            try
            {
                // Conexão ao banco de dados
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
                // Caso ocorra um erro ao selecionar os dados do banco, exibe uma mensagem
                MessageBox.Show($"Erro ao selecionar dados do banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retorna a primeira linha da tabela se existirem dados, caso contrário, retorna null
            return tabela.Rows.Count > 0 ? tabela.Rows[0] : null;
        }

        // Evento do botão para criar uma nova baixa
        private void button_Criarbaixa_Click(object sender, EventArgs e)
        {
            CriarBaixaMedica form = new CriarBaixaMedica();
            form.BaixaCriada += Form_BaixaCriada; // Evento quando a baixa for criada
            form.ShowDialog();
        }

        // Método para recarregar os dados na tabela quando uma baixa for criada
        private void Form_BaixaCriada(object sender, EventArgs e)
        {
            LoadData(); // Recarrega os dados da tabela após a criação da baixa
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtBaixaID.Text, out int baixaID))
            {
                GerarPDFPorID(baixaID); // Chama o método para gerar o PDF se o ID for válido
            }
            else
            {
                // Caso o ID não seja válido, exibe uma mensagem de erro
                MessageBox.Show("Por favor, insira um ID de Baixa válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
