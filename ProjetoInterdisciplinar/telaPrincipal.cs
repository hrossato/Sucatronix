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
    public partial class telaPrincipal : Form
    {
        private readonly Funcionario funcionario;
        public telaPrincipal(Funcionario funcionario)
        {
            this.funcionario = funcionario;
            InitializeComponent();

        }
        
       
        private void ArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void VendasEOrçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            switch (this.funcionario.Tipo) {
                case "ALMOXARIFADO":
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem7.Visible = true;
                    toolStripMenuItem9.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem3.Visible = true;
                    produtosToolStripMenuItem.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    estoqueToolStripMenuItem.Visible = true;
                    entradaDeProdutosToolStripMenuItem.Visible = true;
                    consultarPedidosToolStripMenuItem.Visible = true;
                    break;
                case "TÉCNICO":
                    toolStripMenuItem1.Visible = true;
                    produtosToolStripMenuItem.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    estoqueToolStripMenuItem.Visible = true;
                    entradaDeProdutosToolStripMenuItem.Visible = true;
                    consultarPedidosToolStripMenuItem.Visible = true;
                    solicitarProdutoToolStripMenuItem.Visible = true;
                    consultarSolicitaçõesDeProdutoToolStripMenuItem.Visible = true;
                    break;
                case "GESTOR":
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem8.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    break;
                case "VENDEDOR":
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem6.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    break;
                case "ADMINISTRADOR":
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem8.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    break;
                case "SUPERUSER":
                    toolStripMenuItem2.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem7.Visible = true;
                    toolStripMenuItem9.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem3.Visible = true;
                    produtosToolStripMenuItem.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    estoqueToolStripMenuItem.Visible = true;
                    entradaDeProdutosToolStripMenuItem.Visible = true;
                    consultarPedidosToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    produtosToolStripMenuItem.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    estoqueToolStripMenuItem.Visible = true;
                    entradaDeProdutosToolStripMenuItem.Visible = true;
                    consultarPedidosToolStripMenuItem.Visible = true;
                    solicitarProdutoToolStripMenuItem.Visible = true;
                    consultarSolicitaçõesDeProdutoToolStripMenuItem.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem8.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem6.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem7.Visible = true;
                    toolStripMenuItem9.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem3.Visible = true;
                    produtosToolStripMenuItem.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    estoqueToolStripMenuItem.Visible = true;
                    entradaDeProdutosToolStripMenuItem.Visible = true;
                    consultarPedidosToolStripMenuItem.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem8.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    vendasEOrçamentosToolStripMenuItem.Visible = true;
                    vendasToolStripMenuItem.Visible = true;
                    consultarOrçamentosToolStripMenuItem.Visible = true;
                    consultarVendasToolStripMenuItem.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroClientes Outroform = new cadastroClientes();
            Outroform.ShowDialog();
            Outroform.Activate();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroFornecedor Outroform = new cadastroFornecedor();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e) {
            cadastroFuncionarios Outroform = new cadastroFuncionarios();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void VendasToolStripMenuItem_Click(object sender, EventArgs e) {
            telaVendas_Orcamentos Outroform = new telaVendas_Orcamentos(false, this.funcionario.Id);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void EntradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e) {
            telaEntrada_de_produtos Outroform = new telaEntrada_de_produtos(false, this.funcionario.Id);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void SaídaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e) {
            // Criar saída de produtos
        }

        private void SolicitarProdutoToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_Almoxarifado Outroform = new tela_Almoxarifado(this.funcionario);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ConsultarSolicitaçõesDeProdutoToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_consultarAlmoxarifado Outroform = new tela_consultarAlmoxarifado(this.funcionario);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e) {
            cadastroClientes Outroform = new cadastroClientes();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e) {
            cadastroFornecedor Outroform = new cadastroFornecedor();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e) {
            cadastroFuncionarios Outroform = new cadastroFuncionarios();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e) {
            cadastroProdutos Outroform = new cadastroProdutos();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e) {
            tela_consultarFornecedores Outroform = new tela_consultarFornecedores();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e) {
            tela_consultarClientes Outroform = new tela_consultarClientes();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_consultarProdutos Outroform = new tela_consultarProdutos();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e) {
            tela_consultarFuncionarios Outroform = new tela_consultarFuncionarios();
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ConsultarOrçamentosToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_consultarOrcamentos Outroform = new tela_consultarOrcamentos(this.funcionario.Id);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ConsultarVendasToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_consultarVendas Outroform = new tela_consultarVendas(this.funcionario.Id);
            Outroform.ShowDialog();
            Outroform.Activate();
        }

        private void ConsultarPedidosToolStripMenuItem_Click(object sender, EventArgs e) {
            tela_consultarCompras Outroform = new tela_consultarCompras();
            Outroform.ShowDialog();
            Outroform.Activate();
        }
    }
}
