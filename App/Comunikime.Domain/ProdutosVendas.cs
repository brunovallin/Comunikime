using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunikime.Domain
{
    public class ProdutosVendas
    {
        public int Quantidade { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}