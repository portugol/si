<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Calculo.aspx.cs" Inherits="PortugolWebsite.Pages.Calculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
	<div>
		<a href="Tutoriais.aspx"  title="Voltar">
             <!-- onClick="history.go(-1)"  FUNCIONA COMO O BACK DO NAVEGADOR-->
			<img src="/img/back.png" style="width:30px" />
		</a>
	</div>
    <ul>
	    <li>Introdução</li>
        <li><a href="javascript:openWin('emConstrucao.png')">Leitura de Dados</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Calculo</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Resto da Divisão</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Calculo com Reais</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Mix de Inteiros e Reais</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Conversor Graus para Radianos</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Seno em Radianos</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Seno em Graus</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Coseno</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Tangente</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Cotangente</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Potências</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Logaritmos</a></li>
        <li><a href="javascript:openWin('emConstrucao.png')">Exponêncial</a></li>
    </ul>
</>

<script type="text/javascript">
    //FUNÇÃO QUE ABRE JANELA POPUP "EM CONSTRUÇÃO"
    function openWin(img) {
        var path = "/img/";
        window.open(path + img, "mywin", "menubar=0,resizable=0,width=200,height=200");
    }
</script>


</asp:Content>
