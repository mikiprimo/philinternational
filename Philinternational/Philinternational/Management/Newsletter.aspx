<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Newsletter.aspx.cs" Inherits="Philinternational.Styles.Newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Gestione
    Newsletter</h1>
    <asp:GridView ID="gvNewsletters" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="idnewsletter" GridLines="None" ShowHeader="False" 
        onpageindexchanged="gvNewsletters_PageIndexChanged" 
        onpageindexchanging="gvNewsletters_PageIndexChanging" 
        onrowediting="gvNewsletters_RowEditing" 
        onrowupdating="gvNewsletters_RowUpdating">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><asp:ImageButton ID="ibtnEditNewsletter" runat="server" CausesValidation="False"
                    CommandName="Edit" ImageUrl="~/images/selectfull.png" />
                </ItemTemplate>
                <EditItemTemplate><asp:ImageButton ID="ibtnUpdateNewsletter" runat="server" CausesValidation="False"
                    CommandName="Update" ImageUrl="~/images/accept.png" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblEditData" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Eval("data_creazione")) %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblEditData" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Eval("data_creazione")) %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTitolo" runat="server" Text='<%# Bind("titolo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpdateTitolo" runat="server" Text='<%# Bind("titolo") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblTesto" runat="server" Text='<%# Bind("testo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpdateTesto" runat="server" Text='<%# Bind("testo") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ImageButton ID="ibtnCreateNewsletter" runat="server" AlternateText="Crea una nuova newsletter"
        OnClick="ibtnCreateNewsletter_Click" />&nbsp;<asp:ImageButton ID="ibtnDeleteSelectedNewsletters"
            runat="server" OnClick="ibtnDeleteSelectedNewsletters_Click" 
        AlternateText="Cancella le newsletters selezionate" style="width: 14px" />
</asp:Content>
