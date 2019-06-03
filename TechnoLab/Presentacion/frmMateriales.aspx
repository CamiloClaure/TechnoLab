<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMateriales.aspx.cs" Inherits="TechnoLab.Presentacion.frmMateriales" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container m-3"> 
        <div>
            <br />
            <br />
            <br />
            <dx:BootstrapGridView ID="dgrvMateriales" runat="server" KeyFieldName="Codigo" 
                OnRowInserting="dgrvMateriales_RowInserting"
                OnRowUpdating="dgrvMateriales_RowUpdating"
                OnRowDeleting="dgrvMateriales_RowDeleting">
                <SettingsDataSecurity AllowEdit="true" AllowDelete="true" AllowInsert="true"/>
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButton="true"/>
                    <dx:BootstrapGridViewDataColumn FieldName="Codigo" Visible="false"/>
                    <dx:BootstrapGridViewTextColumn FieldName="CodMaterial" Caption="Codigo"/>
                    <dx:BootstrapGridViewTextColumn FieldName="Descripcion" Caption="Descripcion" />
                    <dx:BootstrapGridViewTextColumn FieldName="Nombre" Caption="Nombre"/>
                    <dx:BootstrapGridViewDateColumn FieldName="FechaCompra" Caption="Fecha de Compra"/>
                    <dx:BootstrapGridViewTextColumn FieldName="Estado" Caption="Estado"/>
                    <dx:BootstrapGridViewTextColumn FieldName="Ubicacion" Caption="Ubicacion"/>
                    <dx:BootstrapGridViewTextColumn FieldName="CodCategoria" Caption="Categoria"/>
                     <dx:BootstrapGridViewTextColumn FieldName="Cantidad" Caption="Cantidad"/>
                    <dx:BootstrapGridViewTextColumn FieldName="Activo" Visible="false"/>
                </Columns>
            </dx:BootstrapGridView>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
