using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    class ItemSolicitacao {
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }

        public override bool Equals(object obj) =>
            (obj.GetType() == this.GetType()) &&
                ((ItemSolicitacao)obj).Produto.Id == this.Produto.Id;

        public override int GetHashCode() {
            var hashCode = -855833831;
            hashCode = hashCode * -1521134295 + EqualityComparer<Produto>.Default.GetHashCode(this.Produto);
            hashCode = hashCode * -1521134295 + this.Quantidade.GetHashCode();
            return hashCode;
        }
    }
}
