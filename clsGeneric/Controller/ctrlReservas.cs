using clsGeneric.Data;
using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Controller
{
    public class ctrlReservas : clsResult, IDisposable
    {
        public List<Reservas> mtdGetReservas()
        {
            try
            {
                List<Reservas> luResult = null;
                dReservas luDato = new dReservas();
                using (luDato)
                {
                    luResult = luDato.mtdGetReservas();
                }

                return luResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void mtdActualizarReserva(Reservas luId)
        {
            dReservas luReserva = new dReservas();
            using (luReserva)
            {
                luReserva.mtdActualizarReserva(luId);
                this.prdResult = luReserva.prdResult;
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
