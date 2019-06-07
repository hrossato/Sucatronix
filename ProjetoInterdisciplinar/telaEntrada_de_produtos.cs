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
    public partial class telaEntrada_de_produtos : Form
    {
        private readonly Funcionario funcionario;
        private readonly Fornecedor fornecedor;
        private Pedido pedido;
        private readonly Produto produto;
        private bool visOnly;
        private List<ItemVenda> listaPedido;
        private BindingSource bindingSourceVenda;
        public telaEntrada_de_produtos(bool visOnly, int funcionario = 0, int pedido = 0)
        {
            this.visOnly = visOnly;
            this.funcionario = new Funcionario(funcionario);
            this.fornecedor = new Fornecedor();
            this.produto = new Produto();
            if (pedido > 0) {
                this.pedido = new Pedido(pedido);
                this.listaPedido = this.pedido.GetProdutos().Select(value => new ItemVenda() {
                    Produto = value.Key,
                    Quantidade = value.Value
                }).ToList();
            } else {
                this.listaPedido = new List<ItemVenda>();
            }
            this.bindingSourceVenda = new BindingSource() {
                DataSource = this.listaPedido
            };
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void TelaEntrada_de_produtos_Load(object sender, EventArgs e) {
            this.comboBox1.DataSource = this.fornecedor.ConsultarTodos().Select(value => (Fornecedor)value).ToList();
            this.comboBox2.DataSource = this.produto.ConsultarTodos().Select(value => (Produto)value).ToList();
            this.dataGridView1.DataSource = this.bindingSourceVenda;
            this.tbValorTotal.Text = this.listaPedido.Aggregate(0.0, (acc, curr) => {
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
        }

        private void Button1_Click(object sender, EventArgs e) {
            if (this.comboBox1.SelectedItem != null && this.textBox1.Text != "") {
                ItemVenda item = new ItemVenda() {
                    Produto = ((Produto)this.comboBox2.SelectedItem),
                    Quantidade = Convert.ToDouble(this.textBox1.Text)
                };
                if (item.Produto != null) {
                    if (this.listaPedido.Find(value => value.Equals(item)) != null) {
                        this.listaPedido.Find(value => value.Equals(item)).Quantidade += item.Quantidade;
                    } else {
                        this.listaPedido.Add(item);
                    }
                    this.tbValorTotal.Text = this.listaPedido.Aggregate(0.0, (acc, curr) => {
                        acc += curr.Preco;
                        return acc;
                    }).ToString();
                }
                this.bindingSourceVenda.ResetBindings(false);
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            Pedido pedido = new Pedido() {
                Data = DateTime.Now,
                Funcionario = this.funcionario.Id,
                Fornecedor = ((Fornecedor)this.comboBox1.SelectedItem).Id,
                Situacao = "Pendente"
            };
            pedido.Inserir();
            int id = pedido.Id;
            pedido.SetProdutos(this.listaPedido.Select(item => new KeyValuePair<Produto, double>(item.Produto, item.Quantidade)).ToList());
            MessageBox.Show("Pedido realizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
