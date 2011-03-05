<%@ Page Title="Gestione dei paragrafi" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Paragrafo.aspx.cs" Inherits="Philinternational.Styles.Paragrafo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Gestione Paragrafi</h3>
    <br />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnNuovoParagrafo" runat="server" AlternateText="Inserisci nuovo paragrafo"
                    CssClass="cleanButtons" ImageUrl="~/images/commands/nuovo.png" OnClick="ibtnNuovoParagrafo_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvParagrafi" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="idparagrafo" OnRowUpdating="gvParagrafi_RowUpdating" OnPageIndexChanged="gvParagrafi_PageIndexChanged"
        OnRowEditing="gvParagrafi_RowEditing" EmptyDataText="Nessun paragrafo presente"
        OnPageIndexChanging="gvParagrafi_PageIndexChanging" GridLines="None" ShowHeader="False"
        PageSize="15">
        <RowStyle CssClass="RowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate><asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                    CommandName="Edit" ImageUrl="~/images/selectfull.png" />
                </ItemTemplate>
                <EditItemTemplate><asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                    CommandName="Update" ImageUrl="~/images/accept.png" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrizione" SortExpression="descrizione">
                <ItemTemplate>
                    <asp:HyperLink ID="hlEditParagrafo" runat="server" NavigateUrl='<%# "~/Management/ArgoAndSubArgomento.aspx?Query=" + DataBinder.Eval (Container.DataItem,"idparagrafo")%>'><%# DataBinder.Eval(Container.DataItem, "descrizione") %></asp:HyperLink>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpdateDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stato">
                <ItemTemplate><asp:CheckBox ID="chkStatus" runat="server" Enabled="False" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </ItemTemplate>
                <EditItemTemplate><asp:CheckBox ID="chkUpdateStatus" runat="server" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
