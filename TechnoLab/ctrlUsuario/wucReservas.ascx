<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReservas.ascx.cs" Inherits="TechnoLab.ctrlUsuario.wucReservas" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/CtrlUsuario/General/wucConfirmarProcesoResponsive.ascx" TagPrefix="uc1" TagName="wucConfirmarProcesoResponsive" %>
<dx:BootstrapCallbackPanel ID="dcpnClientes" runat="server" ClientInstanceName="dcpnClientesInst" OnCallback="dcpnClientes_Callback">
    <ClientSideEvents EndCallback="dcpnClientes_EndCallback" />
    <ContentCollection>
        <dx:ContentControl>
             <dx:BootstrapFormLayout LayoutType="Horizontal"   runat="server">
                    <SettingsItemCaptions   HorizontalAlign="Left" Position="Before" />
                    <Items>
                         <dx:BootstrapLayoutGroup Caption="Datos del Cliente"  >
                           <Items>
                                <dx:BootstrapLayoutItem Caption="Cliente ID" ColSpanMd="6"  BeginRow="true" >
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapTextBox ID="dtxtClienteId"  ClientInstanceName="dtxtClienteIdInst" runat="server" 
                                                                ClientEnabled="false">
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapTextBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>

                                             <%--   <dx:BootstrapLayoutItem Caption="Fecha de registro" ColSpanMd="6"   >
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapDateEdit ID="dtxtFechaReg" 
                                                              ClientInstanceName="dtxtFechaRegInst" runat="server" NullText="Ingresar..." >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapDateEdit>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>--%>

                                                <dx:BootstrapLayoutItem Caption="Tipo empresa" ColSpanMd="6" >
                                                  <ContentCollection>
                                                
                                                      <dx:ContentControl>
                                                           <dx:BootstrapComboBox ID="dcboTipoEmpresa" ClientInstanceName="dcboTipoEmpresaInst" 
                                                                               runat="server" NullText="Seleccionar..." ValueType="System.Int32"  TextField="Descripcion" ValueField="TipoEmpresaId" >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapComboBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>

                                               <dx:BootstrapLayoutItem Caption="Nivel de riesgo" ColSpanMd="6" BeginRow="true"  >
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapComboBox ID="dcboNivelRiesgoId" ClientInstanceName="dcboNivelRiesgoIdInst" 
                                                                               runat="server" NullText="Seleccionar..." ValueType="System.String"  TextField="Descripcion" ValueField="NivelRiesgoId" >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapComboBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>


                               
                                                <dx:BootstrapLayoutItem Caption="Estado" ColSpanMd="6"  >
                                                  <ContentCollection>
                                                
                                                      <dx:ContentControl>
                                                           <dx:BootstrapComboBox ID="dcboEstado" ClientInstanceName="dcboEstadoInst" 
                                                                               runat="server" ClientEnabled="false" NullText="Seleccionar..." ValueType="System.String"  TextField="Descripcion" ValueField="EstadoClienteId" >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapComboBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>



                                            <dx:BootstrapLayoutItem Caption="Nombre completo" ColSpanMd="6" BeginRow="true">
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapTextBox ID="dtxtFullName" MaxLength="30" ClientInstanceName="dtxtFullNameInst" runat="server" 
                                                               NullText="Ingresar..." >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapTextBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>
                                              <dx:BootstrapLayoutItem Caption="Documento" ColSpanMd="6" >
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapTextBox ID="dtxtDocumento"  ClientInstanceName="dtxtDocumentoInst" runat="server" 
                                                              NullText="Ingresar..." >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapTextBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>
                                       
                                             <dx:BootstrapLayoutItem Caption="Telefono" ColSpanMd="6" BeginRow="true">
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapTextBox ID="dtxtTelefono"   ClientInstanceName="dtxtTelefonoInst" runat="server" 
                                                              NullText="Ingresar..." >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapTextBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem>
                                             <dx:BootstrapLayoutItem Caption="Direccion" ColSpanMd="6" >
                                                  <ContentCollection>
                                                      <dx:ContentControl>
                                                          <dx:BootstrapTextBox ID="dtxtDireccion"  ClientInstanceName="dtxtDireccionInst" runat="server" 
                                                              NullText="Ingresar..." >
                                                              <ValidationSettings>
                                                                  <RequiredField IsRequired="true" />
                                                              </ValidationSettings>
                                                          </dx:BootstrapTextBox>
                                                      </dx:ContentControl>
                                                  </ContentCollection>
                                              </dx:BootstrapLayoutItem></Items>
                       </dx:BootstrapLayoutGroup>
                  
                    </Items>


             </dx:BootstrapFormLayout>

            <dx:BootstrapTabControl ID="dtbcOperacionOperacion" ClientInstanceName="dtbcOperacionOperacionInst" runat="server" >
        <Tabs>
            <dx:BootstrapTab Name="idContactosCli" Text="Contactos"> </dx:BootstrapTab>
            <dx:BootstrapTab Name="idDocumentosCli" Text="Documentos"> </dx:BootstrapTab>          
        </Tabs>
        <ClientSideEvents ActiveTabChanged="dtbcDocumentosClientes_ActiveTabChanged" />
    </dx:BootstrapTabControl>
            <table id="idDocumentosClientes" width="90%" class="invi">
                <tr>
                    <td>
                        <dx:BootstrapGridView ID="dbgrvDocumentoCliente" ClientInstanceName="dbgrvDocumentoClienteInst" Width="100%"
                    OnRowInserting="dbgrvDocumentoCliente_RowInserting" runat="server" OnCellEditorInitialize="dbgrvDocumentoCliente_CellEditorInitialize"
                    OnCustomCallback="dbgrvDocumentoCliente_CustomCallback" OnRowUpdated="dbgrvDocumentoCliente_RowUpdated" OnRowDeleting="dbgrvDocumentoCliente_RowDeleting" KeyFieldName="DocumentoId" OnRowUpdating="dbgrvDocumentoCliente_RowUpdating">
                    <SettingsDataSecurity AllowEdit="true" AllowDelete="true" AllowInsert="false" />
                        
                 <Columns>

                  <dx:BootstrapGridViewCommandColumn Name="CommandColumn" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="false" />
                         
                     <dx:BootstrapGridViewTextColumn FieldName="ClienteId"  Caption="Id cliente" SettingsEditForm-Visible="False"/>
                         <dx:BootstrapGridViewComboBoxColumn FieldName="TipoDocumentoId">
                             <PropertiesComboBox TextField="Descripcion" ValueField="TipoDocumentoId" EnableSynchronization="False"
                              IncrementalFilteringMode="StartsWith">
                             </PropertiesComboBox>
                         </dx:BootstrapGridViewComboBoxColumn>
                      <dx:BootstrapGridViewTextColumn FieldName="DocumentoId" Visible="true"  SettingsEditForm-Visible="False"/>
                         <%--<dx:BootstrapGridViewDataColumn FieldName="DocumentoDesc"  Caption="Documento"  />--%>
                      <dx:BootstrapGridViewDataColumn FieldName="Descripcion"  Caption="Descripcion"  />
                      <dx:BootstrapGridViewDateColumn FieldName="FechaVencimiento"  Caption="Fecha de vencimiento"/>
                   
                 </Columns>
                </dx:BootstrapGridView>
                    </td>
                    <td>
                        <dx:BootstrapButton ID="dbtnClienteSeleccionar" Text="Seleccionar..." 
                        AutoPostBack="false"  CausesValidation="false" runat="server" >
                        <ClientSideEvents Click="mtdMostrarClientesWuc" /></dx:BootstrapButton>
                        <dx:BootstrapButton ID="dbtnSeleccionarCliente" Visible="false" ClientInstanceName="dbtnSeleccionarClienteInst" 
                        runat="server" Text="Aceptar" Width="120px"  >
                        <ClientSideEvents Click="dbtnSeleccionarCliente_Click" /></dx:BootstrapButton>
                    </td>
                </tr>
            </table>

            <dx:BootstrapPopupControl ID="dppcSeleccionarDocumento" ClientInstanceName="dppcSeleccionarDocumentoInst" 
                    HeaderText="Documentos" ShowHeader="true" CloseAction="CloseButton" 
                         Width="1000px"    runat="server" Modal="true" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="TopSides" AllowDragging="true" >
        <ContentCollection>
            <dx:ContentControl>

                   <table>
                                <tr>
                                   
                                    <td>
                                       
                                         <dx:ASPxUploadControl ID="dupdSubirArchivos"
                                           ClientInstanceName="dupdSubirArchivosInst"  runat="server"
                                            NullText="Subir documentos" UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                                          OnFileUploadComplete="dupdSubirArchivos_FileUploadComplete"
                                            >
                                           <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True" />
                                            <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".doc,.docx,.pdf,.png">
                                            </ValidationSettings>
                                            <ClientSideEvents FileUploadComplete="dupdSubirArchivos_FileUploadComplete"  />
                                        </dx:ASPxUploadControl>
                                        <dx:ASPxLabel runat="server" ID="dlblErrorSubir" ClientVisible="false" CssClass="alert alert-danger" ClientInstanceName="dlblErrorSubirInst" Text="Error, archivo ya existente!"></dx:ASPxLabel>
                                    </td>

                                </tr>

                            </table>

                
                
               

               <div> <br />  
                     </div>
               <div class="d-flex justify-content-center">
                               <div class="px-1">
                               
                                </div>
                                 <div class="px-1">
                                   <dx:BootstrapButton ID="dbtnCancelarWuc"  
                                       runat="server" Text="Cerrar" CausesValidation="false" 
                                          Width="120px"   AutoPostBack="false">
                                       <ClientSideEvents Click="function(s,e){ dppcSeleccionarDocumentoInst.Hide(); dlblErrorSubirInst.SetVisible(false); }" />
                                     </dx:BootstrapButton>
                                </div>
               </div>

                <dx:ASPxCallback ID="dcllWucClienteDocumento" ClientInstanceName="dcllWucClienteDocumentoInst" runat="server"
    OnCallback="dcllWucClienteDocumento_Callback" >
        <ClientSideEvents  CallbackComplete="dcllWucClienteDocumento_CallbackComplete" EndCallback="dcllWucClienteDocumento_EndCallback" />
