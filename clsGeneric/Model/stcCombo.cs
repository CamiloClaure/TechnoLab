using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    public partial class stcCombo
    {
        public int prdId { get; set; }
        public string prdDescripcion { get; set; }

        public stcCombo() { }
        public stcCombo(int piId, string psDescripcion)
        {
            prdId = piId;
            prdDescripcion = psDescripcion;
        }
    }

    public partial class stcComboAtr
    {
        public int prdId { get; set; }
        public string prdDescripcion { get; set; }
        public string prdAtributo { get; set; }
        public string prdAtributo2 { get; set; }
        public stcComboAtr() { }
        public stcComboAtr(int piId, string psDescripcion, string psAtributo)
        {
            prdId = piId;
            prdDescripcion = psDescripcion;
            prdAtributo = psAtributo;
        }
    }

    public partial class stcComboS
    {
        public string prdId { get; set; }
        public string prdDesc { get; set; }
        public string prdDescripcion { get; set; }

        public decimal prdCandidad { get; set; }

        public string prdNombre { get; set; }
        public string prdExtension { get; set; }
        public stcComboS() { }
        public stcComboS(string piId, string psDescripcion)
        {
            prdId = piId;
            prdDesc = psDescripcion;
            prdDescripcion = psDescripcion;
        }


    }
}
