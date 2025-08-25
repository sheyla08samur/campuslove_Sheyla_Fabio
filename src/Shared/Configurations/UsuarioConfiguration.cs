using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campuslove_Sheyla_Fabio.src.Shared.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario"); // Configura el nombre de la tabla en la base de datos

            builder.HasKey(u => u.Id);

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

            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}