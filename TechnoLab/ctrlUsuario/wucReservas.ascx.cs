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

        }



        #region ManejoControles
        private void mtdVaciarControles()
        {
            dtxtClienteId.Text = string.Empty;
            dtxtDireccion.Text = string.Empty;
            dtxtDocumento.Text = string.Empty;
            dcboEstado.Value = "P";
            dcboEstado.ClientEnabled = false;
            //dtxtFechaReg.Text = string.Empty;
            dtxtFullName.Text = string.Empty;
            dtxtTelefono.Text = string.Empty;
            dcboNivelRiesgoId.Value = null;
            dcboTipoEmpresa.Value = null;
            //Session["wucClienteContacto"] = new List<Contacto>();

            dgrvContacto.DataSource = Session["wucClienteContacto"];
            dgrvContacto.DataBind();

            //Session["DocumentosCliente"] = new List<DocumentosCliente>();
            dbgrvDocumentoCliente.DataSource = Session["DocumentosCliente"];
            dbgrvDocumentoCliente.DataBind();
        }

        private void mtdHabilitarControles()
        {
            bool flag = true;

            //dtxtClienteId.ClientEnabled = flag;
            dtxtDireccion.ClientEnabled = flag;
            dtxtDocumento.ClientEnabled = flag;
            //dcboEstado.ClientEnabled = flag;
            //dtxtFechaReg.ClientEnabled = flag;
            dtxtFullName.ClientEnabled = flag;
            dtxtTelefono.ClientEnabled = flag;
            dcboNivelRiesgoId.ClientEnabled = flag;
            dcboTipoEmpresa.ClientEnabled = flag;
            //dgrvContacto.Enabled = flag;
            dtbcOperacionOperacion.Enabled = flag;
            dbtnClienteSeleccionar.Enabled = flag;
            //dbtnClienteSeleccionar.Enabled = true;
            (dgrvContacto.Columns["CommandColumn"] as GridViewColumn).Visible = true;
            (dbgrvDocumentoCliente.Columns["CommandColumn"] as BootstrapGridViewCommandColumn).Visible = true;
        }

        private void mtdDeshabilitarControles()
        {
            bool flag = false;

            //dtxtClienteId.ClientEnabled = flag;
            dtxtDireccion.ClientEnabled = flag;
            dtxtDocumento.ClientEnabled = flag;
            dcboEstado.ClientEnabled = flag;
            //dtxtFechaReg.ClientEnabled = flag;
            dtxtFullName.ClientEnabled = flag;
            dtxtTelefono.ClientEnabled = flag;
            dcboNivelRiesgoId.ClientEnabled = flag;
            dcboTipoEmpresa.ClientEnabled = flag;
            dtbcOperacionOperacion.Enabled = flag;
            //dgrvContacto.Enabled = flag;

            dbtnClienteSeleccionar.Enabled = flag;
            //dbtnClienteSeleccionar.Enabled = false;
            (dgrvContacto.Columns["CommandColumn"] as GridViewColumn).Visible = false;
            (dbgrvDocumentoCliente.Columns["CommandColumn"] as BootstrapGridViewCommandColumn).Visible = false;
        }

        private void mtdCargarComboBox()
        {
            //using (ctrlClientes luCliente = new ctrlClientes())
            //{
            //    dcboTipoEmpresa.DataSource = luCliente.GetTipoEmpresas();
            //    dcboTipoEmpresa.DataBind();

            //    dcboNivelRiesgoId.DataSource = luCliente.GetNivelRiesgo();
            //    dcboNivelRiesgoId.DataBind();

            //    dcboEstado.DataSource = luCliente.GetEstadoCliente();
            //    dcboEstado.DataBind();

            //    ((BootstrapGridViewComboBoxColumn)dbgrvDocumentoCliente.Columns["TipoDocumentoId"]).PropertiesComboBox.DataSource = Session["cboTipoDocumento"];

            //}


        }

        private void mtdCargarControl(int pClientes)
        {
            //ctrlClientes luClientes = new ctrlClientes();

            //mtdCargarComboBox();

            //dtxtClienteId.Text = pClientes.ClienteId.ToString();
            //dtxtDireccion.Text = pClientes.Direccion;
            //dtxtDocumento.Text = pClientes.Documento;
            //dcboEstado.Value = pClientes.EstadoId;
            //dcboEstado.TextField = pClientes.EstadoDesc;
            ////dtxtFechaReg.Value = pClientes.FechaReg.ToString();
            //dtxtFullName.Text = pClientes.FullName;
            //dtxtTelefono.Text = pClientes.Telefono;
            //dcboNivelRiesgoId.Value = pClientes.NivelRiesgoId;
            //dcboNivelRiesgoId.TextField = pClientes.NivelRiesgoDesc;
            //dcboTipoEmpresa.Value = pClientes.TipoEmpresaId;
            //dcboTipoEmpresa.TextField = pClientes.TipoEmpresaDesc;
            //Session["wucClienteContacto"] = luClientes.getContactos(pClientes.ClienteId);
            //Session["tmpCliente"] = pClientes;
            //dgrvContacto.DataSource = Session["wucClienteContacto"];
            //dgrvContacto.DataBind();
            //Session["DocumentosCliente"] = luClientes.getDocumentosCliente(pClientes.ClienteId);
            //dbgrvDocumentoCliente.DataSource = Session["DocumentosCliente"];
            //dbgrvDocumentoCliente.DataBind();


            //luClientes.Dispose();
        }

        private void mtdMostrarControles(int pCliente, string pProceso)
        {
            //mtdDeshabilitarControles();
            //if (pProceso == "NEW")
            //{
            //    mtdHabilitarControles();
            //    mtdVaciarControles();
            //    dtbcOperacionOperacion.Enabled = false;


            //}
            //if (pProceso == "EDIT" || pProceso == "VER")
            //{
            //    dtbcOperacionOperacion.Enabled = true;

            //    using (ctrlClientes luCtrl = new ctrlClientes())
            //    {
            //        // pOperacion = luCtrl.getOperacion(pOperacion.OperacionId);


            //        if (pProceso == "EDIT")
            //        {
            //            mtdHabilitarControles();

            //        }
            //        mtdCargarControl(pCliente);

            //    }
            //}
        }


        #endregion

        #region CallBacks y otros

        protected void dupdSubirArchivos_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            
        }


        protected void dcpnClientes_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //string[] lsParametros = e.Parameter.ToString().Split('~');
            //Clientes luClientes = new Clientes();
            //ctrlClientes ctrl = new ctrlClientes();
            //if (lsParametros[0] == "NEW" || lsParametros[0] == "EDIT" || lsParametros[0] == "VER")
            //{
            //    mtdCargarComboBox();

            //    if (lsParametros[0] == "NEW")
            //    {
            //        //luOperacion.OperacionId = Convert.ToInt32(lsParametros[1]);
            //        mtdVaciarControles();
            //    }
            //    if (lsParametros[0] == "VER" || lsParametros[0] == "EDIT")
            //    {

            //        luClientes = ctrl.GetClientes(Convert.ToInt32(lsParametros[1]));


            //    }
            //    mtdMostrarControles(luClientes, lsParametros[0]);
            //}

            //dcpnClientes.JSProperties["cp_cliente"] = clsUtil.mtdToJSON(luClientes);
        }

        protected void dcllWucClientes_Callback(object source, CallbackEventArgs e)
        {
            //try
            //{
            //    Clientes luCliente = clsUtil.mtdJsonToObj<Clientes>(e.Parameter.ToString());
            //    List<Contacto> luContactos = (List<Contacto>)Session["wucClienteContacto"];
            //    string lsResult = "NOK~Proceso no completado.";
            //    int? liUsuarioId = (int?)Session["giUsuarioID"];
            //    if (liUsuarioId == null)
            //    {
            //        throw new Exception("La sesión del usuario ha finalizado, favor cerrar sesión.");
            //    }

            //    if (luCliente.Proceso == "NEW")
            //    {
            //        luCliente.UsuarioId = (int)Session["giUsuarioID"];

            //        using (ctrlClientes luCtrl = new ctrlClientes())
            //        {
            //            luCtrl.AddCliente(luCliente, luContactos, (int)liUsuarioId);
            //            if (luCtrl.isSuccess())
            //            {
            //                lsResult = "OK~" + luCtrl.prdResult.prdMessage;
            //            }
            //            else
            //            {
            //                lsResult = "NOK~" + luCtrl.prdResult.prdMessage;
            //            }
            //        }
            //    }
            //    if (luCliente.Proceso == "EDIT")
            //    {
            //        using (ctrlClientes luCtrl = new ctrlClientes())
            //        {
            //            luCtrl.ActualizarCliente(luCliente, luContactos);
            //            if (luCtrl.isSuccess())
            //            {
            //                lsResult = "OK~" + luCtrl.prdResult.prdMessage;
            //            }
            //            else
            //            {
            //                lsResult = "NOK~" + luCtrl.prdResult.prdMessage;
            //            }
            //        }
            //    }
            //    e.Result = lsResult;
            //}
            //catch (Exception ex)
            //{
            //    e.Result = "NOK~" + ex.ToString();
            //}

        }

        protected void dbgrvDocumentoCliente_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //try
            //{
            //    string[] lsValores = e.Parameters.ToString().Split('~');

            //    if (lsValores[0] == "DELETE")
            //    {

            //        int liDoc = Convert.ToInt32(lsValores[1]);

            //        List<DocumentosCliente> lstDocumentos = (List<DocumentosCliente>)this.Session["DocumentosCliente"];
            //        if (lstDocumentos == null) throw new Exception("La sesión ha caducado");

            //        lstDocumentos = (from u in lstDocumentos
            //                         where u.DocumentoId != liDoc
            //                         select u).ToList();
            //        this.Session["DocumentosCliente"] = lstDocumentos;
            //    }


            //    dbgrvDocumentoCliente.DataSource = this.Session["DocumentosCliente"];
            //    dbgrvDocumentoCliente.DataBind();

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void ValidarDocs(List<int> docs)
        {
            //bool correcto = true;

            //foreach (DocumentosCliente d in docs)
            //{
            //    if (d.ClienteId == 0 || d.TipoDocumentoId == 0 || d.FechaVencimiento == null)
            //    {
            //        return correcto = false;
            //    }
            //}

            //return correcto;
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

        protected void dgrvContacto_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] lsParameters = e.Parameters.ToString().Split('~');
            //Session["idPROCESOOpeWUC"] = lsParameters[0];
            //(dgrvContacto.Columns["CommandColumn"] as GridViewColumn).Visible = true;



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



            //dgrvContacto.DataSource = Session["idWucOperacionesDocumentacion"];
            //dgrvContacto.DataBind();
        }

        protected void dgrvContacto_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }

        protected void dgrvContacto_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
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
            //    dgrvContacto.DataSource = Session["wucClienteContacto"];
            //    dgrvContacto.DataBind();

            //    e.Handled = true;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}


        }

        protected void dgrvContacto_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
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
            dbtnSeleccionarCliente.ClientEnabled = true;
        }

    }
}