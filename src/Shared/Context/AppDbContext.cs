using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace campuslove_Sheyla_Fabio.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Constructor que recibe las opciones de configuración
        {
        }

        //public DbSet<Usuario> Usuarios => Set<Usuario>(); // DbSet para la entidad User, permite realizar operaciones CRUD sobre la tabla "usuario"
        //public DbSet<historialInteraccion> historialInteracciones => Set<historialInteraccion>(); // DbSet para la entidad historialInteraccion, permite realizar operaciones sobre la tabla "historialInteraccion"
        //public DbSet<matching> matchings => Set<matching>();// DbSet para la entidad matching, permite realizar operaciones sobre la tabla "matching"        protected override void OnModelCreating(ModelBuilder modelBuilder)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Aplica todas las configuraciones de entidades desde el ensamblado actual
        }
    }
}
