using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Usuario.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraccion.Domain.Entities
{
    [Table("historialInteraccion")]
    public class HistorialInteraccion
    {
        public int Id { get; set; }
        public int ReceptorUsuarioId { get; set; }

        public Campuslove_Sheyla_Fabio.src.Modules.Usuario.Domain.Entities.Usuario? ReceptorUsuario { get; set; }
        public TipoInteraccion Tipo { get; set; }
    }
}