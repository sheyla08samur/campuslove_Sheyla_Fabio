using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> GetProfileAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task RegisterAsync(Usuario user)
        {
            // validación rápida de correo único
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("El email es obligatorio.");

            var existing = await _usuarioRepository.GetByEmailAsync(user.Email);
            if (existing != null)
                throw new Exception("El correo ya está registrado");

            await _usuarioRepository.AddAsync(user);
            await _usuarioRepository.SaveChangesAsync();
        }

        public async Task<Usuario?> LoginAsync(string email, string contrasena)
        {
            var user = await _usuarioRepository.GetByEmailAsync(email);
            if (user != null && user.Contrasena == contrasena)
                return user;

            return null;
        }

        public async Task<IEnumerable<Usuario>> SearchAsync(string? nombre = null, string? carrera = null, string? intereses = null)
        {
            return await _usuarioRepository.SearchAsync(nombre, carrera, intereses);
        }
    }
}
