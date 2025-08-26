using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.HistorialInteraction.Domain.Entities
{
    [Table("historialInteraccion")]
    public class HistorialInteraccion
    {
        public int Id { get; set; }
        public int ReceptorUsuarioId { get; set; }

        public Usuario? ReceptorUsuario { get; set; }
        public TipoInteraccion Tipo { get; set; }
    }
}