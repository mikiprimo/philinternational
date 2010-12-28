<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="newsDetail.aspx.cs" Inherits="Philinternational.Management.newsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dettaglio news
        <label runat="server" id="titoloDettaglioNews">
        </label>
    </h1>
    <p>
        <label runat="server" id="esitoMessaggio">
        </label>
    </p>
    <p>
        <label>
            Data Pubblicazione:</label><label style="font-weight: bold" runat="server" id="labelDataPubblicazione"></label>
        <asp:Label ID="lblDataPubblicazione" runat="server"></asp:Label>
    </p>
    <p>
        <label id="labelTitolo" runat="server">
            Titolo</label><asp:TextBox runat="server" ID="txtTitolo"></asp:TextBox>
    </p>
    <p>
        <label>
            testo</label><br />
        <asp:TextBox runat="server" ID="txtTesto" Rows="10" Columns="50" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <label>
            Stato</label><asp:CheckBox runat="server" ID="chkStato" /><label id="labelStato"
                runat="server"></label>
    </p>
    <p>
        <asp:Button runat="server" Text="Conferma" ID="btnConferma" OnClick="conferma" />&nbsp;
        <asp:Button runat="server" Text="Reset" ID="buttonReset" OnClick="pulisci" />&nbsp;
        <asp:Button runat="server" Text="Torna Indietro" ID="btnComeBack" OnClick="comeBack" />
    </p>
</asp:Content>
