<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArgoAndSubArgomento.aspx.cs" Inherits="Philinternational.Styles.SubArgomento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:HyperLink ID="lnkSelectOtherParagraph" runat="server" NavigateUrl="~/Management/Paragrafo.aspx">Seleziona un altro paragrafo</asp:HyperLink>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvArguments" runat="server" AutoGenerateColumns="False" DataKeyNames="idargomento"
                    EmptyDataText="Nessun argomento associato al paragrafo" EnableModelValidation="True"
                    GridLines="None" onrowediting="gvArguments_RowEditing" 
                    onrowupdating="gvArguments_RowUpdating" 
                    onselectedindexchanging="gvArguments_SelectedIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnSelect" runat="server" CausesValidation="False"
                                CommandName="Select" Height="16px" ImageUrl="~/images/select.png" 
                                    ToolTip="Seleziona questo argomento"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CausesValidation="False"
                                CommandName="Edit" Height="16px" ImageUrl="~/images/selectfull.png" ToolTip="Modifica questo argomento" />
                            </ItemTemplate>
                            <EditItemTemplate><asp:ImageButton ID="ibtnUpdate" runat="server" CausesValidation="False"
                                CommandName="Update" Height="16px" ImageUrl="~/images/accept.png" ToolTip="Aggiorna con le modifiche apportate" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUpdateDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("descrizione") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <EditItemTemplate><asp:CheckBox ID="chkUpdateStatus" runat="server" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                            </EditItemTemplate>
                            <ItemTemplate><asp:CheckBox ID="chkStatus" runat="server" Enabled="False" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="gvSubArguments" runat="server"></asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
