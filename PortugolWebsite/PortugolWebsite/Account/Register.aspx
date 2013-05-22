<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PortugolWebsite.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <meta charset="utf-8" />
    <title>Registar</title>
    <script async="" src="http://connect.facebook.net/en_US/all.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css" />
    <link href="css/login.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="css/register.css" media="screen" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content"> 
        <br />
        <br />              
        <h2 class="register-to">&nbsp; <asp:Literal ID="Literal11" Text="Registar" runat="server"></asp:Literal></h2>
    </div>
        <!-- Register Tab Content -->
	<div id="FormContainer">
	
		
		<div id="signUp" class="toggleTab"> <!-- signUp -->
		
			<div class="cleanForm" class="clearfix toggleTab">				
					<p>
						<label for="full-name">Nome Completo: <span class="requiredField">*</span></label>
						<input type="text" id="Text1" name="full-name" value="" />
						<em>Introduza o nome completo.</em>
					</p>

					<p>
						<label for="username">Username: <span class="requiredField">*</span></label>
						<input type="text" id="Text2" name="username" value="" />
						<em>Caracteres compreendidos 3 a characters, letras ou numeros.</em>
					</p>					

					<p>
						<label for="email">Email : <span class="requiredField">*</span></label>
						<input type="email" id="email1" name="email" value="" />
						<em>Utilize o endereço de correio electrónico como. Exemplo.: aluno@portugol.com</em>
					</p>		
                
                     <p>
						<label for="password">Password: <span class="requiredField">*</span></label>
						<input type="password" id="password1" name="password" value="" />
						<em>Password compreendida 5 a 12 caracteres.</em>
					</p>		
                
                    <p>
						<label for="password">Confirmar Password: <span class="requiredField">*</span></label>
						<input type="password" id="password2" name="password" value="" /> <em>&nbsp;Repita novamente a password que foi preenchida no campo anterior.</em>
					</p>	
					
					<input type="submit" value="Registar" />
                    <br />
                    <br />
					<div class="formExtra">
						<p><strong>Nota: </strong>Preencha obrigatoriamente os campos assinalados com (*).</p>
					</div>				
			
			</div>
		
		</div> <!-- end signUp -->
		
				
	</div> <!-- end pageContainer -->            
</asp:Content>
