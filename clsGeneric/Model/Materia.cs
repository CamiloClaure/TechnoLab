using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    [Table("Materia")]
    public class Materia
    {
        [Key]
        public int IdMateria { get; set; }
        public string Docente { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFin { get; set; }
        public string Nombre { get; set; }
}
}
