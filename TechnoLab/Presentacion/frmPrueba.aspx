<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmPrueba.aspx.cs" Inherits="TechnoLab.Presentacion.frmPrueba" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/ctrlUsuario/wucReservas.ascx" TagPrefix="uc1" TagName="wucReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

function dtbcDocumentosClientes_ActiveTabChanged(s, e) {

    var luTab = s.GetActiveTab();
    var lsText = luTab.GetText();

    var lsTab = luTab.name;
    $('#idDocumentosClientes').hide();
    $('#idContactoClientesGrid').hide();

    if (lsTab == 'idDocumentosCli') {
        dhddClienteWucInst.Set("guTAB", 'DOCUMENTOS');


        $('#idDocumentosClientes').show();
    }
    else {
        dhddClienteWucInst.Set("guTAB", 'PENDIENTES');
        //dgrvOperacionesInst.PerformCallback('PENDIENTES');
        $('#idContactoClientesGrid').show();
    }
}

function dupdSubirArchivos_FileUploadComplete() {

    if (dupdSubirArchivosInst.cp_Result == "Error") {
        dlblErrorSubirInst.SetVisible(true);

    }
    dbgrvDocumentoClienteInst.PerformCallback();
}

function mtdMostrarNuevo() {
    $("#divPrincipal").hide();
    $("#idCargaDatos").show();
    dpnlCargaDatosInst.SetVisible(true);
    mtdNuevoCliente();
}

function mtdAtrasCarga() {
    $("#divPrincipal").show();
    $("#idCargaDatos").hide();
    dpnlCargaDatosInst.SetVisible(false);
}

function mtdMostrarCliente(pClienteId) {
    $("#divPrincipal").hide();
    $("#idCargaDatos").show();
    dpnlCargaDatosInst.SetVisible(true);
    mtdVerCliente(pClienteId);
}


function mtdMostrarEditar(pOperacionId) {
    $("#divPrincipal").hide();
    $("#idCargaDatos").show();

    dpnlCargaDatosInst.SetVisible(true);

    mtdEditarOperacion(pOperacionId);
}

function mtdValidarCliente() {


    if (dtxtClienteIdInst.GetIsValid() &&
        //dtxtFechaRegInst.GetIsValid() &&
        dcboTipoEmpresaInst.GetIsValid() &&
        dcboNivelRiesgoIdInst.GetIsValid() && dcboEstadoInst.GetIsValid() &&
        dtxtFullNameInst.GetIsValid() && dtxtDocumentoInst.GetIsValid() &&
        dtxtTelefonoInst.GetIsValid() && dtxtDireccionInst.GetIsValid()
    ) {
        return true;
    }
    else return false;
}

function mtdGuardarNuevoCliente() {
    if (mtdValidarCliente()) {
        dbtnConfirmarProcesoClienteInst.SetEnabled(true);
        dppcConfirmarProcesoClienteInst.Show();
        dlblConfirmarProcesoClienteInst.SetVisible(false);
        dlblConfirmarProcesoClienteInstError.SetVisible(false);
    }
}

function mtdGuardarWucCliente() {
    dbtnConfirmarProcesoClienteInst.SetEnabled(false);

    var luOperacion = dhddClienteWucInst.Get('guCliente');
    luOperacion.Proceso = dhddClienteWucInst.Get('idProceso');
    if (luOperacion.Proceso == "EDIT") {
        luOperacion.ClienteId = dtxtClienteIdInst.GetValue();
    } else {
        luOperacion.ClienteId = 0;
    }

    //luOperacion.FechaReg = mtdConvertJSONDate(dtxtFechaRegInst.GetValue());
    luOperacion.TipoEmpresaId = dcboTipoEmpresaInst.GetValue();
    luOperacion.NivelRiesgoId = dcboNivelRiesgoIdInst.GetValue();
    luOperacion.EstadoId = dcboEstadoInst.GetValue();
    luOperacion.FullName = dtxtFullNameInst.GetValue();
    luOperacion.Documento = dtxtDocumentoInst.GetValue();

    luOperacion.Telefono = dtxtTelefonoInst.GetValue();
    luOperacion.Direccion = dtxtDireccionInst.GetText();


    dcllWucClientesInst.PerformCallback(mtdJsonToString(luOperacion));

    dlplLoadingInst.Show();
}


