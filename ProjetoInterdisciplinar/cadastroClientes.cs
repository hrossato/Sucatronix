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
    public partial class cadastroClientes : Form
    {
        private Cliente cliente;
        public cadastroClientes(int cliente = 0)
        {
            this.cliente = new Cliente(cliente);
            InitializeComponent();
        }

        private void CadastroClientes_Load(object sender, EventArgs e)
        {
            if (this.cliente.Id > 0) {
                this.tbNomeCliente.Text = this.cliente.Nome;
                this.tbEmailCliente.Text = this.cliente.Email;
                this.tbTelefoneCliente.Text = this.cliente.Telefone;
                this.tbEnderecoCliente.Text = this.cliente.Rua;
                this.tbNumeroCliente.Text = this.cliente.Numero;
                this.tbBairroCliente.Text = this.cliente.Bairro;
                this.tbCepCliente.Text = this.cliente.Cep;
                this.tbObservacoesCliente.Text = this.cliente.Complemento;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) {
            this.cliente.Nome = this.tbNomeCliente.Text;
            this.cliente.Email = this.tbEmailCliente.Text;
            this.cliente.Telefone = this.tbTelefoneCliente.Text;
            this.cliente.Rua = this.tbEnderecoCliente.Text;
            this.cliente.Numero = this.tbNumeroCliente.Text;
            this.cliente.Bairro = this.tbBairroCliente.Text;
            this.cliente.Cep = this.tbCepCliente.Text;
            this.cliente.Complemento = this.tbObservacoesCliente.Text;
            if (this.cliente.Id > 0) {
                if (this.cliente.Atualizar()) {
                    MessageBox.Show("Cliente atualizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                if (this.cliente.Inserir()) {
                    MessageBox.Show("Cliente criado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
