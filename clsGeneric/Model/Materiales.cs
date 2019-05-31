using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
namespace clsGeneric.Model
{
    [Table("materialesform")]
    public class Materiales
    {
        [Key]
        public int Codigo { get; set; }
        public string CodMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }
        public int CodCategoria { get; set; }
    }
}
