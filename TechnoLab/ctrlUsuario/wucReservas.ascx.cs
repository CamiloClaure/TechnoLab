using clsGeneric.Controller;
using clsGeneric.Model;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using DevExpress.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnoLab.ctrlUsuario
{
    public partial class wucReservas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrlMateriales luCtrl = new ctrlMateriales();

            if (!IsPostBack)
            {
                
                 Session["tmpDetalle"] = new List<Materiales>();
                Session["wucMateriales"] = new List<Materiales>();

                Session["wucComboMaterial"] = luCtrl.mtdGetMateriales();
                Session["cboCategoriaMat"] = luCtrl.GetCategoriaMateriales();

            }
           
                
                grid.DataSource = Session["wucMateriales"];
                ((GridViewDataComboBoxColumn)grid.Columns["CodCat"]).PropertiesComboBox.DataSource = Session["cboCategoriaMat"];
                ((GridViewDataComboBoxColumn)grid.Columns["MatXCat"]).PropertiesComboBox.DataSource = Session["wucComboMaterial"];
                grid.DataBind();
          
            

        }

        #region PruebaComboCascada
        protected void grid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Editor.ReadOnly = false;
           /* if (e.Column.FieldName == "MatXCat")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }*/
        }

        protected void FillCityCombo( int codCat)
        {
           
            ctrlMateriales ctrl = new ctrlMateriales();
            List<Materiales> cities = ctrl.GetMaterialesNCantidad(codCat);
         
            Session["wucComboMaterial"] = cities;
            //((GridViewDataComboBoxColumn)grid.Columns["CodCat"]).PropertiesComboBox.DataSource = Session["cboCategoriaMat"];
           
        }
       
        void cboMat_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillCityCombo(Convert.ToInt32(e.Parameter));
        }

        protected void cbpComboMat_Callback(object sender, CallbackEventArgsBase e)
        {
         //   FillCityCombo(Convert.ToInt32(e.Parameter));
        }
        #endregion

        #region ManejoControles
        private void mtdVaciarControles()
        {
            dtxtCodigoEstudiante.Text = string.Empty;

            dtxtFechaInicio.Text = string.Empty;
            dtxtFechaFin.Text = string.Empty;

            //dcboMateria.Value = null;
            //Session["wucClienteContacto"] = new List<Contacto>();


            //Session["DocumentosCliente"] = new List<DocumentosCliente>();

        }

        private void mtdHabilitarControles()
        {
            bool flag = true;

            dtxtCodigoEstudiante.ClientEnabled = flag;

            dtxtFechaFin.ClientEnabled = flag;
            dtxtFechaInicio.ClientEnabled = flag;

            dcboMateria.ClientEnabled = flag;

            //dgrvMaterial.Enabled = flag;


            //dbtnClienteSeleccionar.Enabled = true;


        }

        private void mtdDeshabilitarControles()
        {
            bool flag = false;

            dtxtCodigoEstudiante.ClientEnabled = flag;

            dtxtFechaFin.ClientEnabled = flag;
            dtxtFechaInicio.ClientEnabled = flag;

            dcboMateria.ClientEnabled = flag;

            //dgrvMaterial.Enabled = flag;


            //dbtnClienteSeleccionar.Enabled = false;


        }

        private void mtdCargarComboBox()
        {
            using (ctrlUsuarios luCliente = new ctrlUsuarios())
            {
                dcboMateria.DataSource = luCliente.GetMaterias();
                dcboMateria.DataBind();


            }


        }

        private void mtdCargarControl(Reservas pClientes)
        {
            ctrlUsuarios luClientes = new ctrlUsuarios();

            mtdCargarComboBox();

            dtxtCodigoEstudiante.Text = pClientes.IdEstudiante.ToString();

            //dtxtFechaReg.Value = pClientes.FechaReg.ToString();

            dcboMateria.Value = pClientes.IdMateria;
            dcboMateria.TextField = pClientes.MateriaDesc;

          

            //luClientes.Dispose();
        }

        private void mtdMostrarControles(Reservas pReserva, string pProceso)
        {
            mtdDeshabilitarControles();
            if (pProceso == "NEW")
            {
                mtdHabilitarControles();
                mtdVaciarControles();



            }
            if (pProceso == "EDIT" || pProceso == "VER")
            {


                using (ctrlUsuarios luCtrl = new ctrlUsuarios())
                {
                    // pOperacion = luCtrl.getOperacion(pOperacion.OperacionId);



                    mtdCargarControl(pReserva);

                }
            }
        }


        #endregion

        #region CallBacks y otros




        protected void dcpnEstudiantes_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] lsParametros = e.Parameter.ToString().Split('~');
            Reservas luReservas = new Reservas();
            Usuario user = (Usuario)Session["giUsuario"];
            ctrlUsuarios ctrl = new ctrlUsuarios();
            if (lsParametros[0] == "NEW" || lsParametros[0] == "EDIT" || lsParametros[0] == "VER")
            {
                mtdCargarComboBox();

                if (lsParametros[0] == "NEW")
                {
                    //luOperacion.OperacionId = Convert.ToInt32(lsParametros[1]);
                    mtdVaciarControles();
                    Session["proceso"] = "NEW";
                }
                if (lsParametros[0] == "VER" || lsParametros[0] == "EDIT")
                {

                    luReservas = ctrl.GetReserva(user.Codigo, Convert.ToInt32(lsParametros[1]));
                    Session["proceso"] = "VER";

                }
                mtdMostrarControles(luReservas, lsParametros[0]);
            }

            dcpnEstudiantes.JSProperties["cp_cliente"] = luReservas.IdReserva;
        }

        protected void dcllWucClientes_Callback(object source, CallbackEventArgs e)
        {
            try
            {
                int idReserva = Convert.ToInt32(e.Parameter.ToString().Split('|')[0]);
                int IdMateria = Convert.ToInt32(e.Parameter.ToString().Split('|')[1]);
                List<Materiales> luMateriales = (List<Materiales>)Session["tmpDetalle"];
                string Proceso = Session["proceso"].ToString();
                string lsResult = "NOK~Proceso no completado.";



                if (Proceso == "NEW")
                {
                    Reservas luReservas = new Reservas();
                    luReservas.IdReserva = idReserva;
                    luReservas.IdEstudiante = dtxtCodigoEstudiante.Text;
                    luReservas.FechaI = (DateTime)dtxtFechaInicio.Value;
                    luReservas.FechaF = (DateTime)dtxtFechaFin.Value;
                    var tmp = dcboMateria.SelectedItem;
                    luReservas.IdMateria = IdMateria;
                    luReservas.CodReserva = 1111;
                    

                    using (ctrlUsuarios luCtrl = new ctrlUsuarios())
                    {
                        luCtrl.AddReserva(luReservas, luMateriales);

                    }
                }

                e.Result = lsResult;
            }
            catch (Exception ex)
            {
                e.Result = "NOK~" + ex.ToString();
            }

        }





        protected void dcllWucClienteDocumento_Callback(object source, CallbackEventArgs e)
        {
            //try
            //{

            //    Session["DocumentosCliente"] = new List<DocumentosCliente>();
            //    dbgrvDocumentoCliente.CancelEdit();
            //    dbgrvDocumentoCliente.DataSource = Session["DocumentosCliente"];
            //    dbgrvDocumentoCliente.DataBind();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        protected void dgrvMaterial_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] lsParameters = e.Parameters.ToString().Split('~');
            //Session["idPROCESOOpeWUC"] = lsParameters[0];
            //(dgrvMaterial.Columns["CommandColumn"] as GridViewColumn).Visible = true;



            //using (ctrlClientes luCtrl = new ctrlClientes())
            //{

            //    if (lsParameters[0] == "NEW")
            //    {
            //        Session["idWucOperacionesDocumentacion"] = null;
            //    }
            //    else if (lsParameters[0] == "EDIT")
            //    {
            //        Session["idWucOperacionesDocumentacion"] = luCtrl.getContactos(Convert.ToInt32(lsParameters[1]));
            //    }
            //    else if (lsParameters[0] == "VER")
            //    {

            //    }
            //    //else if (lsParameters[0] == "LOAD")
            //    //{
            //    //    Session["idWucOperacionesDocumentacion"] =
            //    //         luCtrl.getInicialDocumentosRequeridos(Convert.ToInt32(lsParameters[1]), lsParameters[2]);
            //    //}
            //}



            //dgrvMaterial.DataSource = Session["idWucOperacionesDocumentacion"];
            //dgrvMaterial.DataBind();
        }


        protected void dgrvMaterial_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //try
            //{
            //    List<ASPxDataInsertValues> luInserted = e.InsertValues;
            //    List<ASPxDataUpdateValues> luUpdated = e.UpdateValues;
            //    List<ASPxDataDeleteValues> luDeleted = e.DeleteValues;



            //    List<Contacto> luContactos = (List<Contacto>)Session["wucClienteContacto"];

            //    if (luContactos == null) throw new Exception("Excepción");

            //    if (luInserted != null && luInserted.Count > 0)
            //    {

            //        int fieldKeyName = 1;
            //        if (luContactos.Any())
            //        {
            //            fieldKeyName = (from u in luContactos select u.ContactoId).Max() + 1;

            //        }
            //        foreach (ASPxDataInsertValues luInsert in luInserted)
            //        {

            //            Contacto contacto = new Contacto();

            //            if (luInsert.NewValues["ContactoId"] != null)
            //            {
            //                contacto.ContactoId = (int)luInsert.NewValues["ContactoId"];

            //                luContactos = (from u in luContactos
            //                               where u.ContactoId != contacto.ContactoId
            //                               select u).ToList();
            //            }

            //            contacto.ContactoId = fieldKeyName;
            //            contacto.Email = "-";
            //            contacto.ClienteId = 0;
            //            contacto.Area = "-";
            //            contacto.Cargo = "-";
            //            contacto.Telefono = "-";
            //            contacto.Nombre = "-";
            //            if (luInsert.NewValues["Email"] != null) contacto.Email = (string)luInsert.NewValues["Email"];
            //            if (luInsert.NewValues["Area"] != null) contacto.Area = (string)luInsert.NewValues["Area"];
            //            if (luInsert.NewValues["Cargo"] != null) contacto.Cargo = (string)luInsert.NewValues["Cargo"];
            //            if (luInsert.NewValues["Telefono"] != null) contacto.Telefono = (string)luInsert.NewValues["Telefono"];
            //            if (luInsert.NewValues["Nombre"] != null) contacto.Nombre = (string)luInsert.NewValues["Nombre"];
            //            fieldKeyName++;
            //            luContactos.Add(contacto);

            //        }



            //    }

            //    if (luUpdated != null && luUpdated.Count > 0)
            //    {
            //        foreach (ASPxDataUpdateValues luUpd in luUpdated)
            //        {

            //            int luKey = (int)luUpd.Keys["ContactoId"];

            //            Contacto contacto = (from u in luContactos
            //                                 where u.ContactoId == luKey
            //                                 select u).FirstOrDefault();

            //            contacto.Email = "-";
            //            contacto.ClienteId = 0;
            //            contacto.Area = "-";
            //            contacto.Cargo = "-";
            //            contacto.Telefono = "-";
            //            contacto.Nombre = "-";
            //            if (luUpd.NewValues["Email"] != null) contacto.Email = (string)luUpd.NewValues["Email"];
            //            if (luUpd.NewValues["Area"] != null) contacto.Area = (string)luUpd.NewValues["Area"];
            //            if (luUpd.NewValues["Cargo"] != null) contacto.Cargo = (string)luUpd.NewValues["Cargo"];
            //            if (luUpd.NewValues["Telefono"] != null) contacto.Telefono = (string)luUpd.NewValues["Telefono"];
            //            if (luUpd.NewValues["Nombre"] != null) contacto.Nombre = (string)luUpd.NewValues["Nombre"];


            //        }

            //    }

            //    if (luDeleted != null && luDeleted.Count > 0)
            //    {
            //        foreach (ASPxDataDeleteValues luDel in luDeleted)
            //        {
            //            int luKey = (int)luDel.Keys["ContactoId"];
            //            luContactos = (from u in luContactos
            //                           where u.ContactoId != luKey
            //                           select u).ToList();

            //        }
            //    }

            //    Session["wucClienteContacto"] = luContactos;
            //    dgrvMaterial.DataSource = Session["wucClienteContacto"];
            //    dgrvMaterial.DataBind();

            //    e.Handled = true;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}


        }

        protected void dgrvMaterial_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Editor.ReadOnly = false;
        }
        #endregion

        protected void dcbpDocumentos_Callback(object sender, CallbackEventArgsBase e)
        {

        }



        protected void dbgrvDocumentoCliente_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {
            e.Editor.ReadOnly = false;
        }

        protected void dbgrvDocumentoCliente_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //try
            //{

            //    DocumentosCliente docInsert = new DocumentosCliente();


            //    docInsert.ClienteId = (int)e.NewValues["ClienteId"];
            //    docInsert.Descripcion = e.NewValues["Descripcion"].ToString();
            //    docInsert.Activo = true;
            //    docInsert.DocumentoId = (int)e.NewValues["DocumentoId"];
            //    docInsert.TipoDocumentoId = (int)e.NewValues["TipoDocumentoId"];


            //    //luNewTipoDocumento.mtdAddTipoDocumento(docInsert);
            //    List<DocumentosCliente> luRslt = (List<DocumentosCliente>)Session["DocumentosCliente"];
            //    luRslt.Add(docInsert);
            //    e.Cancel = true;
            //    Session["DocumentosCliente"] = luRslt;
            //    ((BootstrapGridView)sender).CancelEdit();
            //    ((BootstrapGridView)sender).DataSource = Session["DocumentosCliente"];
            //    ((BootstrapGridView)sender).DataBind();

            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}

        }

        protected void dbgrvDocumentoCliente_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            //try
            //{

            //    DocumentosCliente docInsert = new DocumentosCliente();
            //    int luKey = (int)e.Keys["DocumentoId"];
            //    List<DocumentosCliente> luRslt = (List<DocumentosCliente>)Session["DocumentosCliente"];

            //    docInsert = (from u in luRslt
            //                 where u.DocumentoId == luKey
            //                 select u).FirstOrDefault();
            //    luRslt.Remove(docInsert);
            //    Clientes tmpCli = (Clientes)Session["tmpCliente"];
            //    docInsert.ClienteId = tmpCli.ClienteId;
            //    docInsert.Descripcion = e.NewValues["Descripcion"].ToString();
            //    docInsert.Activo = true;

            //    docInsert.TipoDocumentoId = (int)e.NewValues["TipoDocumentoId"];
            //    docInsert.FechaVencimiento = (DateTime)e.NewValues["FechaVencimiento"];

            //    luRslt.Add(docInsert);
            //    //luNewTipoDocumento.mtdAddTipoDocumento(docInsert);
            //    using (ctrlClientes luClientes = new ctrlClientes())
            //    {
            //        luClientes.mtdUpdateDocumentosCliente(docInsert);

            //    }

            //    e.Cancel = true;
            //    Session["DocumentosCliente"] = luRslt;
            //    ((BootstrapGridView)sender).CancelEdit();
            //    ((BootstrapGridView)sender).DataSource = Session["DocumentosCliente"];
            //    ((BootstrapGridView)sender).DataBind();


            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        protected void dbgrvDocumentoCliente_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            //try
            //{

            //    DocumentosCliente docInsert = new DocumentosCliente();
            //    int luKey = (int)e.Keys["DocumentoId"];
            //    List<DocumentosCliente> luRslt = (List<DocumentosCliente>)Session["DocumentosCliente"];

            //    docInsert = (from u in luRslt
            //                 where u.DocumentoId == luKey
            //                 select u).FirstOrDefault();
            //    luRslt.Remove(docInsert);

            //    //luNewTipoDocumento.mtdAddTipoDocumento(docInsert);


            //    e.Cancel = true;
            //    Session["DocumentosCliente"] = luRslt;
            //    ((BootstrapGridView)sender).CancelEdit();
            //    ((BootstrapGridView)sender).DataSource = Session["DocumentosCliente"];
            //    ((BootstrapGridView)sender).DataBind();

            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        protected void dbgrvDocumentoCliente_RowUpdated(object sender, ASPxDataUpdatedEventArgs e)
        {

        }

        protected void grid_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            try
            {
                List<Materiales> tmp = (List < Materiales > )Session["tmpDetalle"];
                //ctrlTipoDocumento luNewTipoDocumento = new ctrlTipoDocumento();
                Materiales docInsert = new Materiales();
               

                docInsert.Cantidad = (int)e.NewValues["Cantidad"];
                docInsert.Nombre = e.NewValues["MatXCat"].ToString();
                //string tml = ((GridViewDataComboBoxColumn)grid.Columns["MatXCat"]).PropertiesComboBox.;
                
                docInsert.Activo = true;
                docInsert.CodCategoria = 1;
                docInsert.CodMaterial = "123";
                docInsert.Descripcion = "222";
                docInsert.Estado = "Bueno";
                docInsert.Ubicacion = "";

                tmp.Add(docInsert);
                e.Cancel = true;
                Session["tmpDetalle"] = tmp;
                ((ASPxGridView)sender).CancelEdit();
                ((ASPxGridView)sender).DataSource = Session["tmpDetalle"];
                ((ASPxGridView)sender).DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

       
    }
}