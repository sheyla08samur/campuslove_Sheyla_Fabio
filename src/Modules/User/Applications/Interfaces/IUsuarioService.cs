using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces
{
    public interface IUsuarioService
    {
        Task RegisterAsync(Usuario user);
        Task<Usuario?> LoginAsync(string email, string contrasena);
        Task<IEnumerable<Usuario>> SearchAsync(string? nombre = null, string? carrera = null, string? intereses = null);

        Task<int> GetLikesReceivedAsync(int userId);
        Task<int> GetLikesReceivedAsync(Usuario usuario);
        Task<int> GetDislikesReceivedAsync(int userId);
        Task<int> GetMatchesAsync(int userId);
        Task<Usuario?> GetProfileAsync(int id);
        Task DarLikeAsync(int emisorId, int receptorId, bool esLike);

    }
}
