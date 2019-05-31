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

