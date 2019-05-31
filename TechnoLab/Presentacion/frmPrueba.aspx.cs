using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.Presentacion
{
    public partial class frmPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dgrvClientes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {


            //using (ctrlClientes luCtrl = new ctrlClientes())
            //{
            //    Session["idAllClientes"] = luCtrl.GetClientes();

            //}



            dgrvClientesX.DataSource = Session["idAllClientes"];
            dgrvClientesX.DataBind();


        }
    }
}