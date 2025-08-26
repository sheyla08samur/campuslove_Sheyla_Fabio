using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Applications.Service
{
    public class HistorialService : IHistorialService
    {
        private readonly IHistorialRepository _repository;

        public HistorialService(IHistorialRepository repository)
        {
            _repository = repository;
        }

        public async Task RegistrarInteraccionAsync(int receptorId, TipoInteraccion tipo)
        {
            var historial = new HistorialInteraccion
            {
                ReceptorUsuarioId = receptorId,
                Tipo = tipo
            };

            await _repository.AddAsync(historial);
        }

        public async Task<IEnumerable<HistorialInteraccion>> VerHistorialAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }
    }
}