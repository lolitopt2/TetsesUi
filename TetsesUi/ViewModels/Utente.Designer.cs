namespace TetsesUi.ViewModels
{
    partial class Utente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PassTxt = new System.Windows.Forms.MaskedTextBox();
            this.UtNum = new System.Windows.Forms.TextBox();
            this.LogUten = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 66);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serviços Baixas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 333);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº Utente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 438);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // PassTxt
            // 
            this.PassTxt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.PassTxt.Location = new System.Drawing.Point(266, 481);
            this.PassTxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.RejectInputOnFirstFailure = true;
            this.PassTxt.Size = new System.Drawing.Size(164, 31);
            this.PassTxt.TabIndex = 1;
            this.PassTxt.UseSystemPasswordChar = true;
            // 
            // UtNum
            // 
            this.UtNum.Location = new System.Drawing.Point(266, 375);
            this.UtNum.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.UtNum.Name = "UtNum";
            this.UtNum.Size = new System.Drawing.Size(164, 31);
            this.UtNum.TabIndex = 0;
            this.UtNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UtNum_KeyPress);
            // 
            // LogUten
            // 
            this.LogUten.Location = new System.Drawing.Point(280, 552);
            this.LogUten.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LogUten.Name = "LogUten";
            this.LogUten.Size = new System.Drawing.Size(150, 44);
            this.LogUten.TabIndex = 2;
            this.LogUten.Text = "Login";
            this.LogUten.UseVisualStyleBackColor = true;
            this.LogUten.Click += new System.EventHandler(this.LogUten_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TetsesUi.Properties.Resources.people;
            this.pictureBox2.Location = new System.Drawing.Point(318, 637);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TetsesUi.Properties.Resources.SNS;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(756, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Utente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 737);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LogUten);
            this.Controls.Add(this.UtNum);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Utente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox PassTxt;
        private System.Windows.Forms.TextBox UtNum;
        private System.Windows.Forms.Button LogUten;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}