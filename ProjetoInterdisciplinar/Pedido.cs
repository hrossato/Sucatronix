using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Pedido : Model {
        public Pedido() : base() { }
        public Pedido(int id) : base(id) { }
        public int Id { get; set; }
        public int Funcionario { get; set; }
        public int Fornecedor { get; set; }
        public DateTime Data { get; set; }
        public string Situacao { get; set; }

        public Funcionario GetFuncionario() => new Funcionario(this.Funcionario);
        public Fornecedor GetFornecedor() => new Fornecedor(this.Fornecedor);
        public Dictionary<Produto, double> GetProdutos() {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            Dictionary<Produto, double> produtos = new Dictionary<Produto, double>();
            parameters.Add(new MySqlParameter("@id", this.Id));
            using (MySqlDataReader reader = Banco.ExecuteReader("SELECT produto, quantidade FROM Produto_Pedido WHERE pedido = @id", parameters)) {
                while (reader.Read()) {
                    produtos.Add(new Produto(reader.GetInt32("produto")), reader.GetDouble("quantidade"));
                }
                return produtos;
            }
        }
        public bool SetProdutos(List<KeyValuePair<Produto, double>> produtos) {
            produtos.ForEach(item => {
                List<MySqlParameter> parameters = new List<MySqlParameter> {
                    new MySqlParameter("@pedido", this.Id),
                    new MySqlParameter("@produto", item.Key.Id),
                    new MySqlParameter("@quantidade", item.Value)
                };
                Banco.ExecuteNonQuery("INSERT INTO Produto_Pedido VALUES(@produto, @quantidade, @pedido)", parameters);
            });
            return true;
        }
        public bool ExcluirProdutos() {
            List<MySqlParameter> parameters = new List<MySqlParameter> {
                new MySqlParameter("@pedido", this.Id)
            };
            return Banco.ExecuteNonQuery("DELETE FROM Produto_Pedido WHERE pedido = @pedido", parameters);
        }
    }
}
