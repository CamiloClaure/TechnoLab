using clsGeneric.Model;
using Dapper;
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
        int tmp = 0;

        public dMateriales()
        {
            this.guConnection = new clsConnection(); 
        }

        public dMateriales(int t)
        {
            this.tmp = t;
            guConnection = new clsConnection();
        }

        public List<materialesform> mtdGetMateriales()
        {
            try
            {

                List<materialesform> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<materialesform>(@"Select * from materialesform").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
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
