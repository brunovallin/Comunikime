using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;

namespace Comunikime.Application.Contratos
{
    public interface IProdutoService
    {
        Task<Produto> AddProduto(Produto model);
        Task<Produto> UpdateProduto(int produtoId, Produto model);
        Task<bool> DeleteProduto(int produtoId);

        Task<Produto[]> GetAllProdutosByDescricaoAsync(string descricao);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int ProdutoId);
    }
}