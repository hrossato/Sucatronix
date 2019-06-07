namespace ProjetoInterdisciplinar {
    partial class cadastroProdutos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbPrecoProduto = new System.Windows.Forms.TextBox();
            this.tbEstoqueProduto = new System.Windows.Forms.TextBox();
            this.lbNumeroCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNomeProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPrecoProduto
            // 
            this.tbPrecoProduto.Location = new System.Drawing.Point(346, 98);
            this.tbPrecoProduto.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrecoProduto.Name = "tbPrecoProduto";
            this.tbPrecoProduto.Size = new System.Drawing.Size(158, 20);
            this.tbPrecoProduto.TabIndex = 39;
            // 
            // tbEstoqueProduto
            // 
            this.tbEstoqueProduto.Location = new System.Drawing.Point(109, 96);
            this.tbEstoqueProduto.Margin = new System.Windows.Forms.Padding(2);
            this.tbEstoqueProduto.Name = "tbEstoqueProduto";
            this.tbEstoqueProduto.Size = new System.Drawing.Size(136, 20);
            this.tbEstoqueProduto.TabIndex = 33;
            this.tbEstoqueProduto.TextChanged += new System.EventHandler(this.TbNumeroCliente_TextChanged);
            // 
            // lbNumeroCliente
            // 
            this.lbNumeroCliente.AutoSize = true;
            this.lbNumeroCliente.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroCliente.Location = new System.Drawing.Point(15, 97);
            this.lbNumeroCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNumeroCliente.Name = "lbNumeroCliente";
            this.lbNumeroCliente.Size = new System.Drawing.Size(90, 19);
            this.lbNumeroCliente.TabIndex = 32;
            this.lbNumeroCliente.Text = "Estoque atual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(249, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Preço unitário";
            // 
            // tbNomeProduto
            // 
            this.tbNomeProduto.Location = new System.Drawing.Point(139, 62);
            this.tbNomeProduto.Margin = new System.Windows.Forms.Padding(2);
            this.tbNomeProduto.Name = "tbNomeProduto";
            this.tbNomeProduto.Size = new System.Drawing.Size(365, 20);
            this.tbNomeProduto.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nome do Produto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImage = global::ProjetoInterdisciplinar.Properties.Resources.cMCk44Y;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 283);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(526, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = global::ProjetoInterdisciplinar.Properties.Resources.btFechar;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(498, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 28);
            this.button2.TabIndex = 42;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cadastroProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 283);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPrecoProduto);
            this.Controls.Add(this.tbEstoqueProduto);
            this.Controls.Add(this.lbNumeroCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNomeProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cadastroProdutos";
            this.Text = "cadastroProdutos";
            this.Load += new System.EventHandler(this.CadastroProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPrecoProduto;
        private System.Windows.Forms.TextBox tbEstoqueProduto;
        private System.Windows.Forms.Label lbNumeroCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNomeProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}