<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Newsletter.aspx.cs" Inherits="Philinternational.Styles.Newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Gestione Newsletter</h3>
    <br />
    <asp:MultiView ID="mvNewsletterManager" runat="server">
        <asp:View ID="viewGrid" runat="server">
            <asp:GridView ID="gvNewsletters" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="idnewsletter" GridLines="None" ShowHeader="False" OnPageIndexChanged="gvNewsletters_PageIndexChanged"
                OnPageIndexChanging="gvNewsletters_PageIndexChanging" OnRowEditing="gvNewsletters_RowEditing"
                OnRowUpdating="gvNewsletters_RowUpdating" EmptyDataText="Newsletter non presenti.">
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
            <br />
            <asp:ImageButton ID="ibtnCreateNewsletter" runat="server" AlternateText="Crea una nuova newsletter"
                OnClick="ibtnCreateNewsletter_Click" />&nbsp;<asp:ImageButton ID="ibtnDeleteSelectedNewsletters"
                    runat="server" OnClick="ibtnDeleteSelectedNewsletters_Click" AlternateText="Cancella le newsletters selezionate" />
            <br />
            <br />
            <asp:ImageButton ID="ibtnSendToAll" runat="server" AlternateText="Distribuisci le newsletters selezionate"
                OnClick="ibtnSendToAll_Click" /></asp:View>
        <asp:View ID="viewDistribution" runat="server"><p>Deseleziona eventuali utenti che,
            in via eccezionale, non riceveranno la/le newsletter precedentemente selezionate.</p>
            <br />
            <asp:ImageButton ID="ibtnSendMails" runat="server" AlternateText="Spedisci le newsletters agli utenti"
                OnClick="ibtnSendMails_Click" />
            <asp:Panel ID="pnlDistribution" runat="server" ScrollBars="Vertical" Height="600px">
                <asp:CheckBoxList ID="cblDistribution" runat="server" RepeatColumns="2"></asp:CheckBoxList>
            </asp:Panel>
            <asp:ImageButton ID="ibtnSendMailsBottom" runat="server" AlternateText="Spedisci le newsletters agli utenti"
                OnClick="ibtnSendMails_Click" /><br />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>
