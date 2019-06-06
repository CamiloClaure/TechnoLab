using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [ExplicitKey]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Privilegios { get; set; }
    }
}
