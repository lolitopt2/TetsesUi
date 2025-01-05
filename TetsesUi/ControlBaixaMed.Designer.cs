namespace TetsesUi.ViewModels
{
    partial class ControlBaixaMed
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBaixaID = new System.Windows.Forms.TextBox();
            this.button_Criarbaixa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(376, 322);
            this.dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtBaixaID
            // 
            this.txtBaixaID.Location = new System.Drawing.Point(404, 123);
            this.txtBaixaID.Name = "txtBaixaID";
            this.txtBaixaID.Size = new System.Drawing.Size(100, 20);
            this.txtBaixaID.TabIndex = 4;
            // 
            // button_Criarbaixa
            // 
            this.button_Criarbaixa.Location = new System.Drawing.Point(404, 32);
            this.button_Criarbaixa.Name = "button_Criarbaixa";
            this.button_Criarbaixa.Size = new System.Drawing.Size(107, 23);
            this.button_Criarbaixa.TabIndex = 5;
            this.button_Criarbaixa.Text = "Criar Nova Baixa";
            this.button_Criarbaixa.UseVisualStyleBackColor = true;
            // 
            // ControlBaixaMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Criarbaixa);
            this.Controls.Add(this.txtBaixaID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ControlBaixaMed";
            this.Size = new System.Drawing.Size(527, 324);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBaixaID;
        private System.Windows.Forms.Button button_Criarbaixa;
    }
}
