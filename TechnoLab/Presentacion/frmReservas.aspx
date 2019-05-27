<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReservas.aspx.cs" Inherits="TechnoLab.Presentacion.Reservas" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css"  />
    <link href="~/Content/Layout.css" rel="stylesheet" type="text/css"  />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
        </div>
    </form>
</body>
</html>
