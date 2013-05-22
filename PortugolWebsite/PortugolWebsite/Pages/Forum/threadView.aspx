<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="threadView.aspx.cs" Inherits="PortugolWebsite.Pages.Forum.threadView" %>
<%@ MasterType VirtualPath="~/PortugolWebSite.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">
        <link rel="stylesheet" href="../../css/client.css" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hiddenTopicId" runat="server" />

	<br /><br />
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
			<a class="menuitem" href="forum.aspx">Forum Topics</a> &#062;
            <asp:HyperLink ID="hyperLinkPostReply" NavigateUrl="#" Text="Post a Reply to this Thread" runat="server"></asp:HyperLink>
		</td>
	</tr>
	<tr>
        
		<td height="2"></td>
	</tr>
	<tr>
		<td align="right" valign="top" nowrap>
			<asp:DropDownList id="sortOrder" AutoPostBack="true" OnSelectedIndexChanged="sortOrder_SelectedIndexChanged" runat="server">
				<asp:ListItem Selected="True" Value="desc"> Newest First </asp:ListItem>
				<asp:ListItem Selected="False" Value="asc"> Oldest First </asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td height="4"></td>
	</tr>
	</table>

	<asp:datagrid id="dotForumDisplay" runat="server" BorderWidth="0"

		CellPadding="0" CellSpacing="0" Width="100%"
		AutoGenerateColumns="False"

		HeaderStyle-BackColor="#4373B4"

		AllowPaging="True"
		PageSize="10"
		OnPageIndexChanged="dotForumDisplay_PageIndexChanged">

		<PagerStyle Mode="NextPrev" HorizontalAlign="Right" CssClass="pageLink" BackColor="#ffffff"
			NextPageText="Next &gt;" PrevPageText="&lt; Prev">
		</PagerStyle>

		<selecteditemstyle cssclass="bglight"></selecteditemstyle>
		<alternatingitemstyle cssclass="bgdark"></alternatingitemstyle>
		<ItemStyle CssClass="bglight"></ItemStyle>
	<Columns>

	<asp:TemplateColumn>
		<HeaderStyle CssClass="listheader" />
		<HeaderTemplate>Topic: <%# DataBinder.Eval(Container.DataItem, "Title") %></HeaderTemplate>
	
		<ItemStyle CssClass="listColumnText" />
		<ItemTemplate>
			<table>
			</tr>
                <td width="75%">
                    <b><%# DataBinder.Eval(Container.DataItem, "Subject") %></b>
				</td>
                <td width="300" rowspan="2" valign="top"><%# DataBinder.Eval(Container.DataItem, "Username") %>
                    <br>
                    <%# string.IsNullOrEmpty( Convert.ToString(DataBinder.Eval(Container.DataItem, "LastUpdate")) ) ? string.Empty : ((DateTime)(DataBinder.Eval(Container.DataItem, "LastUpdate"))).ToString("yyyy-MM-dd HH:mm") %>
			    </td>
			</tr>
            <tr>
    			<td>
                    <%# DataBinder.Eval(Container.DataItem, "Post") %>
				</td>
                <td></td>
			</tr>
			</table>
		</ItemTemplate>
	</asp:TemplateColumn>

	</Columns>	

	</asp:datagrid>

	<span id="messageCenter" EnableViewState="false" runat="server"/><p>

</asp:Content>
