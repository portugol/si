<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inserir.aspx.cs" Inherits="LingProg_Inserir" Title="Painel Administração"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="background-color:#F0F0F0;">
        <tr>
            <td rowspan="5">
                   <asp:Menu ID="Menu1" runat="server" DataSourceID="XmlDataSource_PSI" StaticSubMenuIndent="10px" BackColor="#636363" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#FFFFFF">
                        <DataBindings>
                            <asp:MenuItemBinding DataMember="item" NavigateUrlField="url" TextField="textoParaEcra" />
                        </DataBindings>
                        <DynamicHoverStyle BackColor="#C0C0C0" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#636363" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <StaticHoverStyle BackColor="#C0C0C0" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#1C5E55" />
                    </asp:Menu>
                    <asp:XmlDataSource ID="XmlDataSource_PSI" runat="server" DataFile="~/menu/menu_Admin.xml" XPath="/menu/*"></asp:XmlDataSource>
            </td>
            <td colspan="3" style="font-weight: bold; font-size: 14px; font-family: Verdana; color:#ffffff; background-color:#ca5100">
                Inserir Linguagens Programação</td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 158px">
            </td>
            <td style="width: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 155px; text-align: right">
                <asp:Label ID="lbl_Nome" runat="server" Font-Names="Verdana" Font-Size="12px" Text="Nome"></asp:Label></td>
            <td style="width: 158px; text-align: left">
                <asp:TextBox ID="txt_Nome" runat="server"></asp:TextBox></td>
            <td style="width: 20px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txt_Nome"
                    ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 155px; height: 23px">
            </td>
            <td style="width: 158px; height: 23px; text-align: right">
                &nbsp;<asp:Button ID="Bt_Limpar" runat="server" BackColor="Silver" Font-Names="Verdana"
                    Font-Size="12px" OnClick="bt_Limpar" Text="Limpar" Width="58px" />
                <asp:Button ID="Bt_Gravar" runat="server" BackColor="Silver" Font-Names="Verdana" Font-Size="12px"
                    OnClick="bt_Gravar" Text="Gravar" Width="87px"  OnClientClick="return confirm('Tem a certeza que quer gravar este registo?');"/></td>
            <td style="width: 20px; height: 23px; text-align: right">
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;
    <asp:Label ID="lbl_erro" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
        ForeColor="#C00000" Text="Dados introduzidos com sucesso!" Visible="False"></asp:Label>
</asp:Content>

