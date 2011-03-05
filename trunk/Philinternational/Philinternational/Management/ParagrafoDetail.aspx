<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ParagrafoDetail.aspx.cs" Inherits="Philinternational.Management.ParagrafoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Nuovo Paragrafo</h3>
    <asp:TextBox ID="txtDescrizione" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:CheckBox ID="chkStatus" runat="server" Text="Attiva" /><br />
    <br />
    <p><asp:ImageButton ID="ibtnConferma" runat="server" AlternateText="Conferma" 
            Text="Conferma" onclick="ibtnConferma_Click" />
        <asp:ImageButton ID="ibtnReset" runat="server" AlternateText="Pulisci" 
            onclick="ibtnReset_Click" />
        <asp:ImageButton ID="ibntTornaIndietro" runat="server" 
            AlternateText="Torna indietro" onclick="ibntTornaIndietro_Click" />
    </p>
</asp:Content>
