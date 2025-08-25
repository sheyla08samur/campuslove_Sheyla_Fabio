using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Campuslove_Sheyla_Fabio.src.Modules.Usuario.Domain.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Constrasena { get; set; }
        public int Edad { get; set; }
        public string? Genero { get; set; }
        public string? Intereses { get; set; }
        public string? Carrera { get; set; }
        public string? Frase { get; set; }
        public int meGusta { get; set; }
        public int noMeGusta { get; set; }
    }
}