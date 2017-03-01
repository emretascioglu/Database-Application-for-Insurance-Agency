namespace sigortaacentasi
{
    partial class Hosgeldiniz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hosgeldiniz));
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.lblKullaniciadi = new System.Windows.Forms.Label();
            this.lblParola = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(170, 37);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(121, 20);
            this.txtKullanici.TabIndex = 0;
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(170, 83);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(121, 20);
            this.txtParola.TabIndex = 1;
            // 
            // lblKullaniciadi
            // 
            this.lblKullaniciadi.AutoSize = true;
            this.lblKullaniciadi.Location = new System.Drawing.Point(35, 37);
            this.lblKullaniciadi.Name = "lblKullaniciadi";
            this.lblKullaniciadi.Size = new System.Drawing.Size(70, 13);
            this.lblKullaniciadi.TabIndex = 2;
            this.lblKullaniciadi.Text = "Kullanıcı Adı :";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.Location = new System.Drawing.Point(35, 83);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(46, 13);
            this.lblParola.TabIndex = 3;
            this.lblParola.Text = "Parola : ";
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGiris.Location = new System.Drawing.Point(170, 140);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(121, 40);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 133);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Hosgeldiniz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(365, 270);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.lblKullaniciadi);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKullanici);
            this.Name = "Hosgeldiniz";
            this.Text = "Hosgeldiniz";
            this.Load += new System.EventHandler(this.Hosgeldiniz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Label lblKullaniciadi;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}