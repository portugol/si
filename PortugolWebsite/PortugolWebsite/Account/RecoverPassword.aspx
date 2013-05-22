<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="PortugolWebsite.Account.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divRecoverPasswordBox">
        <div style="padding:30px 0px;">
            <div style="margin-left:20px; float: left;">
                <asp:Label ID="lblRecoverPassword" Text="Forgot your password?" Font-Bold="true" Font-Size="32px" runat="server"></asp:Label>
            </div>
            <div style="margin-right:20px; float: right;">
                <asp:Label ID="lblLoginAccount" Text="Already have an account?" runat="server"></asp:Label>&nbsp;
                <asp:HyperLink ID="hlinkLoginAccount" NavigateUrl="~/Account/Login.aspx" runat="server">Login here</asp:HyperLink>
            </div>
        </div>

        <div id="DivMessages" >
            <asp:Label ID="LblInfoMessage" Text="For security reasons, password retrieval is not enable on this web site. Enter the username, or the email address, for your account and we'll send you a new password to your email box"  runat="server"></asp:Label>
        </div>

        <div id="DivSeparator">
            <!--This is line seperator -->
        </div>

        <div>
            <asp:Label ID="lblUsername" Text="Username" runat="server"></asp:Label>&nbsp;
        </div>
        <div>
            <asp:TextBox ID="txtUsername"  runat="server"></asp:TextBox>
        </div>
        

        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Enter the username, or the email address, for your account and we'll send you a new password." ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
        </div>
      
        <div style="margin-right:55px; padding:6px 0px; text-align:right">
            <asp:Button ID="btnSubmit" Text="Continue" runat="server" OnClick="btnSubmit_Click"  />
        </div>    
    </div>
</asp:Content>
