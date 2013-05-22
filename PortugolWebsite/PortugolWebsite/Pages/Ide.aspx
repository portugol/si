<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Ide.aspx.cs" Inherits="PortugolWebsite.Pages.Frontoffice.Ide" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">
    
    <meta charset="utf-8" />
	<link rel="stylesheet" href="../../css/IdeStyle.css" type="text/css" media="screen" />
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script> 
	<!-- <script src="javascript_IDE/jquery.min.js"></script> -->
	<script src="http://localhost:8080/socket.io/socket.io.js"></script>
    
	<script src="../../javascript_IDE/raphael-min.js"></script>
	<script src="../../javascript_IDE/connection.js"></script>
	<script src="../../javascript_IDE/node.js"></script>
	<script src="../../javascript_IDE/nodev.js"></script>
	<script src="../../javascript_IDE/graph.js"></script>
	<script src="../../javascript_IDE/editor.js"></script>

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />

		<div id="pallete">
			<a id="btninicio">Inicio</a><br />
			<a id="btnescrever">Escrever</a><br />
			<a id="btnfim">Fim</a><br>
			<a id="btnvalidar">Validar</a><br />
			<a id="btnexecute">Executar</a><br />
		</div>
		<div id="paper">
		</div>
		<div id="console">
            OUTPUT:<br /> 
		</div>


</asp:Content>
