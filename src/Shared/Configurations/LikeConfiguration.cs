using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campuslove_Sheyla_Fabio.src.Shared.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("likings");

            builder.HasKey(l => l.Id);

            // Relación EmisorUsuario (un Usuario puede dar muchos likes)
            builder.HasOne<Usuario>(l => l.EmisorUsuario)
                   .WithMany()
                   .HasForeignKey(l => l.EmisorUsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación ReceptorUsuario (un Usuario puede recibir muchos likes)
            builder.HasOne<Usuario>(l => l.ReceptorUsuario)
                   .WithMany()
                   .HasForeignKey(l => l.ReceptorUsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Campos obligatorios
            builder.Property(l => l.EmisorUsuarioId).IsRequired();
            builder.Property(l => l.ReceptorUsuarioId).IsRequired();
            builder.Property(l => l.Fecha)
                   .IsRequired();
        }
    }
}
