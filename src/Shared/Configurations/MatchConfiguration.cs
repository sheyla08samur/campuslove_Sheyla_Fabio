using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Infrastructure.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("match");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relación con User1 (Match.User1 ↔ Usuario.MatchesAsUser1)
            builder.HasOne(m => m.User1)
                   .WithMany(u => u.MatchesAsUser1)
                   .HasForeignKey(m => m.User1Id)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con User2 (Match.User2 ↔ Usuario.MatchesAsUser2)
            builder.HasOne(m => m.User2)
                   .WithMany(u => u.MatchesAsUser2)
                   .HasForeignKey(m => m.User2Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
