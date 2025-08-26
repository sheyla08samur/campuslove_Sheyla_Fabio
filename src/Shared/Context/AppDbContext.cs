using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campuslove_Sheyla_Fabio.src.Shared.Context // ✅ corregido el namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<HistorialInteraccion> HistorialInteracciones => Set<HistorialInteraccion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
