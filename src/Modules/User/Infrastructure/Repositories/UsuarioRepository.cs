using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campuslove_Sheyla_Fabio.src.Modules.User.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                                 .AsNoTracking() // mejora performance en consultas de solo lectura
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> SearchAsync(string? nombre, string? carrera, string? intereses)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(u => u.Nombre != null && EF.Functions.Like(u.Nombre, $"%{nombre}%"));

            if (!string.IsNullOrWhiteSpace(carrera))
                query = query.Where(u => u.Carrera != null && EF.Functions.Like(u.Carrera, $"%{carrera}%"));

            if (!string.IsNullOrWhiteSpace(intereses))
                query = query.Where(u => u.Intereses != null && EF.Functions.Like(u.Intereses, $"%{intereses}%"));

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
