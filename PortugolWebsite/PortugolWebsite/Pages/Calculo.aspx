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
    <div style="width:100%; border: 1px solid blue; display:inline-block; ">
        <div style="float: left; border: 1px solid red; ">
            <ul>
	            <li><a href="/Videos/Introducao.avi">Introdução</a></li>
                <li><a href="javascript:openWin('emConstrucao.png')">Leitura de Dados</a></li>
                <li><a href="/Videos/Calculo/Calculo.avi">Calculo</a></li>
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
        </div>
        <div style="float: left;">
           
             VIDEO GOES HERE
            <%--<video width="320" height="240" controls>
              <source src="../Videos/Introducao.avi" type="video/mp4" />
                    Your browser does not support the video tag.
            </video> --%>
            Converter o video

        </div>
    </div>


    <script type="text/javascript">
        //FUNÇÃO QUE ABRE JANELA POPUP "EM CONSTRUÇÃO"
        function openWin(img) {
            var path = "/img/";
            window.open(path + img, "mywin", "menubar=0,resizable=0,width=200,height=200");
        }
    </script>

</asp:Content>
