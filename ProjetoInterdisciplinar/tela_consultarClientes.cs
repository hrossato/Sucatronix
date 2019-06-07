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
    public partial class tela_consultarClientes : Form {
        private Cliente cliente;
        private BindingSource bindingSourceClientes;
        public tela_consultarClientes() {
            this.cliente = new Cliente();
            this.bindingSourceClientes = new BindingSource() {
                DataSource = this.cliente.ConsultarTodos().Select(value => (Cliente)value).ToList()
            };
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Tela_consultarClientes_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceClientes;
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                cadastroClientes Outroform = new cadastroClientes(((Cliente)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceClientes.DataSource = this.cliente.ConsultarTodos().Select(value => (Cliente)value).ToList();
                this.bindingSourceClientes.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.cliente.Excluir(((Cliente)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourceClientes.DataSource = this.cliente.ConsultarTodos().Select(value => (Cliente)value).ToList();
            this.bindingSourceClientes.ResetBindings(false);
        }
    }
}
