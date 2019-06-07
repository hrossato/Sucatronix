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
    public partial class cadastroFuncionarios : Form
    {
        private Funcionario funcionario;
        public cadastroFuncionarios(int funcionario = 0)
        {
            this.funcionario = new Funcionario(funcionario);
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TbTipoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void LbTelefoneForncedor_Click(object sender, EventArgs e)
        {

        }

        private void TbTelefoneFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbTipoFornecedor_Click(object sender, EventArgs e)
        {

        }

        private void TbTipoCliente_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CadastroFuncionarios_Load(object sender, EventArgs e) {
            if (this.funcionario.Id > 0) {
                this.tbNomeFuncionario.Text = this.funcionario.Nome;
                this.tbCpfFuncionario.Text = this.funcionario.Cpf;
                this.textBox1.Text = this.funcionario.Rg;
                this.dateTimePicker1.Value = this.funcionario.DataNascimento;
                this.tbEmailFuncionario.Text = this.funcionario.Email;
                this.textBox3.Text = this.funcionario.Senha;
                this.tbTelefoneUsuario.Text = this.funcionario.Telefone;
                this.tbCepUsuario.Text = this.funcionario.Cep;
                this.tbEnderecoUsuario.Text = this.funcionario.Rua;
                this.tbNumeroUsuario.Text = this.funcionario.Numero;
                this.tbBairroUsuario.Text = this.funcionario.Bairro;
                this.tbObservacoesUsuario.Text = this.funcionario.Complemento;
                this.comboBox1.SelectedItem = this.funcionario.Tipo;
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.funcionario.Nome = this.tbNomeFuncionario.Text;
            this.funcionario.Cpf = this.tbCpfFuncionario.Text;
            this.funcionario.Rg = this.textBox1.Text;
            this.funcionario.DataNascimento = this.dateTimePicker1.Value;
            this.funcionario.Email = this.tbEmailFuncionario.Text;
            this.funcionario.Senha = this.textBox3.Text;
            this.funcionario.Telefone = this.tbTelefoneUsuario.Text;
            this.funcionario.Cep = this.tbCepUsuario.Text;
            this.funcionario.Rua = this.tbEnderecoUsuario.Text;
            this.funcionario.Numero = this.tbNumeroUsuario.Text;
            this.funcionario.Bairro = this.tbBairroUsuario.Text;
            this.funcionario.Complemento = this.tbObservacoesUsuario.Text;
            this.funcionario.Tipo = this.comboBox1.SelectedItem.ToString();
            if (this.funcionario.Id > 0) {
                if (this.funcionario.Atualizar()) {
                    MessageBox.Show("Funcionário atualizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                if (this.funcionario.Inserir()) {
                    MessageBox.Show("Funcionário criado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }
    }
}
