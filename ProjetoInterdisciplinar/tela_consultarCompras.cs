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
    public partial class tela_consultarCompras : Form {
        private Pedido pedido;
        private Funcionario funcionario;
        private BindingSource bindingSourcePedidos;
        public tela_consultarCompras(int funcionario = 0) {
            this.pedido = new Pedido();
            this.funcionario = new Funcionario(funcionario);
            this.bindingSourcePedidos = new BindingSource() {
                DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList()
        };
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e) {
            ((Pedido)this.dataGridView1.SelectedRows[0].DataBoundItem).ExcluirProdutos();
            this.pedido.Excluir(((Pedido)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
            this.bindingSourcePedidos.DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList();
            this.bindingSourcePedidos.ResetBindings(false);
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Tela_consultarCompras_Load(object sender, EventArgs e) {
            this.dataGridView1.DataSource = this.bindingSourcePedidos;
        }

        private void Button1_Click(object sender, EventArgs e) {
            Pedido pedidoSelecionado = ((Pedido)this.dataGridView1.SelectedRows[0].DataBoundItem);
            switch (pedidoSelecionado.Situacao) {
                case "Pendente":
                    if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta compra já foi realizada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            pedidoSelecionado.Situacao = "Realizada";
                            if (pedidoSelecionado.Atualizar()) {
                                MessageBox.Show("Situação da compra alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourcePedidos.DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList();
                            this.bindingSourcePedidos.ResetBindings(false);
                        }
                    }
                    break;
                case "Realizada":
                    if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta compra já foi enviada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            pedidoSelecionado.Situacao = "Enviada";
                            if (pedidoSelecionado.Atualizar()) {
                                MessageBox.Show("Situação da compra alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourcePedidos.DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList();
                            this.bindingSourcePedidos.ResetBindings(false);
                        }
                    }
                    break;
                case "Enviada":
                    if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
                        if (MessageBox.Show("Tem certeza que deseja indicar que esta compra já foi recebida?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                            pedidoSelecionado.Situacao = "Recebida";
                            if (pedidoSelecionado.Atualizar()) {
                                pedidoSelecionado.GetProdutos().ToList().ForEach(value => {
                                    value.Key.EstoqueAtual += value.Value;
                                    value.Key.Atualizar();
                                });
                                MessageBox.Show("Situação da compra alterada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.bindingSourcePedidos.DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList();
                            this.bindingSourcePedidos.ResetBindings(false);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count > 0) {
                telaEntrada_de_produtos Outroform = new telaEntrada_de_produtos(true, 0, ((Pedido)this.dataGridView1.SelectedRows[0].DataBoundItem).Id);
                Outroform.ShowDialog();
                Outroform.Activate();
                this.bindingSourcePedidos.DataSource = this.pedido.ConsultarTodos().Select(value => (Pedido)value).ToList();
                this.bindingSourcePedidos.ResetBindings(false);
            }
        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged == DataGridViewElementStates.Selected) {
                if (this.dataGridView1.SelectedRows.Count > 0) {
                    Pedido pedidoSelecionado = ((Pedido)this.dataGridView1.SelectedRows[0].DataBoundItem);
                    switch (pedidoSelecionado.Situacao) {
                        case "Pendente":
                            if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
                                this.button1.Text = "Alterar situação para 'Realizada'";
                                this.button1.Enabled = true;
                            } else {
                                this.button1.Text = "Avançar";
                                this.button1.Enabled = false;
                            }
                            break;
                        case "Realizada":
                            if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
                                this.button1.Text = "Alterar situação para 'Enviada'";
                                this.button1.Enabled = true;
                            } else {
                                this.button1.Text = "Avançar";
                                this.button1.Enabled = false;
                            }
                            break;
                        case "Enviada":
                            if (this.funcionario.Tipo == "ALMOXARIFE" || this.funcionario.Tipo == "SUPERUSER") {
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
