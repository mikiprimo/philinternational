<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="newsDetail.aspx.cs" Inherits="Philinternational.Management.newsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Dettaglio news</h3>
    <br />
    <label runat="server" id="esitoMessaggio"></label>
    <br />
    <label>Data Pubblicazione: </label>
    <label style="font-weight: bold" runat="server" id="labelDataPubblicazione"></label>
    <asp:Label ID="lblDataPubblicazione" runat="server"></asp:Label>
    <br />
    <br />
    <label id="labelTitolo" runat="server">Titolo: </label>
    <asp:TextBox runat="server" ID="txtTitolo"></asp:TextBox>
    <br />
    <br />
    <label>Testo</label><br />
    <asp:TextBox runat="server" ID="txtTesto" Rows="10" Columns="50" TextMode="MultiLine"> </asp:TextBox><br />
    <br />
    <asp:CheckBox ID="chkStato" runat="server" Text="Attiva" /><br />
    <br />
    <br />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" ToolTip="Conferma"
                    Text="Conferma" OnClick="ibtnConferma_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/conferma.png" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnPulisci" runat="server" AlternateText="Pulisci" ToolTip="Pulisci"
                    OnClick="ibtnReset_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/pulisci.png" />
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
