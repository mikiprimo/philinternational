<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AstaDetail.aspx.cs" Inherits="Philinternational.Management.AstaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Nuova Asta </h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate><br />
            <asp:Label ID="lbldatafine" runat="server">Data di fine asta:</asp:Label>
            <asp:TextBox ID="txtDataFine" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Calendar ID="calDataFine" runat="server" OnSelectionChanged="calDataFine_SelectionChanged">
            </asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:CheckBox ID="chkStatus" runat="server" Text="Attiva" /><br />
    <br />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" Text="Conferma"
                    OnClick="ibtnConferma_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/conferma.png" />
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Pulisci" OnClick="ibtnReset_Click"
                    CssClass="cleanButtons" ImageUrl="~/images/commands/pulisci.png" />
            </td>
            <td>
                <asp:ImageButton ID="ibntTornaIndietro" runat="server" AlternateText="Torna indietro"
                    OnClick="ibntTornaIndietro_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/indietro.png" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
