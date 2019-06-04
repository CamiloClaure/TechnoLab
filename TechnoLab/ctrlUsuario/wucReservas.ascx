<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReservas.ascx.cs" Inherits="TechnoLab.ctrlUsuario.wucReservas" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/CtrlUsuario/General/wucConfirmarProcesoResponsive.ascx" TagPrefix="uc1" TagName="wucConfirmarProcesoResponsive" %>

<dx:BootstrapCallbackPanel ID="dcpnEstudiantes" runat="server" ClientInstanceName="dcpnEstudiantesInst" OnCallback="dcpnEstudiantes_Callback">
    <ClientSideEvents EndCallback="dcpnEstudiantes_EndCallback" />
    <ContentCollection>
        <dx:ContentControl>
            <dx:BootstrapFormLayout LayoutType="Horizontal" runat="server">
                <SettingsItemCaptions HorizontalAlign="Left" Position="Before" />
                <Items>
                    <dx:BootstrapLayoutGroup Caption="Datos del Estudiante">
                        <Items>
                            <dx:BootstrapLayoutItem Caption="Código" ColSpanMd="6" BeginRow="true">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="dtxtCodigoEstudiante" ClientInstanceName="dtxtCodigoEstudianteInst" runat="server"
                                            ClientEnabled="false">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Fecha de Inicio" ColSpanMd="6">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapDateEdit ID="dtxtFechaInicio"
                                            ClientInstanceName="dtxtFechaRegInst" runat="server" NullText="Ingresar...">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapDateEdit>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Fecha de Devolución" ColSpanMd="6">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapDateEdit ID="dtxtFechaFin"
                                            ClientInstanceName="dtxtFechaRegInst" runat="server" NullText="Ingresar...">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapDateEdit>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Materia" ColSpanMd="6">
                                <ContentCollection>

                                    <dx:ContentControl>
                                        <dx:BootstrapComboBox ID="dcboMateria" ClientInstanceName="dcboMateriaInst"
                                            runat="server" NullText="Seleccionar..." ValueType="System.Int32" TextField="Nombre" ValueField="IdMateria">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapComboBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>




                        </Items>
                    </dx:BootstrapLayoutGroup>

                </Items>


            </dx:BootstrapFormLayout>


            <div id="idContactoClientesGrid">

      
                <%-- <dx:BootstrapGridView runat="server" on
                    ID="dgrvMaterial" ClientInstanceName="dgrvMaterialInst" KeyFieldName="Codigo">
                    <SettingsEditing Mode="Batch" ></SettingsEditing>
                    
                    <Columns>
                        <dx:BootstrapGridViewCommandColumn ShowNewButton="true"/>
                        <dx:BootstrapGridViewDataColumn FieldName="Codigo" Visible="false" />
                        <dx:BootstrapGridViewComboBoxColumn FieldName="CodigoCategoria" Caption="Categoria" PropertiesComboBox-ValueField="Id" PropertiesComboBox-TextField="Descripcion"/>
                    </Columns>
                </dx:BootstrapGridView>--%>
            </div>

            <div>
               
                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server"
                    KeyFieldName="Codigo" Width="100%" AutoGenerateColumns="false" OnCellEditorInitialize="grid_CellEditorInitialize" OnRowInserting="grid_RowInserting">
                    <Settings ShowGroupPanel="true" />
                    <SettingsEditing Mode="Inline" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="true" ShowNewButton="true" />

                        <%--<dx:GridViewDataComboBoxColumn FieldName="Codigo" Width="150">
                            <PropertiesComboBox  TextField="Nombre" ValueField="CodMaterial">
                               
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>--%>
                        <dx:GridViewDataColumn FieldName="Codigo" />
                        <dx:GridViewDataColumn FieldName="Nombre" />
                        <dx:GridViewDataColumn FieldName="Cantidad" />
                        
                    </Columns>
                </dx:ASPxGridView>
            </div>

            <dx:BootstrapPopupControl ID="dppcSeleccionarDocumento" ClientInstanceName="dppcSeleccionarDocumentoInst"
                HeaderText="Documentos" ShowHeader="true" CloseAction="CloseButton"
                Width="1000px" runat="server" Modal="true" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="TopSides" AllowDragging="true">
                <ContentCollection>
                    <dx:ContentControl>

                        <table>
                            <tr>

                                <td>hola mundo
                                </td>

                            </tr>

                        </table>





                        <div>
                            <br />
                        </div>
                        <div class="d-flex justify-content-center">
                            <div class="px-1">
                            </div>
                            <div class="px-1">
                                <dx:BootstrapButton ID="dbtnCancelarWuc"
                                    runat="server" Text="Cerrar" CausesValidation="false"
                                    Width="120px" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s,e){ dppcSeleccionarDocumentoInst.Hide(); dlblErrorSubirInst.SetVisible(false); }" />
                                </dx:BootstrapButton>
                            </div>
                        </div>

                        <dx:ASPxCallback ID="dcllWucClienteDocumento" ClientInstanceName="dcllWucClienteDocumentoInst" runat="server"
                            OnCallback="dcllWucClienteDocumento_Callback">
                            <ClientSideEvents CallbackComplete="dcllWucClienteDocumento_CallbackComplete" EndCallback="dcllWucClienteDocumento_EndCallback" />
                        </dx:ASPxCallback>


                    </dx:ContentControl>
                </ContentCollection>

            </dx:BootstrapPopupControl>





        </dx:ContentControl>
    </ContentCollection>
</dx:BootstrapCallbackPanel>





<div class="d-flex justify-content-center">
    <div class="px-1">
        <dx:ASPxButton ID="dbtnGuardarX" ClientInstanceName="dbtnGuardarXInst" runat="server" Text="Guardar"
            Width="120px" AutoPostBack="false">
            <%-- <Image Url="../../Img/Btn/guardar.png" ></Image>--%>
            <ClientSideEvents Click="mtdGuardarNuevoCliente" />
        </dx:ASPxButton>
    </div>
</div>

<uc1:wucConfirmarProcesoResponsive runat="server" ID="wucConfirmarProcesoCliente"
    prdPopUp_ClientInstanceName="dppcConfirmarProcesoClienteInst"
    prdBotonAceptar_ClientInstanceName="dbtnConfirmarProcesoClienteInst"
    prdLabelMensajeProcesoCompleto_ClientInstanceName="dlblConfirmarProcesoClienteInst"
    prdLabelMensajeProcesoCompleto_ClientInstanceNameError="dlblConfirmarProcesoClienteInstError"
    prdAceptarMetodoJs="mtdGuardarWucCliente();" />

<dx:ASPxCallback ID="dcllWucClientes" ClientInstanceName="dcllWucClientesInst" runat="server"
    OnCallback="dcllWucClientes_Callback">
    <ClientSideEvents CallbackComplete="dcllWucClientes_CallbackComplete" EndCallback="dcllWucClientes_EndCallback" />
</dx:ASPxCallback>

<dx:ASPxHiddenField ID="dhddClienteWuc" ClientInstanceName="dhddClienteWucInst" runat="server">
</dx:ASPxHiddenField>
