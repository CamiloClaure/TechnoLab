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

                        foreach(Materiales mat in materiales)
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
