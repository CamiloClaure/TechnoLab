using clsGeneric.Controller;
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
    }
}