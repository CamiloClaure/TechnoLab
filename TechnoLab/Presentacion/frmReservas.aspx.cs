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
    public partial class Reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                using (ctrlMateriales luCtrl = new ctrlMateriales())
                {
                    Session["Materiales"] = luCtrl.mtdGetMateriales();

                }
                dgrvMateriales.DataSource = Session["Materiales"];
                dgrvMateriales.DataBind();
            }
        }

        protected void dgrvMateriales_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                materialesform lunewMaterial = new materialesform();
                ctrlMateriales luDataMaterial = new ctrlMateriales();
                //lunewEntidad.EntidadId = (int)e.NewValues["EntidadId"];
                lunewMaterial.nombre = e.NewValues["nombre"].ToString();
                lunewMaterial.fechaCompra = DateTime.Now;
                lunewMaterial.estado = e.NewValues["estado"].ToString();
                lunewMaterial.Cantidad = (int)e.NewValues["Cantidad"];
                lunewMaterial.Ubicacion = e.NewValues["Ubicacion"].ToString();
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
            //try
            //{
            //    materialesform luNewMaterial = new materialesform();
            //    ctrlMateriales luMaterial = new ctrlMateriales();

            //    luNewMaterial.idMaterial = (int)e.Keys["EntidadId"];


            //    luNewMaterial.nombre = e.NewValues["nombre"].ToString();
            //    luNewMaterial.fechaCompra = DateTime.Now;
            //    luNewMaterial.estado = true;
            //    //luMaterial.mtdActualizarMaterial(luNewMaterial);

            //    if (!luMaterial.isSuccess())
            //    {
            //        throw new Exception(luMaterial.mtdGetMessageToUser());
            //    }
            //    else
            //    {
            //        Session["UserSession"] = luMaterial.mtdGetMateriales();
            //    }
            //}
            //catch
            //{

            //}
        }
    }
}