</dx:ASPxCallback>


            </dx:ContentControl>
        </ContentCollection>
        
    </dx:BootstrapPopupControl>


          


            <div id="idContactoClientesGrid">

            <dx:ASPxGridView ID="dgrvContacto" ClientInstanceName="dgrvContactoInst" runat="server"
               width="100%"  OnCustomCallback="dgrvContacto_CustomCallback" OnRowValidating="dgrvContacto_RowValidating"
                 OnBatchUpdate="dgrvContacto_BatchUpdate" KeyFieldName="ContactoId" OnCellEditorInitialize="dgrvContacto_CellEditorInitialize">
        <SettingsEditing Mode="Batch" ></SettingsEditing>
        <Columns>
            <dx:GridViewCommandColumn Width="15%" Name="CommandColumn" ShowNewButtonInHeader="true" ShowNewButton="true" ShowDeleteButton="true" ShowEditButton="true" />
            <dx:GridViewDataColumn FieldName="ContactoId" Visible="false" Caption="Id" />
            <dx:GridViewDataColumn FieldName="Nombre" Caption="Nombre" />
            <dx:GridViewDataColumn FieldName="Cargo" Caption="Cargo" />
            <dx:GridViewDataColumn FieldName="Area" Caption="Area" />
            <dx:GridViewDataColumn FieldName="Telefono" Caption="Telefono" />
            <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" >
             <%-- <PropertiesTextEdit>
                  
                 <MaskSettings  Mask="*@*.*" />
              </PropertiesTextEdit>--%>
        
            </dx:GridViewDataTextColumn>
