﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetsesUi.ViewModels
{
    public partial class ControlBaixa : UserControl
    {
        private string connectionString = "Server=localhost;Database=sns;Uid=root;Pwd=;";
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // Obtém o ID do Utente armazenado na classe LoggedUser
            int utenteID = LoggedUser.UtenteId;

            // Procura os dados da baixa no banco de dados
            DataRow dadosBaixa = ObterDadosBaixaDoBanco(baixaID);

            if (dadosBaixa == null)
            {
                MessageBox.Show("Nenhuma baixa encontrada com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o ID do Utente corresponde ao ID do Utente na Baixa
            if ((int)dadosBaixa["UtenteID"] != utenteID)
            {
                MessageBox.Show("O ID do Utente não corresponde ao ID da Baixa. Não é possível escolher o local de salvamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Impede a escolha do diretório e geração do PDF
            }

            // Se os IDs coincidirem, abre o diálogo para o usuário escolher a pasta
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Obtém o diretório escolhido pelo usuário
                string pastaEscolhida = folderBrowserDialog.SelectedPath;

                // Define o caminho completo do arquivo PDF (usando o diretório escolhido)
                string caminhoPDF = Path.Combine(pastaEscolhida, $"Baixa_{baixaID}.pdf");

                // Cria o documento PDF
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

        // Método para buscar dados no banco de dados
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

            // Retorna a primeira linha se existir
            if (tabela.Rows.Count > 0)
            {
                return tabela.Rows[0];
            }

            return null;
        }
    }
}
