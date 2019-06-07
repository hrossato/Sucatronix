using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoInterdisciplinar
{
    public partial class telaVendas_Orcamentos : Form
    {
        private readonly Funcionario funcionario;
        private readonly Cliente cliente;
        private readonly Produto produto;
        private Venda venda;
        private bool visOnly;
        private List<ItemVenda> listaVenda;
        private BindingSource bindingSourceVenda;
        public telaVendas_Orcamentos(bool visOnly, int funcionario = 0, int venda = 0)
        {
            this.visOnly = visOnly;
            this.funcionario = new Funcionario(funcionario);
            this.cliente = new Cliente();
            this.produto = new Produto();
            if (venda > 0) {
                this.venda = new Venda(venda);
                this.listaVenda = this.venda.GetProdutos().Select(value => new ItemVenda() {
                    Produto = value.Key,
                    Quantidade = value.Value
                }).ToList();
            } else {
                this.listaVenda = new List<ItemVenda>();
            }
            this.bindingSourceVenda = new BindingSource() {
                DataSource = this.listaVenda
            };
            InitializeComponent();
        }

        private void TelaVendas_Orcamentos_Load(object sender, EventArgs e) {
            this.comboBox1.DataSource = this.cliente.ConsultarTodos().Select(value => (Cliente)value).ToList();
            this.comboBox2.DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList();
            this.dataGridView1.DataSource = this.bindingSourceVenda;
            this.tbValorTotal.Text = this.listaVenda.Aggregate(0.0, (acc, curr) => {
                acc += curr.Preco;
                return acc;
            }).ToString();
            if (visOnly) {
                this.comboBox1.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.textBox1.Enabled = false;
                this.button1.Enabled = false;
                this.button3.Enabled = false;
                this.dataGridView1.Enabled = false;
            }
            if (this.venda != null) {
                this.comboBox1.SelectedItem = ((List<Cliente>)this.comboBox1.DataSource).Find(value => value.Id == this.venda.Cliente);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e) {
            if (this.comboBox1.SelectedItem != null && this.textBox1.Text != "") {
                ItemVenda item = new ItemVenda() {
                    Produto = ((Produto)this.comboBox2.SelectedItem),
                    Quantidade = Convert.ToDouble(this.textBox1.Text)
                };
                if (item.Produto != null) {
                    if (this.listaVenda.Find(value => value.Equals(item)) != null) {
                        if (this.listaVenda.Find(value => value.Equals(item)).Quantidade + item.Quantidade <= item.Produto.EstoqueAtual) {
                            this.listaVenda.Find(value => value.Equals(item)).Quantidade += item.Quantidade;
                        } else {
                            if (MessageBox.Show("O pedido já possui a quantidade em estoque deste produto. Você deseja solicitar o restante dos produtos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No)) {
                                if (MessageBox.Show("Deseja remover estes produtos da solicitação?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                                    this.listaVenda.Remove(this.listaVenda.Find(value => value.Equals(item)));
                                }
                            } else {
                                this.listaVenda.Find(value => value.Equals(item)).Quantidade = item.Produto.EstoqueAtual;
                            }
                        }
                    } else {
                        if (item.Quantidade <= item.Produto.EstoqueAtual) {
                            this.listaVenda.Add(item);
                        } else {
                            if (MessageBox.Show("Este produto não possui quantidade suficiente em estoque para satisfazer o pedido. O cliente deseja levar o restante dos produtos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) {
                                item.Quantidade = item.Produto.EstoqueAtual;
                                this.listaVenda.Add(item);
                            }
                        }
                    }
                    this.tbValorTotal.Text = this.listaVenda.Aggregate(0.0, (acc, curr) => {
                        acc += curr.Preco;
                        return acc;
                    }).ToString();
                    this.bindingSourceVenda.ResetBindings(false);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            if (this.venda != null) {
                this.venda.Data = DateTime.Now;
                this.venda.Funcionario = this.funcionario.Id;
                this.venda.Cliente = ((Cliente)this.comboBox1.SelectedItem).Id;
                this.venda.Situacao = "Em Análise";
                this.venda.Atualizar();
                this.venda.ExcluirProdutos();
                this.venda.SetProdutos(this.listaVenda.Select(item => new KeyValuePair<Produto, double>(item.Produto, item.Quantidade)).ToList());
                MessageBox.Show("Orçamento alterado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                this.venda = new Venda() {
                    Data = DateTime.Now,
                    Funcionario = this.funcionario.Id,
                    Cliente = ((Cliente)this.comboBox1.SelectedItem).Id,
                    Situacao = "Em Análise"
                };
                venda.Inserir();
                int id = venda.Id;
                venda.SetProdutos(this.listaVenda.Select(item => new KeyValuePair<Produto, double>(item.Produto, item.Quantidade)).ToList());
                MessageBox.Show("Orçamento realizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
