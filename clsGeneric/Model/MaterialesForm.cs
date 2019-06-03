using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
namespace clsGeneric.Model
{
    [Table("materialesform")]
    public class materialesform
    {
        [Key]
        public int idMaterial { get; set; }
        public string nombre { get; set; }
        public DateTime fechaCompra { get; set; }
        public string estado { get; set; }
        public int Cantidad { get; set; }
        public string Ubicacion { get; set; }
    }
}
