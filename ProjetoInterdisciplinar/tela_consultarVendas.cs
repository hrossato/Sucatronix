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
    public partial class tela_consultarVendas : Form {
        private Venda venda;
        private Funcionario funcionario;
        private BindingSource bindingSourceVendas;
        public tela_consultarVendas(int funcionario) {
            this.funcionario = new Funcionario(funcionario);
            this.venda = new Venda();
            this.bindingSourceVendas = new BindingSource() {
                DataSource = this.venda.GetVendas()
            };
            InitializeComponent();
        }

        private void Tela_consultarVendas_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourceVendas;
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                telaVendas_Orcamentos Outroform = new telaVendas_Orcamentos(true, this.funcionario.Id, ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourceVendas.DataSource = this.venda.GetVendas();
                this.bindingSourceVendas.ResetBindings(false);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            Venda vendaSelecionada = ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem);
            switch (vendaSelecionada.Situacao) {
                case "Em Produção":
                    if (this.funcionario.Tipo == "TÉCNICO" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta venda já está pronta para envio?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            vendaSelecionada.Situacao = "Pronta para envio";
                            if (vendaSelecionada.Atualizar()) {
                                MessageBox.Show("Situação da venda alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourceVendas.DataSource = this.venda.GetVendas();
                            this.bindingSourceVendas.ResetBindings(false);
                        }
                    }
                    break;
                case "Pronta para envio":
                    if (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta venda já foi enviada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            vendaSelecionada.Situacao = "Enviada";
                            if (vendaSelecionada.Atualizar()) {
                                vendaSelecionada.GetProdutos().ToList().ForEach(value => {
                                    value.Key.EstoqueAtual -= value.Value;
                                    value.Key.Atualizar();
                                });
                                MessageBox.Show("Situação da venda alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourceVendas.DataSource = this.venda.GetVendas();
                            this.bindingSourceVendas.ResetBindings(false);
                        }
                    }
                    break;
                case "Enviada":
                    if (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta venda já foi entregue?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            vendaSelecionada.Situacao = "Entregue";
                            if (vendaSelecionada.Atualizar()) {
                                MessageBox.Show("Situação da venda alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourceVendas.DataSource = this.venda.GetVendas();
                            this.bindingSourceVendas.ResetBindings(false);
                        }
                    }
                    break;
                default:
                    break;
            }
            this.DataGridView1_CellContentClick(this, null);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged == DataGridViewElementStates.Selected) {
                if (this.dataGridView1.SelectedRows.Count > 0) {
                    Venda vendaSelecionada = ((Venda)this.dataGridView1.SelectedRows[0].DataBoundItem);
                    switch (vendaSelecionada.Situacao) {
                        case "Em Produção":
                            if (this.funcionario.Tipo == "TÉCNICO" || this.funcionario.Tipo == "SUPERUSER") {
                                this.button1.Text = "Alterar situação para 'Pronta para envio'";
                                this.button1.Enabled = true;
                            } else {
                                this.button1.Text = "Avançar";
                                this.button1.Enabled = false;
                            }
                            break;
                        case "Pronta para envio":
                            if (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER") {
                                this.button1.Text = "Alterar situação para 'Enviada'";
                                this.button1.Enabled = true;
                            } else {
                                this.button1.Text = "Avançar";
                                this.button1.Enabled = false;
                            }
                            break;
                        case "Enviada":
                            if (this.funcionario.Tipo == "ALMOXARIFADO" || this.funcionario.Tipo == "SUPERUSER") {
                                this.button1.Text = "Alterar situação para 'Entregue'";
                                this.button1.Enabled = true;
                            } else {
                                this.button1.Text = "Avançar";
                                this.button1.Enabled = false;
                            }
                            break;
                        default:
                            this.button1.Text = "Avançar";
                            this.button1.Enabled = false;
                            break;
                    }
                }
            }
        }
    }
}
