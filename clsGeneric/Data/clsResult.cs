using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Data
{
     public class clsResult
    {
        public stcResult prdResult = null;

        public string mtdGetGenericMessage01()
        {
            return "Ocurrió un problema al procesar la información.";
        }
        public string mtdGetMessageToUser()
        {
            if (prdResult.prdResult == stcResult.cnNOK)
            {
                return prdResult.prdMessage;
            }
            if (prdResult.prdResult == stcResult.cnERROR)
            {
                return mtdGetGenericMessage01();
            }
            return null;
        }
        public bool isSuccess()
        {
            bool lbREspuesta = false;
            if (prdResult != null)
            {
                if (prdResult.prdResult == stcResult.cnOK)
                {
                    lbREspuesta = true;
                }
            }
            return lbREspuesta;
        }

        public DateTime mtdGetCurrentDate()
        {
            DateTime luDate = DateTime.Now;
            //   luDate = luDate.AddHours(-4);
            return luDate;
        }


        public void mtdRespOK()
        {
            prdResult = new stcResult(stcResult.cnOK);
            prdResult.prdMessage = "OK";
        }

        public void mtdRespOK(string psMessage)
        {
            prdResult = new stcResult(stcResult.cnOK, psMessage);
        }

        public void mtdRespNOK()
        {
            prdResult = new stcResult(stcResult.cnNOK);
            prdResult.prdMessage = "NOK";
        }

        public void mtdRespNOK(string psMessage)
        {
            prdResult = new stcResult(stcResult.cnNOK, psMessage);
        }

        public void mtdRespError(string psMessage)
        {
            prdResult = new stcResult(stcResult.cnERROR, psMessage);
            throw new Exception(psMessage);
        }

        public static implicit operator clsResult(Task<clsResult> v)
        {
            throw new NotImplementedException();
        }
    }
}
