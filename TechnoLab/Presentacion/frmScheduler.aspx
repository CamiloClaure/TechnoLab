<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmScheduler.aspx.cs" Inherits="TechnoLab.Presentacion.frmScheduler" %>

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
            <dx:BootstrapScheduler runat="server" ID="schdTimeline" GroupType="Resource" ActiveViewType="Timeline" Start="">
        <OptionsEditing AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentCopy="None" AllowAppointmentDragBetweenResources="None" />
        <OptionsAppearance DefaultAppointmentColorsMode="Bootstrap">
        </OptionsAppearance>
        <OptionsResourceNavigator EnableIncreaseDecrease="false" />
        <Storage>
            <Appointments>
                <Mappings AppointmentId="ID" Subject="Descripcion" Description="Descripcion2" Start="Start" End="End" ResourceId="Doctor" Label="Labels" Status="Status" />
                <Labels>
                    <dx:BootstrapAppointmentLabel Text="None"
                        BackgroundCssClass="bg-light" TextCssClass="text-dark"></dx:BootstrapAppointmentLabel>
                    <dx:BootstrapAppointmentLabel Text="Routine"
                        BackgroundCssClass="bg-primary" TextCssClass="text-white"></dx:BootstrapAppointmentLabel>
                    <dx:BootstrapAppointmentLabel Text="Follow-Up"
                        BackgroundCssClass="bg-success" TextCssClass="text-white"></dx:BootstrapAppointmentLabel>
                    <dx:BootstrapAppointmentLabel Text="Urgent"
                        BackgroundCssClass="bg-danger" TextCssClass="text-white"></dx:BootstrapAppointmentLabel>
                    <dx:BootstrapAppointmentLabel Text="Lab Testing"
                        BackgroundCssClass="bg-warning" TextCssClass="text-dark"></dx:BootstrapAppointmentLabel>
                    <dx:BootstrapAppointmentLabel Text="Service"
                        BackgroundCssClass="bg-secondary" TextCssClass="text-white"></dx:BootstrapAppointmentLabel>
                </Labels>
                <Statuses>
                    <dx:BootstrapAppointmentStatus Text="NotSet"
                        Type="Custom" CssClass="bg-white"></dx:BootstrapAppointmentStatus>
                    <dx:BootstrapAppointmentStatus Text="Confirmed"
                        Type="Custom" CssClass="bg-success"></dx:BootstrapAppointmentStatus>
                    <dx:BootstrapAppointmentStatus Text="Awaiting Confirmation"
                        Type="Custom" CssClass="bg-danger"></dx:BootstrapAppointmentStatus>
                    <dx:BootstrapAppointmentStatus Text="Cancelled"
                        Type="Custom" CssClass="bg-secondary"></dx:BootstrapAppointmentStatus>
                </Statuses>
                <CustomFieldMappings>
                   
                </CustomFieldMappings>
            </Appointments>

            <Resources>
                <Mappings ResourceId="Doctor" Caption="Doctor" />
            </Resources>
        </Storage>

        <Views>
            <TimelineView ResourcesPerPage="1" IntervalCount="5">
                <Scales>
                  
                </Scales>
            </TimelineView>
            <DayView Enabled="true" />
            <WorkWeekView Enabled="false" />
            <WeekView Enabled="false" />
            <MonthView Enabled="false" />
            <AgendaView Enabled="false" />
        </Views>
    </dx:BootstrapScheduler>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="chpBody" runat="server">
</asp:Content>
