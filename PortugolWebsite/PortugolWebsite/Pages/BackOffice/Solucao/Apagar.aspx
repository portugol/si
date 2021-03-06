<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Solucao_Apagar" Title="Painel Administração" Codebehind="Apagar.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td rowspan="2">
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
            <td style="font-weight: bold; font-size: 14px; font-family: Verdana; color:#ffffff; background-color: #356bb3">
                Apagar Soluções</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GrdvApagar_Solucoes" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                     DataKeyNames="Id" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" DataSourceID="SqlDataSource_SoluApag">
                    <AlternatingRowStyle BackColor="White" />
                    
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="bt_delete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Tem a certeza que quer eliminar este registo?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Entradas" HeaderText="Entradas" SortExpression="Entradas" />
                        <asp:BoundField DataField="Saidas" HeaderText="Saidas" SortExpression="Saidas" />
                        <asp:BoundField DataField="PerguntasId" HeaderText="PerguntasId" SortExpression="PerguntasId" />
                    </Columns>
                    
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                </asp:GridView>              
                              
                <asp:SqlDataSource ID="SqlDataSource_SoluApag" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString_Listar %>" 
                    DeleteCommand="DELETE FROM solucao WHERE Id = @original_Id AND Entradas = @original_Entradas AND Saidas = @original_Saidas AND PerguntasId = @original_PerguntasId" 
                    InsertCommand="INSERT INTO solucao (Entradas, Saidas, PerguntasId) VALUES (@Entradas, @Saidas, @PerguntasId)" OldValuesParameterFormatString="original_{0}" 
                    SelectCommand="SELECT * FROM solucao" 
                    UpdateCommand="UPDATE solucao SET Entradas = @Entradas, Saidas = @Saidas, PerguntasId = @PerguntasId WHERE Id = @original_Id AND Entradas = @original_Entradas AND Saidas = @original_Saidas AND PerguntasId = @original_PerguntasId" ProviderName="MySql.Data.MySqlClient">
                    <DeleteParameters>
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Entradas" Type="String" />
                        <asp:Parameter Name="original_Saidas" Type="String" />
                        <asp:Parameter Name="original_PerguntasId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Entradas" Type="String" />
                        <asp:Parameter Name="Saidas" Type="String" />
                        <asp:Parameter Name="PerguntasId" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Entradas" Type="String" />
                        <asp:Parameter Name="Saidas" Type="String" />
                        <asp:Parameter Name="PerguntasId" Type="Int32" />
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Entradas" Type="String" />
                        <asp:Parameter Name="original_Saidas" Type="String" />
                        <asp:Parameter Name="original_PerguntasId" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                              
            </td>
        </tr>
    </table>
</asp:Content>

