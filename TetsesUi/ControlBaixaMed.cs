﻿using iTextSharp.text;
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
            // Consulta para buscar as baixas associadas ao MedicoID logado
            string query = $"SELECT * FROM baixas WHERE MedicoID = {ProClass.MedicoID}";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Associa os dados ao DataGridView
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void GerarPDFPorID(int baixaID)
        {
            // Busca os dados da baixa no banco de dados
            DataRow dadosBaixa = ObterDadosBaixaDoBanco(baixaID);

            if (dadosBaixa == null)
            {
                MessageBox.Show("Nenhuma baixa encontrada com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o ID do Médico coincide com o ID logado
            if ((int)dadosBaixa["MedicoID"] != ProClass.MedicoID)
            {
                MessageBox.Show("O ID do Médico não corresponde ao ID da Baixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string pastaEscolhida = folderBrowserDialog.SelectedPath;
                string caminhoPDF = Path.Combine(pastaEscolhida, $"Baixa_{baixaID}.pdf");

                Document documento = new Document();
                PdfWriter.GetInstance(documento, new FileStream(caminhoPDF, FileMode.Create));

                try
                {
                    documento.Open();

                    // Adiciona o título
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
                MessageBox.Show("Você não selecionou nenhuma pasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Erro ao buscar dados do banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tabela.Rows.Count > 0 ? tabela.Rows[0] : null;
        }
    }
}
