<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SubArgomentoDetail.aspx.cs" Inherits="Philinternational.Management.SubArgomentoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Dettaglio Sub Argomento </h3>
    <br />
    <label runat="server" id="esitoMessaggio"></label>
    <br />
    <asp:Label ID="lblDescrizione" runat="server">Descrizione: </asp:Label>
    <br />
    <asp:TextBox ID="txtDescrizione" runat="server"></asp:TextBox>
    <br /><br />
    <asp:CheckBox ID="chkStato" runat="server" Text="Attiva" />
    <br />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" Text="Conferma"
                    CssClass="cleanButtons" ImageUrl="~/images/commands/conferma.png" ToolTip="Conferma"
                    OnClick="ibtnConferma_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnPulisci" runat="server" AlternateText="Pulisci" CssClass="cleanButtons"
                    ImageUrl="~/images/commands/pulisci.png" ToolTip="Pulisci" OnClick="ibtnPulisci_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ibntTornaIndietro" runat="server" AlternateText="Torna indietro"
                    CssClass="cleanButtons" ImageUrl="~/images/commands/indietro.png" ToolTip="Torna Indietro"
                    OnClick="ibntTornaIndietro_Click" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
