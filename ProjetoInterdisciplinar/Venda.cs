using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Venda : Model {
        public Venda() : base() { }
        public Venda(int id) : base(id) { }
        public int Id { get; set; }
        public int Cliente { get; set; }
        public DateTime Data { get; set; }
        public int Funcionario { get; set; }
        public string Situacao { get; set; }

        public Funcionario GetFuncionario() => new Funcionario(this.Funcionario);
        public Cliente GetCliente() => new Cliente(this.Cliente);
        public Dictionary<Produto, double> GetProdutos() {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            Dictionary<Produto, double> produtos = new Dictionary<Produto, double>();
            parameters.Add(new MySqlParameter("@id", this.Id));
            using (MySqlDataReader reader = Banco.ExecuteReader("SELECT produto, quantidade FROM Produto_Venda WHERE venda = @id", parameters)) {
                while (reader.Read()) {
                    produtos.Add(new Produto(reader.GetInt32("produto")), reader.GetDouble("quantidade"));
                }
                return produtos;
            }
        }
        public bool SetProdutos(List<KeyValuePair<Produto, double>> produtos) {
            produtos.ForEach(item => {
                List<MySqlParameter> parameters = new List<MySqlParameter> {
                    new MySqlParameter("@venda", this.Id),
                    new MySqlParameter("@produto", item.Key.Id),
                    new MySqlParameter("@quantidade", item.Value)
                };
                Banco.ExecuteNonQuery("INSERT INTO Produto_Venda VALUES(@produto, @quantidade, @venda)", parameters);
            });
            return true;
        }
        public bool ExcluirProdutos() {
            List<MySqlParameter> parameters = new List<MySqlParameter> {
                new MySqlParameter("@venda", this.Id)
            };
            return Banco.ExecuteNonQuery("DELETE FROM Produto_Venda WHERE venda = @venda", parameters);
        }
        public List<Venda> GetOrcamentos() => this.ConsultarTodos().FindAll(value => ((Venda)value).Situacao == "Em Análise").Select(value => (Venda)value).ToList();
        public List<Venda> GetVendas() => this.ConsultarTodos().FindAll(value => ((Venda) value).Situacao != "Em Análise").Select(value => (Venda) value).ToList();
    }
}
