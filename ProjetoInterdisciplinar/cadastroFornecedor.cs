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
    public partial class cadastroFornecedor : Form
    {
        private Fornecedor fornecedor;
        public cadastroFornecedor(int fornecedor = 0)
        {
            this.fornecedor = new Fornecedor(fornecedor);
            InitializeComponent();
        }

        private void CadastroFornecedor_Load(object sender, EventArgs e)
        {
            if (this.fornecedor.Id > 0) {
                this.tbNomeFornecedor.Text = this.fornecedor.Nome;
                this.tbEmailFornecedor.Text = this.fornecedor.Email;
                this.tbTelefoneFornecedor.Text = this.fornecedor.Telefone;
                this.tbEnderecoFornecedor.Text = this.fornecedor.Rua;
                this.tbNumeroFornecedor.Text = this.fornecedor.Numero;
                this.tbBairroFornecedor.Text = this.fornecedor.Bairro;
                this.tbCepFornecedor.Text = this.fornecedor.Cep;
                this.tbObservacoesFornecedor.Text = this.fornecedor.Complemento;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
                    }

        private void TbTipoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) {
            this.fornecedor.Nome = this.tbNomeFornecedor.Text;
            this.fornecedor.Email = this.tbEmailFornecedor.Text;
            this.fornecedor.Telefone = this.tbTelefoneFornecedor.Text;
            this.fornecedor.Rua = this.tbEnderecoFornecedor.Text;
            this.fornecedor.Numero = this.tbNumeroFornecedor.Text;
            this.fornecedor.Bairro = this.tbBairroFornecedor.Text;
            this.fornecedor.Cep = this.tbCepFornecedor.Text;
            this.fornecedor.Complemento = this.tbObservacoesFornecedor.Text;
            if (this.fornecedor.Id > 0) {
                if (this.fornecedor.Atualizar()) {
                    MessageBox.Show("Fornecedor atualizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                if (this.fornecedor.Inserir()) {
                    MessageBox.Show("Fornecedor criado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
