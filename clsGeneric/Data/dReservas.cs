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
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = 1").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Reservas> mtdGetAprobados()
        {
            try
            {
                List<Reservas> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = 2").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Reservas> mtdGetDevuelto()
        {
            try
            {
                List<Reservas> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = 4").ToList();
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

        public List<stcComboS> mtdGetTipoUsuario()
        {
            try
            {

                List<stcComboS> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<stcComboS>(@"Select  
                                                                        Codigo prdId,
                                                                         Nombre prdDescripcion
                                                                    From usuario").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<stcComboS> mtdGetTipoMateria()
        {
            try
            {

                List<stcComboS> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<stcComboS>(@"Select  
                                                                        Id prdId,
                                                                         Nombre prdDescripcion
                                                                    From materia").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<stcComboS> mtdGetTipoEstado()
        {
            try
            {

                List<stcComboS> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<stcComboS>(@"Select  
                                                                        idEstado prdId,
                                                                         Descripcion prdDescripcion
                                                                    From consestado").ToList();
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
