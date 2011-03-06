<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ParagrafoDetail.aspx.cs" Inherits="Philinternational.Management.ParagrafoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Nuovo Paragrafo</h3>
    <br />
    <asp:Label ID="lblDescrizione" runat="server">Descrizione</asp:Label><br />
    <asp:TextBox ID="txtDescrizione" runat="server" TextMode="MultiLine" 
        Height="167px" Width="507px"></asp:TextBox>
    <br />
    <br />
    <asp:CheckBox ID="chkStatus" runat="server" Text="Attiva" /><br />
    <br />
    <p><asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" Text="Conferma"
        OnClick="ibtnConferma_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/conferma.png"
        ToolTip="Conferma" />&nbsp; <asp:ImageButton ID="ibtnReset" runat="server" AlternateText="Pulisci"
            OnClick="ibtnReset_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/pulisci.png"
            ToolTip="Pulisci" />&nbsp; <asp:ImageButton ID="ibntTornaIndietro" runat="server"
                AlternateText="Torna indietro" OnClick="ibntTornaIndietro_Click" CssClass="cleanButtons"
                ImageUrl="~/images/commands/indietro.png" ToolTip="Torna Indietro" />&nbsp;
    </p>
</asp:Content>
