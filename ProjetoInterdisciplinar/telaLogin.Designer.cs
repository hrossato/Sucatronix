namespace ProjetoInterdisciplinar
{
    partial class telaLogin
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
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.textBox_Senha = new System.Windows.Forms.TextBox();
            this.lotaobogar = new System.Windows.Forms.Button();
            this.labelSenha = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Login
            // 
            this.textBox_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Login.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox_Login.Location = new System.Drawing.Point(201, 259);
            this.textBox_Login.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(168, 20);
            this.textBox_Login.TabIndex = 1;
            this.textBox_Login.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // textBox_Senha
            // 
            this.textBox_Senha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Senha.BackColor = System.Drawing.Color.White;
            this.textBox_Senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Senha.ForeColor = System.Drawing.Color.Black;
            this.textBox_Senha.Location = new System.Drawing.Point(201, 281);
            this.textBox_Senha.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.PasswordChar = '•';
            this.textBox_Senha.Size = new System.Drawing.Size(168, 20);
            this.textBox_Senha.TabIndex = 2;
            this.textBox_Senha.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // lotaobogar
            // 
            this.lotaobogar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lotaobogar.BackColor = System.Drawing.Color.DimGray;
            this.lotaobogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lotaobogar.ForeColor = System.Drawing.Color.White;
            this.lotaobogar.Location = new System.Drawing.Point(202, 306);
            this.lotaobogar.Margin = new System.Windows.Forms.Padding(2);
            this.lotaobogar.Name = "lotaobogar";
            this.lotaobogar.Size = new System.Drawing.Size(167, 76);
            this.lotaobogar.TabIndex = 3;
            this.lotaobogar.Text = "LOGAR";
            this.lotaobogar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.lotaobogar.UseVisualStyleBackColor = false;
            this.lotaobogar.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // labelSenha
            // 
            this.labelSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSenha.AutoSize = true;
            this.labelSenha.BackColor = System.Drawing.Color.Transparent;
            this.labelSenha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenha.Location = new System.Drawing.Point(151, 282);
            this.labelSenha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(46, 19);
            this.labelSenha.TabIndex = 0;
            this.labelSenha.Text = "Senha";
            this.labelSenha.Click += new System.EventHandler(this.LabelSenha_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(152, 259);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(43, 19);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login";
            this.labelLogin.Click += new System.EventHandler(this.Label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::ProjetoInterdisciplinar.Properties.Resources.btFechar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(512, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoInterdisciplinar.Properties.Resources.Sem_Título_2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 427);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // telaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 427);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lotaobogar);
            this.Controls.Add(this.textBox_Senha);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "telaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucatronix TOP";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.TextBox textBox_Senha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button lotaobogar;
        private System.Windows.Forms.Button button1;
    }
}

