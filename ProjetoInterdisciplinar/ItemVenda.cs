using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    class ItemVenda {
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get => this.Produto.Preco * this.Quantidade; }

        public override bool Equals(object obj) =>
            (obj.GetType() == this.GetType()) &&
                ((ItemVenda)obj).Produto.Id == this.Produto.Id;

        public override int GetHashCode() {
            var hashCode = -855833831;
            hashCode = hashCode * -1521134295 + EqualityComparer<Produto>.Default.GetHashCode(this.Produto);
            hashCode = hashCode * -1521134295 + this.Quantidade.GetHashCode();
            return hashCode;
        }
    }
}
