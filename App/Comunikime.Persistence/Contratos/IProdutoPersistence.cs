using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;

namespace Comunikime.Persistence.Contratos
{
    public interface IProdutoPersistence
    {
        Task<Produto[]> GetAllProdutosByDescricaoAsync(string descricao);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int produtoId);
    }
}