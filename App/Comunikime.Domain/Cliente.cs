using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunikime.Domain
{
    public class Cliente:EntidadeBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int VendaId { get; set; }
        public IEnumerable<Venda> Vendas { get; set; }
    }
}