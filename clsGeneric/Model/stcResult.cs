using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Model
{
    public class stcResult
    {
        public const int cnOK = 1;
        public const int cnNOK = 0;
        public const int cnERROR = -1;

        public int prdResult { get; set; }

        public string prdMessage { get; set; }

        public stcResult() { }

        public stcResult(int livalue)
        {
            prdResult = livalue;
        }

        public stcResult(int pivalue, string psMessage)
        {
            prdResult = pivalue;
            prdMessage = psMessage;
        }
    }

    public class dtoResult
    {

        public bool BoolValue { get; set; }
        public string prdMensaje { get; set; }
        public string prdToken { get; set; }
        public string prdUsuario { get; set; }
    }
}
