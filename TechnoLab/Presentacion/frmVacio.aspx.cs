using clsGeneric.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.Presentacion
{
    public partial class frmVacio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ctrlUsuarios luCtrl = new ctrlUsuarios())
            {
                Session["idAllClientes"] = luCtrl.GetReserva("S5899-8");

            }



            dgrvClientesX.DataSource = Session["idAllClientes"];
            dgrvClientesX.DataBind();
        }
        protected void dgrvClientes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {


            using (ctrlUsuarios luCtrl = new ctrlUsuarios())
            {
                Session["idAllClientes"] = luCtrl.GetReserva("S5899-8");

            }



            //dgrvClientesX.DataSource = Session["idAllClientes"];
            //dgrvClientesX.DataBind();


        }
    }
}