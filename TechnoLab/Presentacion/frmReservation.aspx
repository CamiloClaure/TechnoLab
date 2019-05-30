<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmReservation.aspx.cs" Inherits="TechnoLab.Presentacion.frmReservation" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:BootstrapGridView ID="dgrvMateriales" runat="server" KeyFieldName="idMaterial" EnableRowsCache="False">
                <SettingsDataSecurity AllowEdit="true" AllowDelete="true" AllowInsert="true" />
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" />
                    <dx:BootstrapGridViewDataColumn FieldName="idMaterial" Visible="false"/>
                    <dx:BootstrapGridViewDataColumn FieldName="nombre" Caption="Nombre" />
                    <dx:BootstrapGridViewDataColumn FieldName="fechaCompra" Caption="Fecha de Compra"/>
                    <dx:BootstrapGridViewDateColumn FieldName="estado" Visible="false" />
                </Columns>
            </dx:BootstrapGridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
