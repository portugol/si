<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PortugolWebsite.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <link href="css/alterarPass.css" media="screen" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:ChangePassword ID="AlterarPassword" runat="server">
        <ChangePasswordTemplate>
            <div class="content">

                <h2 class="register-to">&nbsp;
                    <asp:Literal ID="txtMudaPass" Text="Alterar a Password" runat="server"></asp:Literal></h2>
            </div>
            <!-- Register Tab Content -->
            <div id="FormContainer">


                <div id="signUp" class="toggleTab">
                    <!-- signUp -->

                    <div class="cleanForm" class="clearfix toggleTab">
                        <p>
                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword" Text="Password:"></asp:Label>

                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="É necessário uma password." ToolTip="É necessário uma password." ValidationGroup="ChangePasswordTESTE">*</asp:RequiredFieldValidator>

                        </p>
                        <p>
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword" Text="Nova Password:"></asp:Label>

                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="É necessário a nova password." ToolTip="É necessário a nova password." ValidationGroup="ChangePasswordTESTE">*</asp:RequiredFieldValidator>

                        </p>
                        <p>

                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword" Text="Confirmar nova Password:"></asp:Label>

                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="É necessário confirmar a nova Password." ToolTip="É necessário confirmar a nova Password." ValidationGroup="ChangePasswordTESTE">*</asp:RequiredFieldValidator>

                        </p>

                        <p>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="Os campos nova Password e confirmar nova Password não coincidem." ValidationGroup="ChangePasswordTESTE"></asp:CompareValidator>
                        </p>
                        <p>
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </p>
                        <p>
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Alterar Password" ValidationGroup="ChangePasswordTESTE" />

                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />

                        </p>
                    </div>
                </div>
            </div>


















        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
