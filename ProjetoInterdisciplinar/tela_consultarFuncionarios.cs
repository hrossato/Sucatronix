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
    public partial class tela_consultarFuncionarios : Form {
        private Funcionario funcionario;
        private BindingSource bindingSourceFuncionarios;
        public tela_consultarFuncionarios() {
            this.funcionario = new Funcionario();
            this.bindingSourceFuncionarios = new BindingSource() {
                DataSource = this.funcionario.ConsultarTodos().Select(value => (Funcionario)value).ToList()
            };
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                cadastroFuncionarios Outroform = new cadastroFuncionarios(((Funcionario)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceFuncionarios.DataSource = this.funcionario.ConsultarTodos().Select(value => (Funcionario)value).ToList();
                this.bindingSourceFuncionarios.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.funcionario.Excluir(((Funcionario)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourceFuncionarios.DataSource = this.funcionario.ConsultarTodos().Select(value => (Funcionario)value).ToList();
            this.bindingSourceFuncionarios.ResetBindings(false);
        }

        private void Tela_consultarFuncionarios_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceFuncionarios;
        }
    }
}
