using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Applications.Interfaces
{
    public interface IHistorialService
    {
        Task RegistrarInteraccionAsync(int receptorId, TipoInteraccion tipo);
        Task<IEnumerable<HistorialInteraccion>> VerHistorialAsync(int userId);
    }
}