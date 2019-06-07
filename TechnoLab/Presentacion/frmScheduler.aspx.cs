using clsGeneric.Controller;
using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.Presentacion
{
    public partial class frmScheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ctrlReservas luCtrl = new ctrlReservas();
            Session["Scheduler"] = new List<Reservas>();
            Session["Scheduler"] = luCtrl.mtdGetReservas();


            List<clsApp> luLista = new List<clsApp>();

            clsApp luA = new clsApp();
            luA.Start = DateTime.Now;
            luA.End = luA.Start.AddDays(1);
            luA.Descripcion = "Prueba1AX";
            luA.Doctor = "Lincoln Bartlett";
            luA.Descripcion2 = "Prueba1";
            luA.Labels = 3;
            luA.Status = 1;
            luA.ID = 1;
            luA.CustomInfo = "CustomInfo";

            clsApp luB = new clsApp();
            luB.Start = DateTime.Now.AddDays(1);
            luB.End = luB.Start.AddHours(1);
            luB.Descripcion = "Prueba2AX";
            luB.Doctor = "Amelia Harper";
            luB.Labels = 2;
            luB.Status = 2;
            luB.Descripcion2 = "Prueba2";
            luB.ID = 2;
            luB.CustomInfo = "CustomInfo2";

            clsApp luC = new clsApp();
            luC.Start = DateTime.Now.AddDays(2);
            luC.End = luC.Start.AddHours(1);
            luC.Descripcion = "Prueba3AX";
            luC.Descripcion2 = "Prueba3";
            luC.Doctor = "Mark Oliver";
            luC.Labels = 5;
            luC.Status = 3;
            luC.ID = 3;
            luC.CustomInfo = "CustomInfo3";
            luLista.Add(luA);
            luLista.Add(luB);
            luLista.Add(luC);
            this.schdTimeline.AppointmentDataSource = luLista;
            this.schdTimeline.ResourceDataSource = luLista;
            this.schdTimeline.DataBind();

        }

        private class clsApp
        {

            public DateTime Start { get; set; }
            public DateTime End { get; set; }

            public string Descripcion { get; set; }
            public string Descripcion2 { get; set; }
            public int ID { get; set; }
            public string Doctor { get; set; }
            public int Labels { get; set; }
            public int Status { get; set; }
            public string CustomInfo { get; set; }
        }
    }
}