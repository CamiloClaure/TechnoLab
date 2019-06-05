<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmHistorialAprobado.aspx.cs" Inherits="TechnoLab.Presentacion.frmHistorialAprovado" %>
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
                <dx:BootstrapGridView id="dgrvHistorialApro" runat="server" keyfieldname="Id"
                    OnRowUpdating="dgrvHistorialApro_RowUpdating">
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" />
                <SettingsDataSecurity AllowEdit="true"/>
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowEditButton="true"/>
                    <dx:BootstrapGridViewDataColumn FieldName="Id" Visible="false"/>
                    <dx:BootstrapGridViewComboBoxColumn FieldName="IdEstudiante" Caption="Estudiante" ReadOnly="true" 
                        PropertiesComboBox-ValueField="prdId" PropertiesComboBox-TextField="prdDescripcion"/>
                    <dx:BootstrapGridViewTextColumn FieldName="CodReserva" Caption="Codigo" ReadOnly="true"/>
                    <dx:BootstrapGridViewComboBoxColumn FieldName="IdMateria" Caption="Materia" ReadOnly="true"
                        PropertiesComboBox-ValueField="prdId" PropertiesComboBox-TextField="prdDescripcion"/>
                    <dx:BootstrapGridViewComboBoxColumn FieldName="Estado" Caption="Estado"
                        PropertiesComboBox-ValueField="prdId" PropertiesComboBox-TextField="prdDescripcion"/>
                    <dx:BootstrapGridViewDateColumn FieldName="FechaInicio" Caption="Fecha Inicio" ReadOnly="true"/>
                  <dx:BootstrapGridViewTimeEditColumn FieldName="FechaInicio" Caption="Hora Inicio" ReadOnly="true"/>
                    <dx:BootstrapGridViewDateColumn FieldName="FechaFin" Caption="Fecha Fin" ReadOnly="true"/>
                    <dx:BootstrapGridViewTimeEditColumn FieldName="FechaFin" Caption="Hora Fin" ReadOnly="true"/>

                    
                    
                    
                    
                </Columns>
            </dx:BootstrapGridView>
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
