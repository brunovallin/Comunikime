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
    public class VendaPersistence:IVendaPersistencia
    {
        public ContextoDB _context { get; }
        public VendaPersistence(ContextoDB context)
        {
            this._context = context;

        }
        public async Task<Venda[]> GetAllVendasAsync()
        {
            IQueryable<Venda> query = _context.Vendas
                                        .Include(v => v.Cliente)
                                        .Include(v => v.Produtos);

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Venda> GetVendaByIdAsync(int vendaId)
        {
            IQueryable<Venda> query = _context.Vendas
                                        .Include(v => v.Cliente)
                                        .Include(v => v.Produtos);

            query = query.OrderBy(p => p.Id).Where(p => p.Id.Equals(vendaId));

            return await query.FirstOrDefaultAsync();
        }
    }
}