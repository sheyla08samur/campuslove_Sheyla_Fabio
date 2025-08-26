using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Campuslove_Sheyla_Fabio.src.Shared.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            // Primary Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Contrasena)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Edad)
                   .IsRequired();

            builder.Property(u => u.Genero)
                   .HasMaxLength(20);

            builder.Property(u => u.Intereses)
                   .IsRequired()
                   .HasColumnType("TEXT");

            builder.Property(u => u.Carrera)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Frase)
                   .IsRequired()
                   .HasColumnType("TEXT");

            builder.Property(u => u.meGusta)
                   .HasDefaultValue(0);

            builder.Property(u => u.noMeGusta)
                   .HasDefaultValue(0);

            // Índice único en Email
            builder.HasIndex(u => u.Email).IsUnique();

            // Relaciones Likes (Emisor/Receptor)
            builder.HasMany(u => u.LikesGiven)
                   .WithOne(l => l.EmisorUsuario)
                   .HasForeignKey(l => l.EmisorUsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.LikesReceived)
                   .WithOne(l => l.ReceptorUsuario)
                   .HasForeignKey(l => l.ReceptorUsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relaciones Matches
            builder.HasMany(u => u.MatchesAsUser1)
                   .WithOne(m => m.User1)
                   .HasForeignKey(m => m.User1Id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.MatchesAsUser2)
                   .WithOne(m => m.User2)
                   .HasForeignKey(m => m.User2Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
