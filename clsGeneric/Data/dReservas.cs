using clsGeneric.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Data
{
    public class dReservas : clsResult, IDisposable
    {
        public clsConnection guConnection;
        int tmp = 0;

        public dReservas()
        {
            this.guConnection = new clsConnection();
        }

        public dReservas(int t)
        {
            this.tmp = t;
            guConnection = new clsConnection();
        }

        public List<Reservas> mtdGetReservas()
        {
            try
            {
                List<Reservas> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = 'Pendiente'").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void mtdActualizarReserva(Reservas lunew)
        {

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    Reservas luResult = guConnection.guDb.Get<Reservas>(lunew.Id);

                    if (luResult != null)
                    {
                        luResult.Estado = lunew.Estado;
                        guConnection.guDb.Update<Reservas>(luResult);

                        guConnection.mtdCerrar();

                        mtdRespOK();
                    }
                    else mtdRespNOK("No se encontró el Nivel para actualizar");
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
