<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="PortugolWebsite.Account.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
        <link href="css/register.css" media="screen" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content"> 
                         
        <h2 class="register-to">&nbsp;
             <asp:Literal ID="Literal11" Text="A minha conta" runat="server"></asp:Literal>
        </h2>
        <h4 class="register-to">&nbsp;
            <asp:HyperLink ID="linkChangePassword" Text="Alterar senha de identificação" NavigateUrl="~/Account/ChangePassword.aspx" runat="server"></asp:HyperLink>
        </h4>
    </div>
        <!-- Register Tab Content -->
	<div id="FormContainer">
	
		
		<div id="signUp"> <!-- signUp -->
		
			<div class="cleanForm">		
                
                <p>
                    <asp:Label ID="lblUsername" AssociatedControlID="txtUsername" Text="Username:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtUsername"  runat="server"></asp:TextBox>
				</p>
                		
				<p>
                    <asp:Label ID="lblName" AssociatedControlID="txtName" Text="Nome completo:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
				</p>

				<p>
                    <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" Text="Endereço de correio eletrónico:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
				</p>

				<p>
                    <asp:Label ID="lblIdioma" AssociatedControlID="ddlIdioma" Text="Idioma preferido:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:DropDownList ID="ddlIdioma" runat="server"></asp:DropDownList>
				</p>
                
               
					
                <asp:Button ID="btnSubmit" Text="Guardar" OnClick="btnSubmit_Click" runat="server" />
                <div class="formExtra">
					<p><strong>Nota: </strong>Os campos assinalados com (*) são de preenchimento obrigatório.</p>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
