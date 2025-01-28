namespace TetsesUi
{
    partial class CriarBaixaMedica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriarBaixaMedica));
            this.txtDataFim = new System.Windows.Forms.DateTimePicker();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstadoBaixa = new System.Windows.Forms.TextBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDatadefim = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUtente = new System.Windows.Forms.Label();
            this.labelDatadeinicio = new System.Windows.Forms.Label();
            this.txtMotivoBaixa = new System.Windows.Forms.TextBox();
            this.txtIDutente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(133, 294);
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(191, 20);
            this.txtDataFim.TabIndex = 35;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(133, 256);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(191, 20);
            this.txtDataInicio.TabIndex = 34;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(133, 351);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(91, 48);
            this.btnSalvar.TabIndex = 33;
            this.btnSalvar.Text = "Criar Baixa Médica";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(34, 219);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 31;
            this.labelEstado.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Observações:";
            // 
            // txtEstadoBaixa
            // 
            this.txtEstadoBaixa.Location = new System.Drawing.Point(133, 216);
            this.txtEstadoBaixa.Name = "txtEstadoBaixa";
            this.txtEstadoBaixa.Size = new System.Drawing.Size(191, 20);
            this.txtEstadoBaixa.TabIndex = 29;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(133, 176);
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(191, 20);
            this.txtObservacoes.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Criação de Baixa Médica";
            // 
            // labelDatadefim
            // 
            this.labelDatadefim.AutoSize = true;
            this.labelDatadefim.Location = new System.Drawing.Point(34, 300);
            this.labelDatadefim.Name = "labelDatadefim";
            this.labelDatadefim.Size = new System.Drawing.Size(85, 13);
            this.labelDatadefim.TabIndex = 26;
            this.labelDatadefim.Text = "Data de término:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Motivo:";
            // 
            // labelUtente
            // 
            this.labelUtente.AutoSize = true;
            this.labelUtente.Location = new System.Drawing.Point(34, 102);
            this.labelUtente.Name = "labelUtente";
            this.labelUtente.Size = new System.Drawing.Size(56, 13);
            this.labelUtente.TabIndex = 24;
            this.labelUtente.Text = "ID Utente:";
            // 
            // labelDatadeinicio
            // 
            this.labelDatadeinicio.AutoSize = true;
            this.labelDatadeinicio.Location = new System.Drawing.Point(34, 262);
            this.labelDatadeinicio.Name = "labelDatadeinicio";
            this.labelDatadeinicio.Size = new System.Drawing.Size(77, 13);
            this.labelDatadeinicio.TabIndex = 23;
            this.labelDatadeinicio.Text = "Data de ínicio:";
            // 
            // txtMotivoBaixa
            // 
            this.txtMotivoBaixa.Location = new System.Drawing.Point(133, 139);
            this.txtMotivoBaixa.Name = "txtMotivoBaixa";
            this.txtMotivoBaixa.Size = new System.Drawing.Size(191, 20);
            this.txtMotivoBaixa.TabIndex = 22;
            // 
            // txtIDutente
            // 
            this.txtIDutente.Location = new System.Drawing.Point(133, 102);
            this.txtIDutente.Name = "txtIDutente";
            this.txtIDutente.Size = new System.Drawing.Size(191, 20);
            this.txtIDutente.TabIndex = 36;
            // 
            // CriarBaixaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 432);
            this.Controls.Add(this.txtIDutente);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstadoBaixa);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDatadefim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelUtente);
            this.Controls.Add(this.labelDatadeinicio);
            this.Controls.Add(this.txtMotivoBaixa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CriarBaixaMedica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Baixa Médica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtDataFim;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstadoBaixa;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelDatadefim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUtente;
        private System.Windows.Forms.Label labelDatadeinicio;
        private System.Windows.Forms.TextBox txtMotivoBaixa;
        private System.Windows.Forms.TextBox txtIDutente;
    }
}