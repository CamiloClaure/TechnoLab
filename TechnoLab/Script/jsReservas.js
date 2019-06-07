
function dgrvButton_Click() {
    alert('OK');
}
var lastCountry = null;
function OnCatChanged(cboCat) {
    if (cbpComboMatInst.InCallback())
        lastCountry = cboCat.GetValue().toString();
    else
        grid.GetEditor("MatXCat").PerformCallback(cboCat.GetValue().toString());
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


    if (dtxtCodigoEstudianteInst.GetIsValid() &&
        //dtxtFechaRegInst.GetIsValid() &&
        dcboMateriaInst.GetIsValid()) {
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
        luOperacion.ClienteId = dtxtCodigoEstudianteInst.GetValue();
    } else {
        luOperacion.ClienteId = 0;
    }

    //luOperacion.FechaReg = mtdConvertJSONDate(dtxtFechaRegInst.GetValue());
   

    dcllWucClientesInst.PerformCallback(luOperacion + "|" + dcboMateriaInst.GetValue());

    dlplLoadingInst.Show();
}


function mtdNuevoCliente() {
    dcpnEstudiantesInst.PerformCallback('NEW~');

    dhddClienteWucInst.Set('idProceso', 'NEW');
    dbtnGuardarXInst.SetEnabled(true);
}



function mtdEditarOperacion(pClienteId) {
    var lsX = 'EDIT~' + pClienteId;
    dcpnEstudiantesInst.PerformCallback(lsX);

    dhddClienteWucInst.Set('idProceso', 'EDIT');
    dhddClienteWucInst.Set('idCliente', pClienteId);
    dbtnGuardarXInst.SetEnabled(true);
}

function mtdManejarControles(valor) {
    dtxtCodigoEstudianteInst.SetIsValid(valor);
    //dtxtFechaRegInst.SetIsValid(valor);
    dcboMateriaInst.SetIsValid(valor);
   
 
}


function mtdVerCliente(pClienteId) {


    dcpnEstudiantesInst.PerformCallback('VER~' + pClienteId);

    dhddClienteWucInst.Set('idProceso', 'VER');

    dbtnGuardarXInst.SetEnabled(false);

}

function dcpnEstudiantes_EndCallback(s, e) {
    var lsValor = dcpnEstudiantesInst.cp_cliente;
   
    dhddClienteWucInst.Set('guCliente', lsValor);
    mtdManejarControles(true);
}

function dcllWucClientes_EndCallback() {
    dlplLoadingInst.Hide();

}
function dcllWucClientes_CallbackComplete(s, e) {

    var lsResult = e.result.toString().split('~');

    //if (lsResult[0] == 'OK') {

        var lsProceso = dhddClienteWucInst.Get('idProceso');
        //if (lsProceso == 'NEW' || lsProceso == 'EDIT') {
            dlblConfirmarProcesoClienteInst.SetVisible(true);
            dlblConfirmarProcesoClienteInst.SetText('Proceso Completado');
            //mtdVerOperacion(lsResult[1]);
            dppcConfirmarProcesoClienteInst.Hide();
            dlplLoadingInst.Hide();
            dgrvClientesInstance.PerformCallback();
            mtdAtrasCarga();


    //    }

    //} else {
    //    dlblConfirmarProcesoClienteInstError.SetVisible(true);
    //    dlblConfirmarProcesoClienteInstError.SetText(lsResult[1]);
    //}

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
