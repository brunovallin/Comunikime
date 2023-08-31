using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Domain;

namespace Comunikime.Persistence.Contratos
{
    public interface IVendaPersistencia
    {
        Task<Venda[]> GetAllVendasAsync();
        Task<Venda> GetVendaByIdAsync(int vendaId);
    }
}