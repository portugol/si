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
                  <p>
                    <label for="full-name">
                        "Nome Completo: "
                        <span class="requiredField">*</span>
                    </label>
                    <input type="text" id="full-name" class="required" />
                    <em>Introduza o seu nome completo.</em>
                </p>      
                 <p>
                    <label for="full-name">
                        "Username: "
                        <span class="requiredField">*</span>
                    </label>
                    <input type="text" id="Text1" class="required" />
                    <em>Introduza o seu username.</em>
                </p>      
                <p>
                    <label for="full-name">
                        "Email: "
                        <span class="requiredField">*</span>
                    </label>
                    <input type="text" id="Text2" class="required" />
                    <em>Introduza o seu endereço de correio electrónico.</em>
                </p>
                <p>
                    <label for="full-name">
                        "Password: "
                        <span class="requiredField">*</span>
                    </label>
                    <input type="password" id="Text3" class="required" />
                    <em>Introduza a sua senha de identificação.</em>
                </p>
                <p>
                    <label for="full-name">
                        "Confirmar Password: "
                        <span class="requiredField">*</span>
                    </label>
                    <input type="password" id="Password1" class="required" />
                    <em>Introduza novamente a sua senha de identificação.</em>
                </p>
                <asp:Button Text="Registar" runat="server" />
    </div>
</asp:Content>
