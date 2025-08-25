using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraccion.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace campuslove_Sheyla_Fabio.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Constructor que recibe las opciones de configuración
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>(); // DbSet para la entidad User, permite realizar operaciones CRUD sobre la tabla "usuario"
        public DbSet<Like> Likes => Set<Like>(); // DbSet para la entidad Like
        public DbSet<Match> Matches => Set<Match>(); // DbSet para la entidad Match
        public DbSet<HistorialInteraccion> HistorialInteracciones => Set<HistorialInteraccion>(); // DbSet para la entidad HistorialInteraccion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Aplica todas las configuraciones de entidades desde el ensamblado actual
        }
    }
}
