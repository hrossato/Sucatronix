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
    public partial class tela_consultarOrcamentos : Form {
        private Venda venda;
        private Funcionario funcionario;
        private BindingSource bindingSourceVendas;
        public tela_consultarOrcamentos(int funcionario) {
            this.funcionario = new Funcionario(funcionario);
            this.venda = new Venda();
            this.bindingSourceVendas = new BindingSource() {
                DataSource = this.venda.GetOrcamentos()
            };
            InitializeComponent();
        }

        private void Tela_consultarOrcamentos_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceVendas;
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                telaVendas_Orcamentos Outroform = new telaVendas_Orcamentos(false, this.funcionario.Id, ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceVendas.DataSource = this.venda.GetOrcamentos();
                this.bindingSourceVendas.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem).ExcluirProdutos();
            this.venda.Excluir(((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourceVendas.DataSource = this.venda.GetOrcamentos();
            this.bindingSourceVendas.ResetBindings(false);
        }

        private void Button3_Click(object sender, EventArgs e) {
            if (this.funcionario.Tipo == "VENDEDOR" || this.funcionario.Tipo == "SUPERUSER") {
                Venda vendaSelecionada = ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem);
                if (MessageBox.Show("Tem certeza que deseja transformar este orçamento numa venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                    vendaSelecionada.Situacao = "Em Produção";
                    if (vendaSelecionada.Atualizar()) {
                        MessageBox.Show("Venda efetuada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.bindingSourceVendas.DataSource = this.venda.GetOrcamentos();
                    this.bindingSourceVendas.ResetBindings(false);
                }
            }
        }
    }
}
