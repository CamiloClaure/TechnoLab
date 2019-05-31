<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMaterial.aspx.cs" Inherits="TechnoLab.Presentacion.Reservas" %>

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
    <br />
    <br />
    <div class="container m-3"> 
    <form id="form1" runat="server">
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
    </form>
        </div>
</body>
</html>
