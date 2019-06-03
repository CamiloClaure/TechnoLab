using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webGeneric.CtrlUsuario.General
{
    public partial class wucConfirmarProcesoResponsive : System.Web.UI.UserControl
    {

        public string prdPopUpHeaderText = "Confirmación de Proceso";
        public string prdLabelMensaje_ClientInstanceName = "¿Está seguro de continuar con el proceso?";

        public string prdPopUp_ClientInstanceName = string.Empty;
        public string prdBotonAceptar_ClientInstanceName = string.Empty;
        public string prdBotonRechazar_ClientInstanceName = string.Empty;
        public string prdLabelMensajeProcesoCompleto_ClientInstanceName = string.Empty;
        public string prdLabelMensajeProcesoCompleto_ClientInstanceNameError = string.Empty;
        public string prdLabelMensajeProcesoCompleto_ClientInstanceNameInfo = string.Empty;
        public string prdAceptarMetodoJs = string.Empty;
        public string prdCancelarMetodoJs = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (dppcConfirmarProcesoResponsive.ClientInstanceName.Length == 0)
            {
                dppcConfirmarProcesoResponsive.HeaderText = prdPopUpHeaderText;
                dlblMsgEAcConfirmacion.Text = prdLabelMensaje_ClientInstanceName;

                dppcConfirmarProcesoResponsive.ClientInstanceName = prdPopUp_ClientInstanceName;
                dbtnConrfimarProcesoGenericoOK.ClientInstanceName = prdBotonAceptar_ClientInstanceName;
                dbtnConrfimarProcesoGenericoNOK.ClientInstanceName = prdBotonRechazar_ClientInstanceName;
                dlblMensajeGenericoOK.ClientInstanceName = prdLabelMensajeProcesoCompleto_ClientInstanceName;
                dlblMensajeGenericoNOK.ClientInstanceName = prdLabelMensajeProcesoCompleto_ClientInstanceNameError;
                dlblMensajeGenericoInfo.ClientInstanceName = prdLabelMensajeProcesoCompleto_ClientInstanceNameInfo;


                dbtnConrfimarProcesoGenericoOK.ClientSideEvents.Click = "function (s,e){ " + prdAceptarMetodoJs + "}";
                dbtnConrfimarProcesoGenericoNOK.ClientSideEvents.Click = "function (s,e){ " + prdCancelarMetodoJs + prdPopUp_ClientInstanceName + ".Hide();}";
                dppcConfirmarProcesoResponsive.ClientSideEvents.CloseButtonClick = "function (s,e){ " + prdCancelarMetodoJs + "}";



                //idContenedorMensaje.ID = "cnt_" +  prdLabelMensajeProcesoCompleto_ClientInstanceName;
                //idContenedorMensaje.ClientIDMode = ClientIDMode.Static;
            }
        }
    }
}