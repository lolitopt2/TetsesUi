namespace TetsesUi
{
    partial class Opening
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opening));
            this.SysButton = new System.Windows.Forms.Button();
            this.UtButton = new System.Windows.Forms.Button();
            this.ProButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.dbload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SysButton
            // 
            this.SysButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SysButton.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysButton.Location = new System.Drawing.Point(100, 105);
            this.SysButton.Name = "SysButton";
            this.SysButton.Size = new System.Drawing.Size(142, 84);
            this.SysButton.TabIndex = 1;
            this.SysButton.Text = "Sistema";
            this.SysButton.UseVisualStyleBackColor = true;
            this.SysButton.Click += new System.EventHandler(this.SysButton_Click);
            // 
            // UtButton
            // 
            this.UtButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UtButton.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UtButton.Location = new System.Drawing.Point(100, 195);
            this.UtButton.Name = "UtButton";
            this.UtButton.Size = new System.Drawing.Size(142, 84);
            this.UtButton.TabIndex = 2;
            this.UtButton.Text = "Utente";
            this.UtButton.UseVisualStyleBackColor = true;
            this.UtButton.Click += new System.EventHandler(this.UtButton_Click);
            // 
            // ProButton
            // 
            this.ProButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProButton.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProButton.Location = new System.Drawing.Point(100, 285);
            this.ProButton.Name = "ProButton";
            this.ProButton.Size = new System.Drawing.Size(142, 84);
            this.ProButton.TabIndex = 3;
            this.ProButton.Text = "Profissional";
            this.ProButton.UseVisualStyleBackColor = true;
            this.ProButton.Click += new System.EventHandler(this.ProButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Gray;
            this.Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Time.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Time.Location = new System.Drawing.Point(146, 371);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(2, 15);
            this.Time.TabIndex = 4;
            // 
            // dbload
            // 
            this.dbload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dbload.Location = new System.Drawing.Point(132, 389);
            this.dbload.Name = "dbload";
            this.dbload.Size = new System.Drawing.Size(77, 24);
            this.dbload.TabIndex = 5;
            this.dbload.Text = "DB Con";
            this.dbload.UseVisualStyleBackColor = true;
            this.dbload.Click += new System.EventHandler(this.dbload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TetsesUi.Properties.Resources.SNS;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(58, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Opening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 434);
            this.Controls.Add(this.dbload);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.ProButton);
            this.Controls.Add(this.UtButton);
            this.Controls.Add(this.SysButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Opening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNS - Página Inicial";
            this.Load += new System.EventHandler(this.Opening_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SysButton;
        private System.Windows.Forms.Button UtButton;
        private System.Windows.Forms.Button ProButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
      
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Button dbload;
    }
}

