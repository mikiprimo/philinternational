<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArgomentoDetail.aspx.cs" Inherits="Philinternational.Management.ArgomentoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Dettaglio Argomento 
</h1><hr />br>
    <p><label runat="server" id="esitoMessaggio"></label>
    </p>
    Descrizione:
    <asp:TextBox ID="txtDescrizione" runat="server"></asp:TextBox>
    <br />
    Stato<asp:CheckBox runat="server" ID="chkStato" /><label id="labelStato" runat="server"></label>
    <p>
        <asp:Button runat="server" Text="Conferma" ID="btnConferma" OnClick="conferma" />&nbsp;
        <asp:Button runat="server" Text="Reset" ID="buttonReset" OnClick="pulisci" />&nbsp;
        <asp:Button runat="server" Text="Torna Indietro" ID="btnComeBack" OnClick="comeBack" />
    </p>
</asp:Content>