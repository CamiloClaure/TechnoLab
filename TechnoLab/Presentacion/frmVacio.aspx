<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmVacio.aspx.cs" Inherits="TechnoLab.Presentacion.frmVacio" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/ctrlUsuario/wucReservas.ascx" TagPrefix="uc1" TagName="wucReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Script/jsReservas.js")%>?<%=DateTime.Now.Ticks.ToString()%>"> </script>
    <div class="divContainer">

        <div id="divPrincipal">
            <div class="borderBotom">
                <dx:ASPxLabel ID="dlblTitleForm" runat="server" Text="Clientes" Font-Size="Large" Font-Bold="true" CssClass="ThemeColor">
                </dx:ASPxLabel>
            </div>
            <div>
                <br />
            </div>
            <div id="idOpeNewHist">
                <dx:BootstrapButton ID="dbtnNuevaOperacionAlta" runat="server" CausesValidation="false"
                    Text="Nueva Reserva" AutoPostBack="false">
                    <ClientSideEvents Click="mtdMostrarNuevo" />
                </dx:BootstrapButton>
            </div>


            <div>
                <br />
            </div>
            <dx:ASPxGridView ID="dgrvClientesX" ClientInstanceName="dgrvClientesInstance" runat="server" OnCustomCallback="dgrvClientes_CustomCallback">
                <Columns>
                    <dx:GridViewDataColumn>
                        <DataItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <div onclick="mtdMostrarCliente(<%#Eval("ClienteId")%>);" class="icoBtnVer"></div>
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
                                        <div onclick="mtdMostrarEditar(<%#Eval("ClienteId")%>);" class="icoBtnEditar"></div>
                                    </td>
                                </tr>
                            </table>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>



                    <dx:GridViewDataColumn FieldName="FechaI" Caption="Fecha Inicio" />
                    <dx:GridViewDataColumn FieldName="FechaF" Caption="Fecha Fin" />
                    <dx:GridViewDataColumn FieldName="IdEstudiante" Visible="false" Caption="Id Estudiante" />
                    <dx:GridViewDataColumn FieldName="IdEncargado" Caption="Id Encargado" />
                    <dx:GridViewDataColumn FieldName="CodReserva" Visible="false" Caption="Cod. Reserva" />
                    <dx:GridViewDataColumn FieldName="IdMateria" Caption="Id materia" />
                    
                </Columns>
                <SettingsPager PageSize="30">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>
                <Settings ShowColumnHeaders="true" />
                <SettingsSearchPanel ShowApplyButton="true" ShowClearButton="true" Visible="true" HighlightResults="true" />

            </dx:ASPxGridView>
        </div>
        <div id="idCargaDatos">

            <dx:ASPxPanel ID="dpnlCargaDatos" ClientInstanceName="dpnlCargaDatosInst"
                runat="server"
                ClientVisible="false">
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:BootstrapButton ID="dbtnBack" runat="server" Text="<- Volver" AutoPostBack="false"
                            CausesValidation="false">
                            <ClientSideEvents Click="mtdAtrasCarga" />
                        </dx:BootstrapButton>

                        <uc1:wucReservas runat="server" ID="wucReservas" />

                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxPanel>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
