using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoInterdisciplinar {
    public partial class cadastroProdutos : Form {
        private Produto produto;
        public cadastroProdutos(int produto = 0) {
            this.produto = new Produto(produto);
            InitializeComponent();
        }

        private void TbNumeroCliente_TextChanged(object sender, EventArgs e) {

        }

        private void Button1_Click(object sender, EventArgs e) {
            this.produto.Nome = this.tbNomeProduto.Text;
            this.produto.EstoqueAtual = Convert.ToDouble(this.tbEstoqueProduto.Text);
            this.produto.Preco = Convert.ToDouble(this.tbPrecoProduto.Text);
            if (this.produto.Id > 0) {
                if (this.produto.Atualizar()) {
                    MessageBox.Show("Produto atualizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                if (this.produto.Inserir()) {
                    MessageBox.Show("Produto criado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private void CadastroProdutos_Load(object sender, EventArgs e) {
            if (this.produto.Id > 0) {
                this.tbNomeProduto.Text = this.produto.Nome;
                this.tbEstoqueProduto.Text = this.produto.EstoqueAtual.ToString();
                this.tbPrecoProduto.Text = this.produto.Preco.ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
