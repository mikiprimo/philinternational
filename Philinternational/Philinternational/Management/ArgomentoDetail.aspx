<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArgomentoDetail.aspx.cs" Inherits="Philinternational.Management.ArgomentoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3>Dettaglio
    Argomento </h3>
    <br />
    <p><label runat="server" id="esitoMessaggio"></label>
    </p>
    <asp:Label ID="lblDescrizione" runat="server" Text="Descrizione: "></asp:Label><br />
    <asp:TextBox ID="txtDescrizione" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblStato" runat="server" Text="Stato: "></asp:Label><asp:CheckBox
        runat="server" ID="chkStato" />
    <table>
        <tr class="commandPanel">
            <td>
                <asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" CssClass="cleanButtons"
                    ToolTip="Conferma" ImageUrl="~/images/commands/conferma.png" OnClick="ibtnConferma_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnPulisci" runat="server" AlternateText="Pulisci" CssClass="cleanButtons"
                    ToolTip="Pulisci" ImageUrl="~/images/commands/pulisci.png" OnClick="ibtnPulisci_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnIndietro" runat="server" AlternateText="Indietro" CssClass="cleanButtons"
                    ToolTip="Sub argomenti selezionati" ImageUrl="~/images/commands/indietro.png"
                    OnClick="ibtnIndietro_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
