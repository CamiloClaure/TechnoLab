using clsGeneric.Model;
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

            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["giUsuario"];
                if (dtvwMenuOpciones != null)
                {
                dtvwMenuOpciones.Nodes.Add("Inicio", "Init", "../Imagenes/cuentas.png","~/Presentacion/frmBienvenida.aspx");

                    if (user.Privilegios == "admin")
                    {
                        LlenarOpcionesAdmin();
                    }
                    else
                    {
                        LlenarOpcionesUser();
                    }
                }
                if (this.dpltPane != null)
                {
                    this.dpltPane.GetPaneByName("ContentUrlPane").ContentUrl = "frmBienvenida.aspx";
                }



            }




        }

        protected void LlenarOpcionesAdmin()
        {
            dtvwMenuOpciones.Nodes.Add("Administrador", "Admin", "../Imagenes/cuentas.png");
            string url = "~/Presentacion/frmHistoricoDevuelto.aspx";
            var node = dtvwMenuOpciones.Nodes.FindByName("Admin").Nodes.Add("frmHistoricoDevuelto", "1", "", url, "contentUrl");
            url = "~/Presentacion/frmMateriales.aspx";
            node = dtvwMenuOpciones.Nodes.FindByName("Admin").Nodes.Add("frmMateriales", "1", "", url, "contentUrl");

            url = "~/Presentacion/frmHistorialAprobado.aspx";
            node = dtvwMenuOpciones.Nodes.FindByName("Admin").Nodes.Add("frmHistorialAprobado", "1", "", url, "contentUrl");

            url = "~/Presentacion/frmReservasAdm.aspx";
            node = dtvwMenuOpciones.Nodes.FindByName("Admin").Nodes.Add("frmReservasAdm", "1", "", url, "contentUrl");

            url = "~/Presentacion/frmVacio.aspx";
            node = dtvwMenuOpciones.Nodes.FindByName("Admin").Nodes.Add("Reservar", "1", "", url, "contentUrl");



        }

        protected void LlenarOpcionesUser()
        {
            dtvwMenuOpciones.Nodes.Add("Opciones", "User", "~/Imagenes/cuentas.png");
            string url = "~/Presentacion/frmVacio.aspx";
            var node = dtvwMenuOpciones.Nodes.FindByName("User").Nodes.Add("Reservar", "1", "", url, "contentUrl");

        }

        protected void btnReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/frmReservation.aspx", false);
        }
    }
}