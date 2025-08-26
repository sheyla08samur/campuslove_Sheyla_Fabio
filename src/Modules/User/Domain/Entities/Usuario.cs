using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;




namespace Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public int Edad { get; set; }
        public string? Genero { get; set; }
        public string? Intereses { get; set; }
        public string? Carrera { get; set; }
        public string? Frase { get; set; }
        public int meGusta { get; set; }
        public int noMeGusta { get; set; }

        public ICollection<Like> LikesGiven { get; set; } = new List<Like>();
        public ICollection<Like> LikesReceived { get; set; } = new List<Like>();

        public ICollection<Match> MatchesAsUser1 { get; set; } = new List<Match>();
        public ICollection<Match> MatchesAsUser2 { get; set; } = new List<Match>();




    }
}