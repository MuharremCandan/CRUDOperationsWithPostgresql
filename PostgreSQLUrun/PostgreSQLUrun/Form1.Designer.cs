
namespace PostgreSQLUrun
{
    partial class FrmMainPage
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
            this.btnUrun = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUrun
            // 
            this.btnUrun.Location = new System.Drawing.Point(36, 26);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(236, 364);
            this.btnUrun.TabIndex = 0;
            this.btnUrun.Text = "Ürün İşlemleri";
            this.btnUrun.UseVisualStyleBackColor = true;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.Location = new System.Drawing.Point(473, 26);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(236, 364);
            this.btnKategori.TabIndex = 1;
            this.btnKategori.Text = "Kategori İşelmleri";
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // FrmMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnUrun);
            this.Name = "FrmMainPage";
            this.Text = "Main Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button btnKategori;
    }
}