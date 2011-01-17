<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div id="presentazione">
		<h1>Phil International è un sito di offerta Filatelica per corrispondenza</h1>
		<p>In questo momento è attiva l'asta numero <span>53</span></p>
		<p>Data di scadenza <span>01 gennaio 2011</span></p>
		<p>Prima di registrarsi, leggere attentamente le <asp:HyperLink NavigateUrl="~/condizioniVendita.aspx" Text="condizioni di vendita" runat="server" ></asp:HyperLink> e di pagamento</p>
	</div>
	<br />
	<hr style="background-color:#000;height:2px;border:1px solid #eee"/>
	<div id="info" class="block">
		<div runat="server" id="infoOutput"></div>		 
		</div>
	<br />
	<h2 class="center">Alcuni lotti della nostra asta</h2>
    <div id="LottoRndOutput" runat="server"></div>
</asp:Content>
