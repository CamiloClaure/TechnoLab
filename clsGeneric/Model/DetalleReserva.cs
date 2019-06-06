using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    [Table("detallereserva")]
    public class DetalleReserva
    {
        [Key]
        public int IdDetalle { get; set; }
        public int CodReserva { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
        public int IdReserva { get; set; }
    }
}
