using clsGeneric.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace clsGeneric.Data
{
    public class dReservas : clsResult, IDisposable
    {
        public clsConnection guConnection;
        public dReservas()
        {
            this.guConnection = new clsConnection();
        }

        public dReservas(int t)
        {
          
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
                    DynamicParameters luParams = new DynamicParameters();
                    luParams.Add("@Estado", "Pendiente");
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = @Estado",luParams).ToList();
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
                    DynamicParameters luParams = new DynamicParameters();
                    luParams.Add("@Estado", "Aprobado");
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = @Estado", luParams).ToList();
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
                    DynamicParameters luParams = new DynamicParameters();
                    luParams.Add("@Estado", "Devuelto");
                    luResult = guConnection.guDb.Query<Reservas>(@"Select * from reserva where Estado = @Estado", luParams).ToList();
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
                    Reservas luResult = guConnection.guDb.Get<Reservas>(lunew.IdReserva);

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
                                                                        IdMateria prdId,
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
        public Reservas GetReserva(string CodEstudiante, int CodReserva)
        {
            Reservas reservas = new Reservas();

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@CodUser", CodEstudiante);
                    luParameters.Add("@CodReserva", CodReserva);
                    reservas = guConnection.guDb.Query<Reservas>(@"	Select res.*,mat.Nombre as 'MateriaDesc'
                                                                	from reserva res join
                                                                	materia mat on mat.IdMateria = res.IdMateria
                                                                	where res.IdEstudiante = @CodUser and res.IdReserva = @CodReserva;
                                                                ").FirstOrDefault();
                    guConnection.mtdCerrar();

                }
            }
            catch (Exception es)
            {

                es.ToString();
            }

            return reservas;
        }


        public Reservas GetReserva(string CodEstudiante)
        {
            Reservas reservas = new Reservas();

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@CodUser", CodEstudiante);

                    reservas = guConnection.guDb.Query<Reservas>(@"	Select res.*,mat.Nombre as 'MateriaDesc'
                                                                	from reserva res join
                                                                	materia mat on mat.IdMateria = res.IdMateria
                                                                	where res.IdEstudiante = @CodUser;
                                                                ").FirstOrDefault();
                    guConnection.mtdCerrar();

                }
            }
            catch (Exception es)
            {

                es.ToString();
            }

            return reservas;
        }

        public List<Reservas> GetListaReserva(string CodEstudiante)
        {
            List<Reservas> reservas = new List<Reservas>();

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@CodUser", CodEstudiante);

                    reservas = guConnection.guDb.Query<Reservas>(@"	Select res.*,mat.Nombre as 'MateriaDesc'
                                                                	from reserva res join
                                                                	materia mat on mat.IdMateria = res.IdMateria
                                                                	where res.IdEstudiante = @CodUser;
                                                                ",luParameters).ToList();
                    guConnection.mtdCerrar();

                }
            }
            catch (Exception es)
            {

                es.ToString();
            }

            return reservas;
        }




        public void AddReserva(Reservas reserva, List<Materiales> materiales)
        {
            try
            {
                TransactionOptions luTransOptions = new TransactionOptions();
                TransactionScope guTransaction = new TransactionScope(TransactionScopeOption.Required, luTransOptions);
                List<DetalleReserva> listaDetalles = new List<DetalleReserva>();
                using (guTransaction)
                {
                    using (guConnection)
                    {
                        guConnection.mtdAbrir();

                        guConnection.guDb.Insert<Reservas>(reserva);

                        foreach (Materiales mat in materiales)
                        {
                            DetalleReserva detalle = new DetalleReserva();
                            detalle.CodReserva = reserva.CodReserva;
                            detalle.IdReserva = reserva.IdReserva;
                            detalle.IdMaterial = mat.Codigo;
                            detalle.Cantidad = mat.Cantidad;
                            listaDetalles.Add(detalle);
                        }
                        guConnection.guDb.Insert<List<DetalleReserva>>(listaDetalles);
                    }


                    guTransaction.Complete();
                    guConnection.mtdCerrar();
                    mtdRespOK(reserva.CodReserva.ToString());

                }
            }

            catch (Exception e) { }
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
