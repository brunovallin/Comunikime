using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Comunikime.Domain
{
    public class Produto: EntidadeBase
    {
        public string Descricao { get; set; }
        public float PrecoUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Categoria { get; set; }
    }
}