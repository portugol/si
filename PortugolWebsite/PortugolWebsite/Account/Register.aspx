<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PortugolWebsite.Account.Register" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    
    <title>Registar</title>
    <script async="" src="http://connect.facebook.net/en_US/all.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css" />
    <link href="css/register.css" media="screen" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content"> 
                         
        <h2 class="register-to">&nbsp; <asp:Literal ID="Literal11" Text="Registar" runat="server"></asp:Literal></h2>
    </div>
        <!-- Register Tab Content -->
	<div id="FormContainer">
	
		
		<div id="signUp"> <!-- signUp -->
		 <div id="DivMessages">
            <asp:Label ID="lblDuplicateEmail" Text="Cannot register. There's already an account with that email."  Visible="false" ForeColor="Red" EnableViewState="false" runat="server"></asp:Label>
            <asp:Label ID="lblDuplicateUserName" Text="Cannot register. There's already an account with that username."  Visible="false" ForeColor="Red" EnableViewState="false" runat="server"></asp:Label>
            <asp:Label ID="lblInvalidEmail" Text="Cannot register. Invalid E-mail format."  Visible="false" ForeColor="Red" EnableViewState="false" runat="server"></asp:Label>
            <asp:Label ID="lblInvalidPassword" Text="Cannot register. Invalid password format. Password must be at least 6 characters and must have at least 1 non alphanumeric character" ForeColor="Red"  Visible="false" EnableViewState="false" runat="server"></asp:Label>
            <asp:Label ID="lblProviderError" Text="Cannot register. <p>Application error.</p><p>Website administrators have been automatically notified of this problem.</p><p> Please try again later.</p>"  Visible="false" ForeColor="Red" EnableViewState="false" runat="server"></asp:Label>
            <%--<asp:Label ID="asdasd" Text='<%# Convert.ToString(Membership.Providers["CustomMembershipProvider"].MinRequiredPasswordLength) %>' runat="server"></asp:Label>--%>
        </div>
			<div class="cleanForm">				
				<p>
                    <asp:Label ID="lblName" AssociatedControlID="txtName" Text="Nome completo:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
					<em>Introduza o nome completo.</em>
				</p>

				<p>
                    <asp:Label ID="lblUsername" AssociatedControlID="txtUsername" Text="Username:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtUsername"  runat="server"></asp:TextBox>
					<em>Caracteres compreendidos 3 a 12, letras ou numeros.</em>
				</p>					

				<p>
                    <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" Text="Endereço de correio eletrónico:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
					<em>Utilize o endereço de correio electrónico como. Exemplo.: aluno@portugol.com</em>
				</p>
                
                <p>
                    <asp:Label ID="lblPassword" AssociatedControlID="txtPassword" Text="Senha de identificação:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server"></asp:TextBox>
					<em>Password com o mínimo cinco caracteres e no máximo vinte, em que um deles seja alfanumérico e um especial.</em>
				</p>		
                
                <p>
                    <asp:Label ID="lblConfirmPassword" AssociatedControlID="txtConfirmPassword" Text="Confirmar senha de identificação:" runat="server"></asp:Label>
                    <span class="requiredField">*</span>
                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
					<em>&nbsp;Repita novamente a password que foi preenchida no campo anterior.</em>
				</p>	
					
                <asp:Button ID="btnSubmit" Text="Registar" OnClick="btnSubmit_Click" runat="server" />
                <div class="formExtra">
					<p><strong>Nota: </strong>Preencha obrigatoriamente os campos assinalados com (*).</p>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
