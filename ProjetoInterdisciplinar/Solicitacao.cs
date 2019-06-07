using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Solicitacao : Model {
        public Solicitacao() : base() { }
        public Solicitacao(int id) : base(id) { }
        public int Id { get; set; }
        public int Funcionario { get; set; }
        public DateTime Data { get; set; }
        public string Situacao { get; set; }

        public Funcionario GetFuncionario() => new Funcionario(this.Funcionario);
        public Dictionary<Produto, double> GetProdutos() {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            Dictionary<Produto, double> produtos = new Dictionary<Produto, double>();
            parameters.Add(new MySqlParameter("@id", this.Id));
            using (MySqlDataReader reader = Banco.ExecuteReader("SELECT produto, quantidade FROM Produto_Solicitacao WHERE solicitacao = @id", parameters)) {
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
                Banco.ExecuteNonQuery("INSERT INTO Produto_Solicitacao VALUES(@produto, @quantidade, @pedido)", parameters);
            });
            return true;
        }
        public List<object> GetBySolicitante(int funcionario) =>
            this.ConsultarTodos().FindAll(value => ((Solicitacao)value).Funcionario == funcionario).ToList();
    }
}
