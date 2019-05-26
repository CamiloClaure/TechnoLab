using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
namespace clsGeneric.Model
{
    [Table("MaterialesForm")]
    public class MaterialesForm
    {
        [Key]
        public int idMaterial { get; set; }
        public string nombre { get; set; }
        public DateTime fechaCompra { get; set; }
        public bool estado { get; set; }
    }
}
