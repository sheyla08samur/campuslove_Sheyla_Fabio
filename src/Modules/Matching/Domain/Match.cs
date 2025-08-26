using System;
using System.ComponentModel.DataAnnotations.Schema;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities
{
    [Table("matching")]
    public class Match
    {
        public int Id { get; set; }

        // Claves foráneas hacia Usuario
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public Usuario? User1 { get; set; }
        public Usuario? User2 { get; set; }
    }
}
