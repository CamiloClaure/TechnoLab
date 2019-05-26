using clsGeneric.Data;
using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Controller
{
    public class ctrlMateriales : clsResult, IDisposable
    {
        public MaterialesForm mtdGetMateriales()
        {
            try
            {
                MaterialesForm luResult = null;

                using (dMateriales luData = new dMateriales())
                {
                    luResult = luData.mtdGetCliente();
                }
                mtdRespOK();
                return luResult;
            }
            catch (Exception ex)
            {
                mtdRespError(ex.ToString());
                return null;
            }
        }

        #region IDisposable Support
        // some fields that require cleanup
        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose unmanaged managed resources.
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
