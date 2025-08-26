using System;
using System.ComponentModel.DataAnnotations.Schema;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities
{
    [Table("likings")]
    public class Like
    {
        public int Id { get; set; }

        // Usuario que da el like
        public int EmisorUsuarioId { get; set; }
        public Usuario? EmisorUsuario { get; set; }

        // Usuario que recibe el like
        public int ReceptorUsuarioId { get; set; }
        public Usuario? ReceptorUsuario { get; set; }

        // True = Like 👍 | False = Dislike 👎
        public bool IsLike { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
