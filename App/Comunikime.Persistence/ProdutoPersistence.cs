using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;
using Comunikime.Persistence.Contexto;
using Comunikime.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Comunikime.Persistence
{
    public class ProdutoPersistence:IProdutoPersistence
    {

        public ContextoDB _context { get; }
        public ProdutoPersistence(ContextoDB context)
        {
            this._context = context;
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Produto> GetProdutoByIdAsync(int ProdutoId)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(p => p.Id.Equals(ProdutoId));

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Produto[]> GetAllProdutosByDescricaoAsync(string descricao)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(p => p.Categoria.ToLower()
                                               .Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}