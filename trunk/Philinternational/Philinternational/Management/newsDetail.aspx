﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newsDetail.aspx.cs" Inherits="Philinternational.Management.newsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Dettaglio news <label runat="server" id="titoloDettaglioNews"></label></h1>
<p><label runat="server" id="esitoMessaggio"></label></p>
<p>
<label>Data Pubblicazione</label><label runat="server" ID="labelDataPubblicazione"></label>
</p>

<p>
<label id="labelTitolo" runat="server">Titolo</label><asp:TextBox runat="server" ID="txtTitolo"></asp:TextBox>
</p>
<p>
<label>testo</label><asp:TextBox runat="server" id="txtTesto" Rows="10" Columns="50" TextMode="MultiLine"></asp:TextBox>
</p>
<p>
<label>Stato</label><asp:CheckBox runat="server" ID="chkStato"/><label id="labelStato" runat="server"></label>
</p>
<p><asp:Button runat="server"  Text="Conferma" ID="buttonConferma"  OnClick="conferma"/>&nbsp;
    <asp:Button runat="server" Text="Reset" ID="buttonReset" />
    <asp:HiddenField ID="txtCodice" runat="server" />
</p>

</asp:Content>
