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
    public partial class tela_consultarAlmoxarifado : Form {
        private readonly Funcionario funcionario;
        private Solicitacao solicitacao;
        private BindingSource bindingSourceSolicitacao;
        public tela_consultarAlmoxarifado(Funcionario funcionario) {
            this.funcionario = funcionario;
            this.solicitacao = new Solicitacao();
            this.bindingSourceSolicitacao = new BindingSource() {
                DataSource = (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER" ? this.solicitacao.ConsultarTodos() : this.solicitacao.GetBySolicitante(this.funcionario.Id)).Select(value => (Solicitacao) value).ToList()
            };
            InitializeComponent();
        }

        private void Tela_consultarAlmoxarifado_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceSolicitacao;
            if (this.funcionario.Tipo != "ALMOXARIFADO" || this.funcionario.Tipo != "SUPERUSER") {
                this.button2.Enabled = false;
                this.button3.Enabled = false;
            }
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                tela_Almoxarifado Outroform = new tela_Almoxarifado(this.funcionario, ((Solicitacao)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceSolicitacao.DataSource = (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER" ? this.solicitacao.ConsultarTodos() : this.solicitacao.GetBySolicitante(this.funcionario.Id)).Select(value => (Solicitacao)value).ToList();
                this.bindingSourceSolicitacao.ResetBindings(false);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            Solicitacao sol = (Solicitacao)this.dataGridView1.SelectedRows[0].DataBoundItem;
            sol.Situacao = "Aprovada";
            if (sol.Atualizar()) {
                sol.GetProdutos().ToList().ForEach(value => {
                    value.Key.EstoqueAtual -= value.Value;
                    value.Key.Atualizar();
                });
                MessageBox.Show("Solicitação aprovada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bindingSourceSolicitacao.DataSource = (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER" ? this.solicitacao.ConsultarTodos() : this.solicitacao.GetBySolicitante(this.funcionario.Id)).Select(value => (Solicitacao)value).ToList();
                this.bindingSourceSolicitacao.ResetBindings(false);
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            Solicitacao sol = (Solicitacao)this.dataGridView1.SelectedRows[0].DataBoundItem;
            sol.Situacao = "Rejeitada";
            if (sol.Atualizar()) {
                MessageBox.Show("Solicitação rejeitada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bindingSourceSolicitacao.DataSource = (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER" ? this.solicitacao.ConsultarTodos() : this.solicitacao.GetBySolicitante(this.funcionario.Id)).Select(value => (Solicitacao)value).ToList();
                this.bindingSourceSolicitacao.ResetBindings(false);
            }
        }
    }
}
