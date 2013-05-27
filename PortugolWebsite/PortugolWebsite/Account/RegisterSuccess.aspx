<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="RegisterSuccess.aspx.cs" Inherits="PortugolWebsite.Account.RegisterSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div id="divRegisterSuccess">
            <div style="padding:30px 0px;">
                <div style="margin-left:20px; float: left;">
                    <asp:Label ID="lblLogin" Text="Registration successful" Font-Bold="true" Font-Size="32px" runat="server"></asp:Label>
                </div>
                <div style="margin-right:20px; float: right;">
                                
                </div>
            </div>

            <div id="DivSeparator" class="separator">
                <!--This is line seperator -->
            </div>

            <div class="divbox">
                <p><asp:Label ID="Label1" Text="Registo efectuado com sucesso." Font-Bold="true" Font-Size="16px"  runat="server"></asp:Label></p>
                <asp:Label ID="LblSuccess" Text="Agora pode-se " Font-Bold="true" Font-Size="16px"  runat="server"></asp:Label>
                <asp:HyperLink ID="hlinkCreateAccount" NavigateUrl="/Account/Login.aspx" Text="Autenticar " Font-Size="16px" runat="server"></asp:HyperLink>
                <asp:Label ID="LblSuccess2" Text=" no website com a sua conta." Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
            </div>
        </div> 
</asp:Content>
