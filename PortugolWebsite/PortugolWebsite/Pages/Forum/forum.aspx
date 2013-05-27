<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="PortugolWebsite.Pages.Forum.forum" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">
        <link rel="stylesheet" href="../../css/forum.css" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">    
    <br /><br />
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
			<a class="menuitem" href="forum.aspx">Forum Topics</a>
            <asp:LoginView ID="LoginView1" runat="server">
	            <LoggedInTemplate>
                     &#062;
	                <asp:HyperLink ID="hyperLinkPostReply" NavigateUrl="~/Pages/Forum/createTopic.aspx" Text="Create a new topic" runat="server"></asp:HyperLink>              
	            </LoggedInTemplate>
            </asp:LoginView>
            
		</td>
	</tr>
	<tr>
        
		<td height="2"></td>
	</tr>
	<tr>
		<td align="right" valign="top" nowrap>

		</td>
	</tr>
	<tr>
		<td height="4"></td>
	</tr>
	</table>

	<asp:datagrid id="dotForumDisplay" DataKeyField="Id" runat="server" BorderWidth="0"

		CellPadding="0" CellSpacing="0" Width="100%"
		AutoGenerateColumns="False"

		AllowPaging="True"
		PageSize="15"
		OnPageIndexChanged="dotForumDisplay_PageIndexChanged"
		
		CssClass="forum">

		<PagerStyle Mode="NextPrev" HorizontalAlign="Right" CssClass="pageLink" BackColor="#ffffff"
			NextPageText="Next &gt;" PrevPageText="&lt; Prev">
		</PagerStyle>

		<selecteditemstyle cssclass="bglight"></selecteditemstyle>
		<alternatingitemstyle cssclass="bgdark"></alternatingitemstyle>
		<ItemStyle CssClass="bglight"></ItemStyle>

	<Columns>

	<asp:TemplateColumn>
		<HeaderStyle width="70%" CssClass="listheader" />
		<HeaderTemplate>Title</HeaderTemplate>
	
		<ItemStyle CssClass="listColumnText" />
		<ItemTemplate>
			<b>
                <a class="listItemLink" href="threadView.aspx?TopicId=<%# DataBinder.Eval(Container.DataItem, "Id") %>">
			    <%# DataBinder.Eval(Container.DataItem, "Title") %>
                </a>
			</b>
            <br>
			<%# DataBinder.Eval(Container.DataItem, "Description") %>
		</ItemTemplate>
	</asp:TemplateColumn>
	

	<asp:TemplateColumn>
		<HeaderStyle width="5%" CssClass="listheader" />
		<HeaderTemplate>Threads</HeaderTemplate>
	
		<ItemStyle CssClass="listColumnNumber" />
		<ItemTemplate>
			<%# DataBinder.Eval(Container.DataItem, "ThreadCount") %>
		</ItemTemplate>
	</asp:TemplateColumn>



	<asp:TemplateColumn>
		<HeaderStyle width="20%" CssClass="listheader" HorizontalAlign="center" />
		<HeaderTemplate>Last Post</HeaderTemplate>
	
		<ItemStyle HorizontalAlign="center" CssClass="listColumnText" />
		<ItemTemplate>
			<%# string.IsNullOrEmpty( Convert.ToString(DataBinder.Eval(Container.DataItem, "LastPost")) ) ? string.Empty : ((DateTime)(DataBinder.Eval(Container.DataItem, "LastPost"))).ToString("yyyy-MM-dd hh:mm") %><br>
		</ItemTemplate>
	</asp:TemplateColumn>


	</Columns>

	</asp:datagrid>

	<span id="messageCenter" EnableViewState="false" runat="server"/>

</asp:Content>
