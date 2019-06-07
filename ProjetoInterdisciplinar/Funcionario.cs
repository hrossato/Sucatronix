using Isopoh.Cryptography.Argon2;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Funcionario : Model {
        public Funcionario() : base() { }
        public Funcionario(int id) : base(id) { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        private string _senha { get; set; }
        public string Senha { get => _senha; set => _senha = Argon2.Hash(value); }
        public string Tipo { get; set; }
        public override string ToString() => this.Nome;

        public void GetByUsuario() {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@usuario", this.Email));
            using (MySqlDataReader reader = Banco.ExecuteReader("SELECT id, nome, cpf, rg, telefone, dataNascimento, cep, rua, numero, complemento, bairro, senha, tipo FROM Funcionario WHERE email = @usuario", parameters)) {
                if (reader.HasRows) {
                    reader.Read();
                    this.Id = reader.GetInt32("Id");
                    this.Nome = reader.GetString("Nome");
                    this.Cpf = reader.GetString("Cpf");
                    this.Rg = reader.GetString("Rg");
                    this.Telefone = reader.GetString("Telefone");
                    this.DataNascimento = reader.GetDateTime("DataNascimento");
                    this.Cep = reader.GetString("Cep");
                    this.Rua = reader.GetString("Rua");
                    this.Numero = reader.GetString("Numero");
                    this.Complemento = reader.GetString("Complemento");
                    this.Bairro = reader.GetString("Bairro");
                    this._senha = reader.GetString("Senha");
                    this.Tipo = reader.GetString("Tipo");
                } else {
                    this.Email = null;
                }
            }
        }

        public bool Verificar(string usuario, string senha) {
            this.Email = usuario;
            this.GetByUsuario();
            if (this.Email != null) {
                if (Argon2.Verify(this.Senha, senha)) {
                    this.Senha = senha;
                    return true;
                } else {
                    this.Id = 0;
                    this.Nome = null;
                    this.Cpf = null;
                    this.Rg = null;
                    this.Telefone = null;
                    this.DataNascimento = DateTime.Now;
                    this.Cep = null;
                    this.Rua = null;
                    this.Numero = null;
                    this.Complemento = null;
                    this.Bairro = null;
                    this.Email = null;
                    this._senha = null;
                    this.Tipo = null;
                    return false;
                }
            } else {
                return false;
            }
        }
    }
}
