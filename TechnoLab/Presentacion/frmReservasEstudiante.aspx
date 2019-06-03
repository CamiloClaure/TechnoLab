<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReservasEstudiante.aspx.cs" Inherits="TechnoLab.Presentacion.frmReservasEstudiante" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/ctrlUsuario/wucReservas.ascx" TagPrefix="uc1" TagName="wucReservas" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Css/General/stsGeneral.css?<%=DateTime.Now.Ticks.ToString()%>" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css"  />
    
</head>
<body>
    <script type="text/javascript" src="~/Script/jsReservas.js"> </script>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
