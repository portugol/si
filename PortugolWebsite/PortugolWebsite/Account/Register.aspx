<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PortugolWebsite.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <meta charset="utf-8" />
    <title>Registar</title>
    <script async="" src="http://connect.facebook.net/en_US/all.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css" />
    <link href="css/login.css" media="screen" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <br />
        <br />
        <h2 class="register-to">&nbsp; <asp:Literal ID="Literal11" Text="Registar" runat="server"></asp:Literal></h2>
        <asp:Literal ID="name" Text="Nome*:" runat="server"></asp:Literal>
        <asp:Literal ID="username" Text="Username*:" runat="server"></asp:Literal>
        <asp:Literal ID="password" Text="Password*:" runat="server"></asp:Literal>
    </div>
</asp:Content>
