<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="createTopic.aspx.cs" Inherits="PortugolWebsite.Pages.Forum.createTopic" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <br /><br />

	<span id="messageCenter" EnableViewState="false" runat="server"/><p>
	
	<p>
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
			<a href="forum.aspx" class="menuitem">Forum Topics</a> &#062;
			<b>New Topic</b>		
		</td>
		
		<td height="15"></td>
	</tr>
	</table>

	<p>
	<table border="0" cellspacing="0" cellpadding="4">
	<tr>
		<td class="requiredField">
            <asp:Literal ID="litTitle" Text="Topic Title:" runat="server"></asp:Literal>
            <asp:RequiredFieldValidator id="reqTitle" ControlToValidate="txtTitle" ErrorMessage="Required field." display="static" runat="server">*</asp:RequiredFieldValidator></td>
		<td class="requiredField">
            <asp:TextBox id="txtTitle" Width="500px" maxlength="255" runat="server"/>
		</td>
	</tr>
	<tr>
		<td class="requiredField" valign="top">
            <asp:Literal ID="litDesc" Text="Topic description:" runat="server"></asp:Literal>
            <asp:RequiredFieldValidator id="reqDesc" ControlToValidate="txtDescritpion" ErrorMessage="Required field." display="static" runat="server">*</asp:RequiredFieldValidator>
		</td>
		<td class="requiredField">
            <asp:TextBox TextMode="MultiLine" id="txtDescritpion"  Width="500px" Height="100px" MaxLength="1000" runat="server"/>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:button id="submitter" name="submitter" text="Post Topic" OnClick="submitter_Click" runat="server" />
			<asp:button id="canceller" name="canceller" text="Cancel" CausesValidation="False" PostBackUrl="~/Pages/Forum/forum.aspx" runat="server" />
		</td>
	</tr>
	</table>



</asp:Content>

