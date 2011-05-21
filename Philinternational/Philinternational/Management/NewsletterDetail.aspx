<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NewsletterDetail.aspx.cs" Inherits="Philinternational.Management.NewsletterDetail" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Nuova
    newsletter</h1>
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate><p>
            <asp:TextBox ID="txtDataCreazione" runat="server" Enabled="False"></asp:TextBox>
            <asp:Calendar ID="calDataCreazione" runat="server" OnSelectionChanged="calDataCreazione_SelectionChanged">
            </asp:Calendar>
        </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <p>
        <asp:Label ID="lblTitolo" runat="server">Titolo: </asp:Label>
        <asp:TextBox ID="txtTitolo" runat="server"></asp:TextBox>
    </p>
    <br />
    <p>
        <asp:Label ID="lblTesto" runat="server">Testo: </asp:Label><br />
        <%--<asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="20" Columns="50"></asp:TextBox>--%>
        <CKEditor:CKEditorControl ID="CKEditNewsletter" runat="server"></CKEditor:CKEditorControl>
    </p>
    <br />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" ToolTip="Conferma"
                    Text="Conferma" OnClick="ibtnConferma_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/conferma.png"
                    ValidationGroup="RegisterUserValidationGroup" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnPulisci" runat="server" AlternateText="Pulisci" ToolTip="Pulisci"
                    CssClass="cleanButtons" ImageUrl="~/images/commands/pulisci.png" OnClick="ibtnPulisci_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ibntTornaIndietro" runat="server" AlternateText="Torna indietro"
                    ToolTip="Torna indietro" OnClick="ibntTornaIndietro_Click" CssClass="cleanButtons"
                    ImageUrl="~/images/commands/indietro.png" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
