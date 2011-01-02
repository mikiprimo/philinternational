<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Paragrafo.aspx.cs" Inherits="Philinternational.Styles.Paragrafo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvParagrafi" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="idparagrafo" OnRowUpdating="gvParagrafi_RowUpdating" OnPageIndexChanged="gvParagrafi_PageIndexChanged"
        OnRowEditing="gvParagrafi_RowEditing">
        <Columns>
            <asp:BoundField DataField="idparagrafo" HeaderText="ID" ReadOnly="True" SortExpression="idparagrafo" />
            <asp:TemplateField>
                <EditItemTemplate><asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                    CommandName="Update" ImageUrl="~/images/accept.png" />
                </EditItemTemplate>
                <ItemTemplate><asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                    CommandName="Edit" ImageUrl="~/images/selectfull.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrizione" SortExpression="descrizione">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpdateDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("descrizione") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stato">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkUpdateStatus" runat="server" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkStatus" runat="server" Enabled="False" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
