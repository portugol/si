<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PortugolWebSite.Master" CodeBehind="Teste.aspx.cs" Inherits="PortugolWebsite.Pages.Teste" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Escolha o tipo de dificuldade do teste"></asp:Label>
    </p>
    <p>
        </p>


    <asp:RadioButtonList ID="rbCapitulo" runat="server" Width="139px" ></asp:RadioButtonList>
    <div>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Iniciar Teste" OnClick="Button1_Click" />

    </div>

</asp:Content>
