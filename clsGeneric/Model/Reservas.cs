using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    [Table("Reserva")]
    public class Reservas
    {
        [Key]
        public int IdReserva { get; set; }
        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }

        public string IdEstudiante { get; set; }
         
        public string IdEncargado { get; set; }
        public int CodReserva { get; set; }
        public int IdMateria { get; set; }
        [Computed]
        public string MateriaDesc { get; set; }
    }
}
