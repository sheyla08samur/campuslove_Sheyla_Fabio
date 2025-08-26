using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;

namespace Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> LoginAsync(string email, string contrasena)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Contrasena == contrasena);
        }

        public async Task RegisterAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> SearchAsync(string? nombre = null, string? carrera = null, string? intereses = null)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(u => u.Nombre != null && u.Nombre.Contains(nombre));

            if (!string.IsNullOrWhiteSpace(carrera))
                query = query.Where(u => u.Carrera != null && u.Carrera.Contains(carrera));

            if (!string.IsNullOrWhiteSpace(intereses))
                query = query.Where(u => u.Intereses != null && u.Intereses.Contains(intereses));

            return await query.ToListAsync();
        }

        public async Task<int> GetLikesReceivedAsync(int userId)
        {
            return await _context.Likes
                .CountAsync(l => l.ReceptorUsuarioId == userId && l.IsLike);
        }

        public async Task<int> GetDislikesReceivedAsync(int userId)
        {
            return await _context.Likes
                .CountAsync(l => l.ReceptorUsuarioId == userId && !l.IsLike);
        }

        public async Task<int> GetMatchesAsync(int userId)
        {
            return await _context.Matches
                .CountAsync(m => m.User1Id == userId || m.User2Id == userId);
        }
        public async Task<Usuario?> GetProfileAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
