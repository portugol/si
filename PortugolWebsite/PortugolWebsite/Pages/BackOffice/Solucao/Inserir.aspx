<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Solucao_Inserir" Title="Painel Administra��o" Codebehind="Inserir.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="background-color:#F0F0F0;">
        <tr>
            <td rowspan="7">
                 <asp:Menu ID="Menu1" runat="server" DataSourceID="XmlDataSource_PSI" StaticSubMenuIndent="10px" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666">
                        <DataBindings>
                            <asp:MenuItemBinding DataMember="item" NavigateUrlField="url" TextField="textoParaEcra" />
                        </DataBindings>
                        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#E3EAEB" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#1C5E55" />
                    </asp:Menu>
                    <asp:XmlDataSource ID="XmlDataSource_PSI" runat="server" DataFile="~/menu/menu_Admin.xml" XPath="/menu/*"></asp:XmlDataSource>
            </td>
            <td colspan="3" style="font-weight: bold; font-size: 14px; font-family: Verdana; color:#ffffff; background-color:#356bb3">
                Inserir Solu��es</td>
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
                <asp:Label ID="lbl_entradas" runat="server" Font-Names="Verdana" Font-Size="12px" Text="Entradas"></asp:Label></td>
            <td style="width: 158px; text-align: left">
                <asp:TextBox ID="txt_entradas" runat="server"></asp:TextBox></td>
            <td style="width: 20px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_entradas"
                    ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 155px; text-align: right">
                <asp:Label ID="lbl_saidas" runat="server" Font-Names="Verdana" Font-Size="12px" Text="Saidas"></asp:Label></td>
            <td style="width: 158px; text-align: left">
                <asp:TextBox ID="txt_saidas" runat="server"></asp:TextBox></td>
            <td style="width: 20px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_saidas"
                    ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 155px; text-align: right">
                <asp:Label ID="lbl_perguntaid" runat="server" Font-Names="Verdana" Font-Size="12px" Text="Pergunta"></asp:Label></td>
            <td style="width: 158px; text-align: left">
                <asp:DropDownList ID="Drop_Perguntaid" runat="server" DataSourceID="SqlDataSource_PerguntaID" DataTextField="Id" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource_PerguntaID" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_Listar %>" 
                    SelectCommand="SELECT Id FROM perguntas"  ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
                    </td>
            <td style="width: 20px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Drop_Perguntaid"
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
                <asp:Button ID="Bt_Inserir" runat="server" BackColor="Silver" Font-Names="Verdana" Font-Size="12px"
                    OnClick="bt_Inserir" Text="Inserir" Width="87px" OnClientClick="return confirm('Tem a certeza que quer inserir este registo?');"/></td>
            <td style="width: 20px; height: 23px; text-align: right">
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;
    <asp:Label ID="lbl_erro" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
        ForeColor="#C00000" Text="Dados introduzidos com sucesso!" Visible="False"></asp:Label>
</asp:Content>
