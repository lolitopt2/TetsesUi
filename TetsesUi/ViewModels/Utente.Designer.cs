﻿namespace TetsesUi.ViewModels
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serviços Baixas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nr utente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // PassTxt
            // 
            this.PassTxt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.PassTxt.Location = new System.Drawing.Point(361, 261);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.RejectInputOnFirstFailure = true;
            this.PassTxt.Size = new System.Drawing.Size(84, 20);
            this.PassTxt.TabIndex = 5;
            this.PassTxt.UseSystemPasswordChar = true;
            // 
            // UtNum
            // 
            this.UtNum.Location = new System.Drawing.Point(361, 206);
            this.UtNum.Name = "UtNum";
            this.UtNum.Size = new System.Drawing.Size(84, 20);
            this.UtNum.TabIndex = 6;
            this.UtNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UtNum_KeyPress);
            // 
            // LogUten
            // 
            this.LogUten.Location = new System.Drawing.Point(368, 298);
            this.LogUten.Name = "LogUten";
            this.LogUten.Size = new System.Drawing.Size(75, 23);
            this.LogUten.TabIndex = 7;
            this.LogUten.Text = "Login";
            this.LogUten.UseVisualStyleBackColor = true;
            this.LogUten.Click += new System.EventHandler(this.LogUten_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TetsesUi.Properties.Resources.SNS;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Utente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogUten);
            this.Controls.Add(this.UtNum);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Utente";
            this.Text = "Utente";
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
    }
}