function mtdNuevoCliente() {
    dcpnClientesInst.PerformCallback('NEW~');

    dhddClienteWucInst.Set('idProceso', 'NEW');
    dbtnGuardarXInst.SetEnabled(true);
}



function mtdEditarOperacion(pClienteId) {
    var lsX = 'EDIT~' + pClienteId;
    dcpnClientesInst.PerformCallback(lsX);

    dhddClienteWucInst.Set('idProceso', 'EDIT');
    dhddClienteWucInst.Set('idCliente', pClienteId);
    dbtnGuardarXInst.SetEnabled(true);
}

function mtdManejarControles(valor) {
    dtxtClienteIdInst.SetIsValid(valor);
    //dtxtFechaRegInst.SetIsValid(valor);
    dcboTipoEmpresaInst.SetIsValid(valor);
    dcboNivelRiesgoIdInst.SetIsValid(valor);
    dcboEstadoInst.SetIsValid(valor);
    dtxtFullNameInst.SetIsValid(valor);
    dtxtDocumentoInst.SetIsValid(valor);
    dtxtTelefonoInst.SetIsValid(valor);
    dtxtDireccionInst.SetIsValid(valor);
}


function mtdVerCliente(pClienteId) {


    dcpnClientesInst.PerformCallback('VER~' + pClienteId);

    dhddClienteWucInst.Set('idProceso', 'VER');

    dbtnGuardarXInst.SetEnabled(false);

}

function dcpnClientes_EndCallback(s, e) {
    var lsValor = dcpnClientesInst.cp_cliente;
    var luCliente = mtdStringToJson(lsValor);
    dhddClienteWucInst.Set('guCliente', luCliente);
    mtdManejarControles(true);
}

function dcllWucClientes_EndCallback() {
    dlplLoadingInst.Hide();

}
function dcllWucClientes_CallbackComplete(s, e) {

    var lsResult = e.result.toString().split('~');

    if (lsResult[0] == 'OK') {

        var lsProceso = dhddClienteWucInst.Get('idProceso');
        if (lsProceso == 'NEW' || lsProceso == 'EDIT') {
            dlblConfirmarProcesoClienteInst.SetVisible(true);
            dlblConfirmarProcesoClienteInst.SetText('Proceso Completado');
            //mtdVerOperacion(lsResult[1]);
            dppcConfirmarProcesoClienteInst.Hide();
            dlplLoadingInst.Hide();
            dgrvClientesInstance.PerformCallback();
            mtdAtrasCarga();


        }

    } else {
        dlblConfirmarProcesoClienteInstError.SetVisible(true);
        dlblConfirmarProcesoClienteInstError.SetText(lsResult[1]);
    }

}

function dcllWucClienteDocumento_CallbackComplete() {
    dbtnSeleccionarClienteInst.SetEnabled = false;
}

function dcllWucClienteDocumento_EndCallback() {
    dppcSeleccionarDocumentoInst.Hide();
    dlplLoadingInst.Hide();
}

function mtdMostrarClientesWuc() {

    dbgrvDocumentoClienteInst.PerformCallback();
    dppcSeleccionarDocumentoInst.Show();
}

