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
    public partial class frmReservasAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                using (ctrlReservas luCtrl = new ctrlReservas())
                {
                    Session["Reservas"] = luCtrl.mtdGetReservas();

                }
                dgrvReservasAdm.DataSource = Session["Reservas"];
                dgrvReservasAdm.DataBind();
            }
        }

        protected void dgrvReservasAdm_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                Reservas lunewReserva = new Reservas();
                ctrlReservas luReserva = new ctrlReservas();

                lunewReserva.Id = (int)e.Keys["Id"];
                lunewReserva.Estado = e.NewValues["Estado"].ToString();
                luReserva.mtdActualizarReserva(lunewReserva);

                if (!luReserva.isSuccess())
                {
                    throw new Exception(luReserva.mtdGetMessageToUser());
                }
                else
                {
                    Session["Reservas"] = luReserva.mtdGetReservas();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dgrvEntidades_RowUpdating-->" + ex.ToString());
            }
            e.Cancel = true;
            ((BootstrapGridView)sender).CancelEdit();
            dgrvReservasAdm.DataSource = Session["Reservas"];
            ((BootstrapGridView)sender).DataBind();
        }
    }
}