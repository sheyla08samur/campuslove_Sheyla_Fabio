using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campuslove_Sheyla_Fabio.src.Shared.Configurations
{
    public class HistorialInteraccionConfiguration : IEntityTypeConfiguration<HistorialInteraccion>
    {
        public void Configure(EntityTypeBuilder<HistorialInteraccion> builder)
        {
            builder.ToTable("historialInteraccion");

            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.ReceptorUsuario)
                .WithMany() 
                .HasForeignKey(h => h.ReceptorUsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(h => h.Tipo)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}