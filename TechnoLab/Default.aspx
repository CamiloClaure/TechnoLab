<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnoLab._Default" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/General/login.css" rel="stylesheet" type="text/css" />
    <link href="css/General/estiloInicio.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
  
    </head>
<body>
      <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery.min.js")%>"> </script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/bootstrap.min.js")%>"> </script>
    <center>
    <div class="row mx-auto">
			<div class="col-md-12 col-sm-12 col-xs-12 mx-auto">
		<div class="divEncabezado mx-auto"><img class="img-fluid mx-auto" src="Imagenes\logo500.png" >
			<hr>
			<h2 class="text-justify text-center" id="encabezado">Reservas de laboratorio de tecnología EMI - UASC</h2>

		</div>

			</div>
		</div>

		      </center>
		
    

    <div class="container-fluid">
		<div class="row justify-content mt-3">
			<div class="col-xs-4 col-sm-4 col-md-4 m-auto">

				<div class="shadow-lg p-2 mb-5 rounded " id="formContenido">
                    <div style="text-align:center" class="mx-auto">
                <div class="tittle_login"> Inicio de sesión </div>
                <div style="background-color:#1f4e79; height:3px; width:100%"></div>
            </div
		    		<div class="campo">
			    		<label>Código de usuario</label>
				    	<dx:ASPxTextBox runat="server" ID="txtUsuario" Text="S5899-8"
                            CssClass="form-control contenido" Width="100%">
                            <FocusedStyle CssClass="AccountNameFocused" />
                            <BackgroundImage ImageUrl="Img/Btn/Login.png" Repeat="NoRepeat"
                                HorizontalPosition="left" VerticalPosition="center" />
                            <ValidationSettings ErrorDisplayMode="Text" Display="Dynamic" ErrorTextPosition="Bottom"
                                SetFocusOnError="true" ErrorFrameStyle-CssClass="AccountNameError" ValidateOnLeave="false">
                                <RegularExpression ErrorText="Usuario Inválido" ValidationExpression="\w+" />
                                <RequiredField IsRequired="True" ErrorText="Ingrese un Usuario" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
					    <br>
					    <label>Contraseña</label>
					    <dx:ASPxTextBox ID="txtPassword" runat="server" Password="true" Text="123"
                            CssClass="form-control contenido">
                            <FocusedStyle CssClass="PasswordFocused" />
                            <BackgroundImage ImageUrl="Img/Btn/Password.png" Repeat="NoRepeat"
                                HorizontalPosition="left" VerticalPosition="center" />
                        </dx:ASPxTextBox>
					    <br>
					    <asp:Button ID="btnIngresar" runat="server" 
                            Text="Ingresar" CssClass="btn btn-primary mx-auto" OnClick="btnIngresar_Click"></asp:Button><br>
				    </div>
			    </div>
			</div>
            </div>
 </div>
</body>
</html>
</asp:Content>
