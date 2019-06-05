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

        public List<Materiales> GetMaterialesXCategoria(int idCat)
        {
            try
            {
                using(dMateriales luResult = new dMateriales())
                {
                    return luResult.GetMaterialesXCategoria(idCat);
                }
            }
            catch
            {
                return null;
            }
        }
        public List<Materiales> mtdGetMateriales()
        {
            try
            {
                List<Materiales> luResult = null;
                dMateriales luDato = new dMateriales();
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

        public void MtdGuardarMaterial(Materiales newTipo)
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

        public void mtdActualizarMaterial(Materiales luId)
        {
            dMateriales luMaterial = new dMateriales();
            using (luMaterial)
            {
                luMaterial.mtdActualizarMaterial(luId);
                this.prdResult = luMaterial.prdResult;
            }
        }

        public void mtdBajaMaterial(int luId)
        {
            dMateriales luMaterial = new dMateriales();
            using (luMaterial)
            {
                luMaterial.mtdBajaMaterial(luId);
                this.prdResult = luMaterial.prdResult;
            }
        }
        

        public List<Categoria> GetCategoriaMateriales()
        {
            try
            {
                using (dMateriales luResult = new dMateriales())
                {
                    return luResult.GetCategoriaMateriales();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Materiales> GetMaterialesNCantidad()
        {
            try
            {
                using (dMateriales luResult = new dMateriales())
                {
                    return luResult.GetMaterialesNCantidad();
                }
            }
            catch
            {
                return null;
            }
        }


        public List<stcComboS> mtdGetTipoCategoria()
        {
            try
            {
                List<stcComboS> luResult = null;
                dMateriales luCategoria = new dMateriales();
                using (luCategoria)
                {
                    luResult = luCategoria.mtdGetTipoCategoria();
                }
                mtdRespOK();
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
