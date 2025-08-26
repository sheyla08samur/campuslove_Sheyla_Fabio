using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Applications.Interfaces
{
    public interface IHistorialRepository
    {
        Task AddAsync(HistorialInteraccion historial);
        Task<IEnumerable<HistorialInteraccion>> GetByUserIdAsync(int userId);
    }
}