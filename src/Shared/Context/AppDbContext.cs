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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Aplica todas las configuraciones de entidades desde el ensamblado actual
        }
    }
}
