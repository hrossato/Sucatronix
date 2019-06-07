using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Produto : Model {

        public Produto() : base() { }
        public Produto(int id) : base(id) { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double EstoqueAtual { get; set; }
        public double Preco { get; set; }
        public override string ToString() => this.Nome;
    }
}
