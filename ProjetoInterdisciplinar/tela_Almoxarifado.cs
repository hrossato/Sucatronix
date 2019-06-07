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
    public partial class tela_Almoxarifado : Form {
        private Funcionario funcionario;
        private Solicitacao solicitacao;
        private readonly Produto produto;
        private List<ItemSolicitacao> listaSolicitacao;
        private BindingSource bindingSourceSolicitacao;
        public tela_Almoxarifado(Funcionario funcionario, int solicitacao = 0) {
            this.produto = new Produto();
            if (solicitacao > 0) {
                this.solicitacao = new Solicitacao(solicitacao);
                this.bindingSourceSolicitacao = new BindingSource() {
                    DataSource = this.solicitacao.GetProdutos().Select(value => new ItemSolicitacao() {
                        Produto = value.Key,
                        Quantidade = value.Value
                    }).ToList()
                };
            } else {
                this.funcionario = funcionario;
                this.listaSolicitacao = new List<ItemSolicitacao>();
                this.bindingSourceSolicitacao = new BindingSource() {
                    DataSource = this.listaSolicitacao
                };
            }
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Button1_Click(object sender, EventArgs e) {
            if (this.comboBox1.SelectedItem != null && this.textBox1.Text != "") {
                ItemSolicitacao item = new ItemSolicitacao() {
                    Produto = ((Produto)this.comboBox1.SelectedItem),
                    Quantidade = Convert.ToDouble(this.textBox1.Text)
                };
                if (item.Produto != null) {
                    if (this.listaSolicitacao.Find(value => value.Equals(item)) != null) {
                        if (this.listaSolicitacao.Find(value => value.Equals(item)).Quantidade + item.Quantidade <= item.Produto.EstoqueAtual) {
                            this.listaSolicitacao.Find(value => value.Equals(item)).Quantidade += item.Quantidade;
                        } else {
                            if (MessageBox.Show("O pedido já possui a quantidade em estoque deste produto. Você deseja solicitar o restante dos produtos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No)) {
                                if (MessageBox.Show("Deseja remover estes produtos da solicitação?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                                    this.listaSolicitacao.Remove(this.listaSolicitacao.Find(value => value.Equals(item)));
                                }
                            } else {
                                this.listaSolicitacao.Find(value => value.Equals(item)).Quantidade = item.Produto.EstoqueAtual;
                            }
                        }
                    } else {
                        if (item.Quantidade <= item.Produto.EstoqueAtual) {
                            this.listaSolicitacao.Add(item);
                        } else {
                            if (MessageBox.Show("Este produto não possui quantidade suficiente em estoque para satisfazer o pedido. O cliente deseja levar o restante dos produtos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                                item.Quantidade = item.Produto.EstoqueAtual;
                                this.listaSolicitacao.Add(item);
                            }
                        }
                    }
                }
                this.bindingSourceSolicitacao.ResetBindings(false);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            Solicitacao solicitacao = new Solicitacao() {
                Data = DateTime.Now,
                Funcionario = this.funcionario.Id,
                Situacao = "Pendente"
            };
            solicitacao.Inserir();
            int id = solicitacao.Id;
            solicitacao.SetProdutos(this.listaSolicitacao.Select(item => new KeyValuePair<Produto, double>(item.Produto, item.Quantidade)).ToList());
            MessageBox.Show("Solicitação realizada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Tela_Almoxarifado_Load(object sender, EventArgs e) {
            this.comboBox1.DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList();
            this.dataGridView1.DataSource = this.bindingSourceSolicitacao;
            if (this.solicitacao != null) {
                this.comboBox1.Enabled = false;
                this.textBox1.Enabled = false;
                this.button1.Enabled = false;
                this.button2.Enabled = false;
            }
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
