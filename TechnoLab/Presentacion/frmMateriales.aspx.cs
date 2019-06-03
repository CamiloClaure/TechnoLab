using clsGeneric.Controller;
using clsGeneric.Model;
using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.Presentacion
{
    public partial class frmMateriales : System.Web.UI.Page
    {
        public string prdEndCallbackJS = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ctrlMateriales luCtrl = new ctrlMateriales())
            {
                Session["Materiales"] = luCtrl.mtdGetMateriales();
                Session["Categoria"] = luCtrl.mtdGetTipoCategoria();
                dgrvMateriales.DataSource = Session["Materiales"];
                if (prdEndCallbackJS.Length > 0)
                {
                    dgrvMateriales.ClientSideEvents.EndCallback = "function (s,e){ " + prdEndCallbackJS + "}";
                }
            ((BootstrapGridViewComboBoxColumn)dgrvMateriales.Columns["CodCategoria"]).PropertiesComboBox.DataSource = Session["Categoria"];
                dgrvMateriales.DataBind();
            }

           
        }

        protected void dgrvMateriales_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                Materiales lunewMaterial = new Materiales();
                ctrlMateriales luDataMaterial = new ctrlMateriales();
                //lunewEntidad.EntidadId = (int)e.NewValues["EntidadId"];
                lunewMaterial.CodMaterial = e.NewValues["CodMaterial"].ToString();
                lunewMaterial.Descripcion = e.NewValues["Descripcion"].ToString();
                lunewMaterial.Nombre = e.NewValues["Nombre"].ToString();
                lunewMaterial.FechaCompra = DateTime.Now;
                lunewMaterial.Estado = e.NewValues["Estado"].ToString();
                lunewMaterial.Ubicacion = e.NewValues["Ubicacion"].ToString();
                lunewMaterial.CodCategoria = (int)e.NewValues["CodCategoria"];
                lunewMaterial.Cantidad = (int)e.NewValues["Cantidad"];
                lunewMaterial.Activo = true;
                luDataMaterial.MtdGuardarMaterial(lunewMaterial);
                Session["Materiales"] = luDataMaterial.mtdGetMateriales();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            e.Cancel = true;
            ((BootstrapGridView)sender).CancelEdit();
            dgrvMateriales.DataSource = Session["Materiales"];
            ((BootstrapGridView)sender).DataBind();
        }

        protected void dgrvMateriales_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                Materiales lunewMaterial = new Materiales();
                ctrlMateriales luMaterial = new ctrlMateriales();

                lunewMaterial.Codigo = (int)e.Keys["Codigo"];


                lunewMaterial.CodMaterial = e.NewValues["CodMaterial"].ToString();
                lunewMaterial.Descripcion = e.NewValues["Descripcion"].ToString();
                lunewMaterial.Nombre = e.NewValues["Nombre"].ToString();
                lunewMaterial.FechaCompra = DateTime.Now;
                lunewMaterial.Estado = e.NewValues["Estado"].ToString();
                lunewMaterial.Ubicacion = e.NewValues["Ubicacion"].ToString();
                lunewMaterial.CodCategoria = (int)e.NewValues["CodCategoria"];
                lunewMaterial.Cantidad = (int)e.NewValues["Cantidad"];
                lunewMaterial.Activo = true;
                luMaterial.mtdActualizarMaterial(lunewMaterial);

                if (!luMaterial.isSuccess())
                {
                    throw new Exception(luMaterial.mtdGetMessageToUser());
                }
                else
                {
                    Session["Materiales"] = luMaterial.mtdGetMateriales();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dgrvEntidades_RowUpdating-->" + ex.ToString());
            }
            e.Cancel = true;
            ((BootstrapGridView)sender).CancelEdit();
            dgrvMateriales.DataSource = Session["Materiales"];
            ((BootstrapGridView)sender).DataBind();
        }

        protected void dgrvMateriales_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                Materiales luNewMaterial = new Materiales();
                int luId = (int)e.Keys["Codigo"];
                ctrlMateriales luMaterial = new ctrlMateriales();
                luNewMaterial.Codigo = luId;
                luMaterial.mtdBajaMaterial(luId);
                if (!luMaterial.isSuccess())
                {
                    throw new Exception(message: luMaterial.prdResult.prdMessage);
                }
                else
                {
                    Session["Materiales"] = luMaterial.mtdGetMateriales();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dgrvEntidades_RowDeleting-->" + ex.ToString());
            }
            e.Cancel = true;
            ((BootstrapGridView)sender).CancelEdit();
            dgrvMateriales.DataSource = Session["Materiales"];
            ((BootstrapGridView)sender).DataBind();
        }
    }
}