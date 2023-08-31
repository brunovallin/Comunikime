using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Persistence.Contexto;
using Comunikime.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Comunikime.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        public ContextoDB _context { get; }
        public GeralPersistence(ContextoDB context)
        {
            this._context = context;

        }
        public void Add<T>(T entidade) where T : class
        {
            _context.Add(entidade);
        }

        public void Update<T>(T entidade) where T : class
        {
            _context.Update(entidade);
        }

        public void Delete<T>(T entidade) where T : class
        {
            _context.Remove(entidade);
        }

        public void DeleteRange<T>(T entidadeLista) where T : class
        {
            _context.RemoveRange(entidadeLista);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}