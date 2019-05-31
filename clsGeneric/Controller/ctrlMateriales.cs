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
        public List<materialesform> mtdGetMateriales()
        {
            try
            {
                List<materialesform> luResult = null;
                dMateriales luDato = new dMateriales(4);
                using (luDato)
                {
                    luResult = luDato.mtdGetMateriales();
                }

                return luResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void MtdGuardarMaterial(materialesform newTipo)
        {
            try
            {
                dMateriales luMaterial = new dMateriales();
                using (luMaterial)
                {
                    luMaterial.mtdGuardarMaterial(newTipo);
                    this.prdResult = luMaterial.prdResult;
                }
            }
            catch (Exception ex)
            {
                mtdRespError(ex.ToString());
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
