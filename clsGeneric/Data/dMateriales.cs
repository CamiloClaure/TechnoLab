using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Data
{
    public class dMateriales : clsResult, IDisposable
    {
        public clsConnection guConnection;

        public dMateriales()
        {
            guConnection = new clsConnection();
        }

        public MaterialesForm mtdGetMateriales()
        {
            MaterialesForm luResult = null;
            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Get<MaterialesForm>();
                    guConnection.mtdCerrar();
                }
            }
            catch (Exception ex)
            {
                mtdRespError(ex.ToString());
            }
            return luResult;
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
