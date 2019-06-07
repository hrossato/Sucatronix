using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoInterdisciplinar
{
    public partial class telaLogin : Form
    {
        private Funcionario funcionario;
        public telaLogin()
        {
            this.funcionario = new Funcionario();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // textBox_Login.Focus();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void LabelSenha_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if(this.funcionario.Verificar(this.textBox_Login.Text, this.textBox_Senha.Text))
            {
                telaPrincipal tela = new telaPrincipal(this.funcionario);
                tela.Show();
                tela.Activate();
                this.Close();
            }
            else
            {
                Console.WriteLine("Não Logou");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
