using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunikime.Domain
{
    public class Venda:EntidadeBase
    {
        public int CodigoVenda { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ProdutosVendas> Produtos { get; set; }
        public float ValorTotal { get; set; }
    }
}