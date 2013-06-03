<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Tutoriais.aspx.cs" Inherits="PortugolWebsite.Pages.Frontoffice.Tutoriais" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
	<div class="div-table">
        <div class="div-table-row">
            <div class="div-table-col" >
				<a href="Calculo.aspx">
					<img src="logos/calculo.png" style="position:relative;" />
				</a>
				<p>Cálculo</p>
			</div>
            <div class="div-table-col">
				<a href="#">
					<img src="logos/decisao.png" style="position:relative;" />
				</a>
				<p>Decisão</p>
			</div>
            <div class="div-table-col">
				<a href="#">
					<img src="logos/repitacao.png" style="position:relative;" />
				</a>
				<p>Repetição</p>
			</div>
        </div>
	</div>
	<div class="div-table">
        <div class="div-table-row">
            <div class="div-table-col">
				<a href="#">
					<img src="logos/arrays.png" style="position:relative;" />
				</a>
				<p>Arrays</p>
			</div>
            <div class="div-table-col">
				<a href="#">
					<img src="logos/funcoes.png" style="position:relative;" />
				</a>
				<p>Funções</p>
			</div>
		</div>
    </div>

</asp:Content>
