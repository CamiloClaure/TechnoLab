<%@ Page Title="TechnoLab" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnoLab._Default" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/General/login.css" rel="stylesheet" type="text/css" />
  
    </head>
<body>
      <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery.min.js")%>"> </script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/bootstrap.min.js")%>"> </script>
       <div id="LogonContainer" class="LogonContainer center shadow1">
      
            <div style="text-align:center">
                <div class="tittle_login"> Inicio de sesión </div>
                <div style="background-color:#1f4e79; height:4px; width:100%"></div>
            </div>

            <br />  <br />

       

            <div class="card-body text-dark div_padding">
                <div class="row">
                    <div class="col">
                        <dx:ASPxTextBox runat="server" ID="txtUsuario" Text="integgre"
                            CssClass="AccountNameTextBox" Width="100%">
                            <FocusedStyle CssClass="AccountNameFocused" />
                            <BackgroundImage ImageUrl="Img/Btn/Login.png" Repeat="NoRepeat"
                                HorizontalPosition="left" VerticalPosition="center" />
                            <ValidationSettings ErrorDisplayMode="Text" Display="Dynamic" ErrorTextPosition="Bottom"
                                SetFocusOnError="true" ErrorFrameStyle-CssClass="AccountNameError" ValidateOnLeave="false">
                                <RegularExpression ErrorText="Usuario Inválido" ValidationExpression="\w+" />
                                <RequiredField IsRequired="True" ErrorText="Ingrese un Usuario" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </div>
                </div>
                <br />  
                <div class="row">
                    <div class="col">
                        <dx:ASPxTextBox ID="txtPassword" runat="server" Password="true" Text="123"
                            CssClass="UserPasswordTextBox">
                            <FocusedStyle CssClass="PasswordFocused" />
                            <BackgroundImage ImageUrl="Img/Btn/Password.png" Repeat="NoRepeat"
                                HorizontalPosition="left" VerticalPosition="center" />
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ForeColor="White"
                            ErrorMessage="Debe ingresar una contraseña" CssClass="errorLabels">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:RequiredFieldValidator runat="server" ID="rfvUsuario" ControlToValidate="txtUsuario" ForeColor="White"
                            ErrorMessage="Debe ingresar un usuario" CssClass="errorLabels">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="col" style="text-align:center;">
                        <asp:Button ID="btnIngresar" runat="server" BackColor="#1f4e79"
                            Text="Ingresar" CssClass="SignInButton" OnClick="btnIngresar_Click"></asp:Button>
                    </div>
                </div>

                

                <div class="row">
                    <div class="col">
                        <asp:RequiredFieldValidator ID="rfvError" runat="server" ControlToValidate="txtError"
                            ForeColor="DarkOrange">&nbsp;</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtError" runat="server" Width="1px" Visible="false" Text="a"></asp:TextBox>
                        <dx:ASPxLabel ForeColor="Black" runat="server" ID="ErrorLabel" Text="" Visible="false" />
                    </div>
                </div>

            </div>
    
    </div>
 
 
</body>
</html>
</asp:Content>