</Columns>
       <Settings ShowFooter="true" />
            <SettingsPager PageSize="15 ">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>

</dx:ASPxGridView>

            </div>


        </dx:ContentControl>
    </ContentCollection>
</dx:BootstrapCallbackPanel>





<div class="d-flex justify-content-center">
                              <div class="px-1">
                                  <dx:ASPxButton ID="dbtnGuardarX" ClientInstanceName="dbtnGuardarXInst" runat="server" Text="Guardar" 
                                          Width="120px"   AutoPostBack="false" >
                                      <Image Url="../../Img/Btn/guardar.png" ></Image>
                                            <ClientSideEvents Click="mtdGuardarNuevoCliente" />
                                  </dx:ASPxButton>
                              </div>
</div>

<uc1:wucConfirmarProcesoResponsive runat="server" id="wucConfirmarProcesoCliente"   
        prdPopUp_ClientInstanceName="dppcConfirmarProcesoClienteInst"
        prdBotonAceptar_ClientInstanceName="dbtnConfirmarProcesoClienteInst"
        prdLabelMensajeProcesoCompleto_ClientInstanceName="dlblConfirmarProcesoClienteInst"
        prdLabelMensajeProcesoCompleto_ClientInstanceNameError="dlblConfirmarProcesoClienteInstError"
        prdAceptarMetodoJs="mtdGuardarWucCliente();" />

<dx:ASPxCallback ID="dcllWucClientes" ClientInstanceName="dcllWucClientesInst" runat="server"
    OnCallback="dcllWucClientes_Callback" >
        <ClientSideEvents  CallbackComplete="dcllWucClientes_CallbackComplete" EndCallback="dcllWucClientes_EndCallback" />
</dx:ASPxCallback>

<dx:ASPxHiddenField ID="dhddClienteWuc" ClientInstanceName="dhddClienteWucInst" runat="server" >

</dx:ASPxHiddenField>