﻿using System;
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
            //dtvwMenuOpciones.Nodes.Add("Administrador", "Admin", "../Imagenes/cuentas.png");
            //string url = "~/Presentacion/frmHistoricoDevuelto.aspx";
            //var node = dtvwMenuOpciones.Nodes.FindByName("Reservitas").Nodes.Add("ReservasEst", "1", "", url, "contentUrl");
            if (!IsPostBack){

                if (this.dpltPane != null) {
                    this.dpltPane.GetPaneByName("ContentUrlPane").ContentUrl = "frmBienvenida.aspx";
                }

               

            }




        }

        protected void btnReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/frmReservation.aspx", false);
        }
    }
}