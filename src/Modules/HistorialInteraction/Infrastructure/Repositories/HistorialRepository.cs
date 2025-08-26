using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Infrastructure.Repositories
{
    public class HistorialRepository : IHistorialRepository
    {
        private readonly AppDbContext _context;

        public HistorialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HistorialInteraccion historial)
        {
            _context.HistorialInteracciones.Add(historial);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistorialInteraccion>> GetByUserIdAsync(int userId)
        {
            return await _context.HistorialInteracciones
                .Where(h => h.ReceptorUsuarioId == userId)
                .Include(h => h.ReceptorUsuario)
                .ToListAsync();
        }
    }
}