using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    [Table("reserva")]
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string IdEstudiante { get; set; }
        public int CodReserva { get; set; }
        public int IdMateria { get; set; }
        public string Estado { get; set; }
    }
}
