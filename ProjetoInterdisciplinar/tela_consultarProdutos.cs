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
    public partial class tela_consultarProdutos : Form {
        private Produto produto;
        private BindingSource bindingSourceProdutos;
        public tela_consultarProdutos() {
            this.produto = new Produto();
            this.bindingSourceProdutos = new BindingSource() {
                DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList()
            };
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                cadastroProdutos Outroform = new cadastroProdutos(((Produto)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceProdutos.DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList();
                this.bindingSourceProdutos.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.produto.Excluir(((Produto)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourceProdutos.DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList();
            this.bindingSourceProdutos.ResetBindings(false);
        }

        private void Tela_consultarProdutos_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceProdutos;
        }
    }
}
