<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="postReply.aspx.cs" Inherits="PortugolWebsite.Pages.Forum.postReply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hiddenTopicId" runat="server" />
    <asp:HiddenField ID="hiddenRecordID" runat="server" />

	<span id="messageCenter" EnableViewState="false" runat="server"/><p>
	
	<p>
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
			<a class="menuitem" href="forum.aspx">Forum Topics</a> &#062;
			<asp:HyperLink id="topicLink" NavigateUrl="topicView.aspx" CssClass="menuitem" runat="server" /> &#062;
			<b>New Reply</b>		
		</td>
		
		<td height="15"></td>
	</tr>
	</table>

	<p>
	<table border="0" cellspacing="0" cellpadding="4">
	<tr>
		<td class="requiredField">Subject: 
            <asp:RequiredFieldValidator id="reqSubject" ControlToValidate="psSubject" ErrorMessage="The Subject Field is required." display="static" runat="server">*</asp:RequiredFieldValidator></td>
		<td class="requiredField">
            <asp:TextBox id="txtSubject" Width="500px" maxlength="255" runat="server"/>
		</td>
	</tr>
	<tr>
		<td class="requiredField" valign="top">Post: 
            <asp:RequiredFieldValidator id="reqPost" ControlToValidate="psPost" ErrorMessage="The Post Field is required." display="static" runat="server">*</asp:RequiredFieldValidator>
		</td>
		<td class="requiredField">
            <asp:TextBox TextMode="MultiLine" id="txtPost"  Width="500px" Height="300px" MaxLength="1000" runat="server"/>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:button id="submitter" name="submitter" text="Post Reply" OnClick="submitter_Click" runat="server" />
			<asp:button id="canceller" name="canceller" text="Cancel" CausesValidation="False" OnClick="canceller_Click" runat="server" />
		</td>
	</tr>
	</table>



</asp:Content>
