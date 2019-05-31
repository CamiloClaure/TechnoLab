using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.Presentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //dtvwMenuOpciones.Nodes.Add("Reservas", "Reservitas", "../Imagenes/cuentas.png");
            //string url = "~/Presentacion/frmReservation.aspx";
            //var node = dtvwMenuOpciones.Nodes.FindByName("Reservitas").Nodes.Add("ReservasEst", "1", "", url, "contentUrl");
            // dtvwMenuOpciones.Nodes.FindByName("Reservitas").Target = "contentUrl";
            
        }

        protected void btnReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/frmReservation.aspx", false);
        }
    }
}