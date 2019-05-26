<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnoLab._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid">
		<div class="row">
			<div class="col-md-12 col-sm-12 col-xs-12">
		<center><div align = "center" class="divEncabezado"><img class="img-fluid" src="Imagenes\logo500.png" >
			<hr>
			<h2 class="text-justify text-center" id="encabezado">Reservas de laboratorio de tecnología EMI - UASC</h2>

		</div></center>

			</div>
		</div>
		<br>
    <center>

			<div class="container-fluid">
				<div class="row justify-content">
					<div class="col-xs-4 col-sm-4 col-md-4 m-auto">
						<form class="shadow-lg p-3 mb-5 rounded " id="formContenido" margin = "5" padding = "5" action="inicioSesion.php" method="POST">
				<div class="campo">
					<label>Código de usuario</label>
					<input type="text" name="Usuario" placeholder="Usuario" class="form-control contenido">
					<br>
					<label>Contraseña</label>
					<input type="password" name="Contraseña" placeholder="Clave" class="form-control contenido">
					<br>
					<button class="btn btn-primary" onclick="goOficial()">Iniciar sesión</button><br>
				</div>
			</form>
					</div>
				</div>
			</div>
    </center>
		<br><br>

		<footer>
			<center>
				<div id="futer2">
					<h6 id="futer"><img src="Imagenes\mlogoemi.png" width="62">ESCUELA MILITAR DE INGENIERÍA</h6>
				</div>
			</center>

		</footer>

</asp:Content>
