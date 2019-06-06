using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clsGeneric.Controller;
using clsGeneric.Model;

namespace TechnoLab
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ctrlUsuarios luUsuer = new ctrlUsuarios();
            Usuario user = luUsuer.GetUsuario(this.txtUsuario.Text, this.txtPassword.Text);
            Session["giUsuario"] = user;
            if(user != null)
            {

            Response.Redirect("Presentacion/frmPrincipal.aspx", false);
            }
        }
    }
}