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
    public partial class tela_consultarFornecedores : Form {
        private Fornecedor fornecedor;
        private BindingSource bindingSourceFornecedores;
        public tela_consultarFornecedores() {
            this.fornecedor = new Fornecedor();
            this.bindingSourceFornecedores = new BindingSource() {
                DataSource = this.fornecedor.ConsultarTodos().Select(value => (Fornecedor)value).ToList()
            };
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Tela_consultarFornecedores_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceFornecedores;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                cadastroFornecedor Outroform = new cadastroFornecedor(((Fornecedor)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceFornecedores.DataSource = this.fornecedor.ConsultarTodos().Select(value => (Fornecedor)value).ToList();
                this.bindingSourceFornecedores.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.fornecedor.Excluir(((Fornecedor)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourceFornecedores.DataSource = this.fornecedor.ConsultarTodos().Select(value => (Fornecedor)value).ToList();
            this.bindingSourceFornecedores.ResetBindings(false);
        }
    }
}
