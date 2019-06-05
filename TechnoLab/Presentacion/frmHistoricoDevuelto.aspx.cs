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
    public partial class frmHistoricoDevuelto : System.Web.UI.Page
    {
        public string prdEndCallbackJS = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ctrlReservas luCtrl = new ctrlReservas())
            {
                Session["Reservas"] = luCtrl.mtdGetDevuelto();
                Session["Usuario"] = luCtrl.mtdGetTipoUsuario();
                Session["Materia"] = luCtrl.mtdGetTipoMateria();
                Session["Estado"] = luCtrl.mtdGetTipoEstado();
                dgrvHistorialDevuelto.DataSource = Session["Reservas"];
                if (prdEndCallbackJS.Length > 0)
                {
                    dgrvHistorialDevuelto.ClientSideEvents.EndCallback = "function (s,e){ " + prdEndCallbackJS + "}";
                }
                ((BootstrapGridViewComboBoxColumn)dgrvHistorialDevuelto.Columns["IdEstudiante"]).PropertiesComboBox.DataSource = Session["Usuario"];
                ((BootstrapGridViewComboBoxColumn)dgrvHistorialDevuelto.Columns["IdMateria"]).PropertiesComboBox.DataSource = Session["Materia"];
                ((BootstrapGridViewComboBoxColumn)dgrvHistorialDevuelto.Columns["Estado"]).PropertiesComboBox.DataSource = Session["Estado"];
                dgrvHistorialDevuelto.DataBind();
            }
        }

        protected void dgrvHistorialApro_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                Reservas lunewReserva = new Reservas();
                ctrlReservas luReserva = new ctrlReservas();

                lunewReserva.Id = (int)e.Keys["Id"];
                lunewReserva.Estado = (int)e.NewValues["Estado"];
                luReserva.mtdActualizarReserva(lunewReserva);

                if (!luReserva.isSuccess())
                {
                    throw new Exception(luReserva.mtdGetMessageToUser());
                }
                else
                {
                    Session["Reservas"] = luReserva.mtdGetAprobados();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dgrvEntidades_RowUpdating-->" + ex.ToString());
            }
            e.Cancel = true;
            ((BootstrapGridView)sender).CancelEdit();
            dgrvHistorialDevuelto.DataSource = Session["Reservas"];
            ((BootstrapGridView)sender).DataBind();
        }
    }
}