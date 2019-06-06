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

        public List<Materiales> mtdGetMateriales()
        {
            try
            {
                List<Materiales> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<Materiales>(@"Select * from material where Activo = 1").ToList();
                    guConnection.mtdCerrar();
                }
                return luResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void mtdGuardarMaterial(Materiales luNew)
        {

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@CodMaterial", luNew.CodMaterial);
                    Materiales luResult = guConnection.guDb.Query<Materiales>(@"Select * From material u where u.CodMaterial=@CodMaterial", luParameters).FirstOrDefault();
                    if (luResult == null)
                    {
                        guConnection.guDb.Insert<Materiales>(luNew);
                        //   mtdTokenResetPassword(prdUsuario.UsuarioId);
                        mtdRespOK();

                    }
                    else
                    {
                        if (!(bool)luResult.Activo)
                        {
                            luResult.CodMaterial = luNew.CodMaterial;
                            luResult.Descripcion = luNew.Descripcion;
                            luResult.Nombre = luNew.Nombre;
                            luResult.FechaCompra = luNew.FechaCompra;
                            luResult.Estado = luNew.Estado;
                            luResult.Ubicacion = luNew.Ubicacion;
                            luResult.CodCategoria = luNew.CodCategoria;
                            luResult.Cantidad = luNew.Cantidad;
                            luResult.Activo = true;

                            guConnection.guDb.Update<Materiales>(luResult);
                            mtdRespOK();
                        }
                        else
                        {
                            mtdRespNOK("El Tipo de Entidad ya existe");
                        }
                    }
                    guConnection.mtdCerrar();
                }
            }
            catch (Exception ex)
            {
                mtdRespError(ex.ToString());
            }
        }

        public void mtdActualizarMaterial(Materiales lunew)
        {
            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    Materiales luResult = guConnection.guDb.Get<Materiales>(lunew.Codigo);

                    if (luResult != null)
                    {
                        luResult.CodMaterial = lunew.CodMaterial;
                        luResult.Descripcion = lunew.Descripcion;
                        luResult.Nombre = lunew.Nombre;
                        luResult.FechaCompra = lunew.FechaCompra;
                        luResult.Estado = lunew.Estado;
                        luResult.Ubicacion = lunew.Ubicacion;
                        luResult.CodCategoria = lunew.CodCategoria;
                        luResult.Cantidad = lunew.Cantidad;
                        luResult.Activo = true;
                        guConnection.guDb.Update<Materiales>(luResult);

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

        public void mtdBajaMaterial(int luId)
        {
            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@Codigo", luId);
                    Materiales luResult = guConnection.guDb.Query<Materiales>(@"Select * From material u where u.Codigo=@Codigo", luParameters).FirstOrDefault();

                    if (luResult != null)
                    {
                        luResult.Activo = false;

                        guConnection.guDb.Update<Materiales>(luResult);

                        guConnection.mtdCerrar();

                        mtdRespOK();
                    }
                    else mtdRespNOK("No se encontró el Nivel para Eliminar");
                }
                //  mtdRespNOK("No se encontró el Nivel para actualizar");
            }
            catch (Exception ex)
            {
                mtdRespError(ex.ToString());
            }
        }

        public List<stcComboS> mtdGetTipoCategoria()
        {
            try
            {

                List<stcComboS> luResult = null;
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    luResult = guConnection.guDb.Query<stcComboS>(@"Select  
                                                                        Id prdId,
                                                                         Descripcion prdDescripcion
                                                                    From categoria").ToList();
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
