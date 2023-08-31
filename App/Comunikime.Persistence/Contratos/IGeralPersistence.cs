using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;

namespace Comunikime.Persistence.Contratos
{
    public interface IGeralPersistence
    {
        void Add<T>(T entidade) where T:class;
        void Update<T>(T entidade) where T:class;
        void Delete<T>(T entidade) where T:class;
        void DeleteRange<T>(T entidade) where T:class;

        Task<Boolean> SaveChangesAsync();
    }
}