function dbtnSeleccionarCliente_Click() {
    dcllWucClienteDocumentoInst.PerformCallback();
    dlplLoadingInst.Show();
}


    </script>
       <div class="divContainer">

        <div id="divPrincipal">
             <div class="borderBotom"> 
               <dx:ASPxLabel ID="dlblTitleForm" runat="server" Text="Clientes" Font-Size="Large"  Font-Bold="true" CssClass="ThemeColor">            
               </dx:ASPxLabel>
            </div><div> <br /> </div>
            <div id="idOpeNewHist" >
            <dx:BootstrapButton ID="dbtnNuevaOperacionAlta" runat="server" CausesValidation="false" 
                     Text="Nuevo Cliente" AutoPostBack="false"   >
                       <ClientSideEvents Click="mtdMostrarNuevo"/>
            </dx:BootstrapButton>
        </div>
        

        <div>
            <br />
        </div>
             <dx:ASPxGridView ID="dgrvClientesX" ClientInstanceName="dgrvClientesInstance" runat="server" OnCustomCallback="dgrvClientes_CustomCallback" >
               <Columns>
                            <dx:GridViewDataColumn>
                                <DataItemTemplate>
                                     <table>
                                        <tr>
                                            <td>
                                                 <div onclick="mtdMostrarCliente(<%#Eval("ClienteId")%>);" class="icoBtnVer" ></div>
                                            </td>
                                        </tr>
                                    </table>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn>
                                <DataItemTemplate>
                                     <table>
                                        <tr>
                                            <td>
                                                 <div onclick="mtdMostrarEditar(<%#Eval("ClienteId")%>);" class="icoBtnEditar" ></div>
                                            </td>
                                        </tr>
                                    </table>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        

             
                <dx:GridViewDataColumn FieldName="ClienteId"  Caption="Id cliente"  />
                <dx:GridViewDataColumn FieldName="TipoEmpresaDesc"  Caption="Tipo empresa"  />
                   <dx:GridViewDataColumn FieldName="TipoEmpresaId" Visible="false"  Caption="Tipo empresa"  />
                <dx:GridViewDataColumn FieldName="EstadoDesc" Caption="Estado"  />
                   <dx:GridViewDataColumn FieldName="EstadoId" Visible="false" Caption="Estado"  />
                <dx:GridViewDataColumn FieldName="FullName"  Caption="Nombre completo"  />
                <dx:GridViewDataColumn FieldName="Documento"  Caption="Documento"  />
                <dx:GridViewDataColumn FieldName="NivelRiesgoDesc"  Caption="Nivel registro"  />
                   <dx:GridViewDataColumn FieldName="NivelRiesgoId"  Visible="false" Caption="Nivel registro"  />
                <dx:GridViewDataColumn FieldName="Telefono"  Caption="Telefono"  />
                <dx:GridViewDataColumn FieldName="FechaReg"  Caption="Fecha registro"  />
                <dx:GridViewDataColumn FieldName="UserName"  Caption="Usuario id"  />
                   <dx:GridViewDataColumn FieldName="UsuarioId" Visible="false" Caption="Usuario id" />
                <dx:GridViewDataColumn FieldName="Direccion"  Caption="Direccion"  />
                
                </Columns>
                 <SettingsPager PageSize="30">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
          <Settings ShowColumnHeaders="true"/>
           <SettingsSearchPanel ShowApplyButton="true" ShowClearButton="true" Visible="true" HighlightResults="true" />

             </dx:ASPxGridView>
        </div>
         <div id="idCargaDatos">
             
         <dx:ASPxPanel ID="dpnlCargaDatos" ClientInstanceName="dpnlCargaDatosInst" 
              runat="server"
             ClientVisible="false" >
             <PanelCollection>
                 <dx:PanelContent>
                     <dx:BootstrapButton ID="dbtnBack" runat="server"  Text="<- Volver"   AutoPostBack="false" 
                                       CausesValidation="false"  >
                             <ClientSideEvents Click="mtdAtrasCarga" />
                    </dx:BootstrapButton>

                     <uc1:wucReservas runat="server" id="wucReservas" />

                 </dx:PanelContent>
             </PanelCollection>
         </dx:ASPxPanel>

         </div>
    </div>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
