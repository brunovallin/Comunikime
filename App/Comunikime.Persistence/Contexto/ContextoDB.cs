using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;
using Microsoft.EntityFrameworkCore;

namespace Comunikime.Persistence.Contexto
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutosVendas> ProdutosVendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutosVendas>()
                        .HasKey(PV => new {PV.ProdutoId, PV.VendaId});
        }
    }
}