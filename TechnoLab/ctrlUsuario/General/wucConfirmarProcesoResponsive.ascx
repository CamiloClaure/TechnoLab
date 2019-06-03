<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucConfirmarProcesoResponsive.ascx.cs" Inherits="webGeneric.CtrlUsuario.General.wucConfirmarProcesoResponsive" %>



<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<dx:BootstrapPopupControl  ID="dppcConfirmarProcesoResponsive" HeaderText="Confirmación de Proceso" 
        runat="server"   Width="580px" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Modal="true" CloseAction="CloseButton"  AllowDragging="true">
    <ContentCollection>
            <dx:ContentControl >

                <div class="container" >
                    <dx:ASPxLabel ID="dlblMsgEAcConfirmacion"  
				            runat="server" Font-Size="Medium" CssClass="cMarrom" Text= "¿Está seguro de continuar con el proceso?" >
			        </dx:ASPxLabel>
			        <br />
                    <div class="br"></div>

                    <div class="d-flex justify-content-center">

                        <div class="px-1">
                            <dx:BootstrapButton ID="dbtnConrfimarProcesoGenericoOK"    CausesValidation="False"
							runat="server" Text="Aceptar" AutoPostBack="false" >
                                <SettingsBootstrap RenderOption="Primary" />
                            </dx:BootstrapButton>
                        </div>
                          
                       <div class="px-1">
                             <dx:BootstrapButton ID="dbtnConrfimarProcesoGenericoNOK" CausesValidation="False"  
							    runat="server" Text="Cancelar" AutoPostBack="false"  >
                                <SettingsBootstrap RenderOption="Primary" />
                            </dx:BootstrapButton>
                       </div>

                    </div>
                      
                     <div class="br"></div>

                  
                     <dx:ASPxLabel ID="dlblMensajeGenericoOK" ClientVisible="false"  Width="100%" CssClass="alert alert-success"   runat="server"  
                         Text="LOREM"   > 
                     </dx:ASPxLabel>
                    <dx:ASPxLabel ID="dlblMensajeGenericoNOK" ClientVisible="false"  Width="100%" CssClass="alert alert-danger"   runat="server"  
                         Text="LOREM"   > 
                     </dx:ASPxLabel>
                    <dx:ASPxLabel ID="dlblMensajeGenericoInfo" ClientVisible="false"  Width="100%" CssClass="alert alert-primary"   runat="server"  
                         Text="LOREM"   > 
                     </dx:ASPxLabel>
             

                      <div id="idContenedorMensaje"  runat="server" >
                            
                        </div>  
                </div>


            </dx:ContentControl>
        </ContentCollection>
</dx:BootstrapPopupControl>
