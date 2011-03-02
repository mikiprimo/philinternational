<%@ Page Title="Offerta filatelica per corrsipondenza, affrettatevi chiude il 4 aprile 2011. PhilInternational" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div id="presentazione">
		<h1>Phil International è un sito di offerta Filatelica per corrispondenza</h1>
		<p class="lato1">Al momento è attiva l'asta<span id="numeroAsta" runat="server"></span></p>
		<p class="lato2">Data di scadenza <span id="dataScadenza" runat="server"></span></p>
		<div style="clear:both;width:100%">
			<p>Prima di registrarsi, leggere attentamente le <asp:HyperLink NavigateUrl="~/Varie/condizioniVendita.aspx" Text="condizioni di vendita" runat="server" ></asp:HyperLink> e di pagamento</p>
		</div>
	</div>
	<br />
	<div id="info" class="block"><div runat="server" id="infoOutput"></div></div>
	<br />
	<h2 class="center">Alcuni lotti della nostra asta</h2>
	<div class="navi"></div> 
	<a class="prev browse left"></a> 
	<div class="scrollable" id="chained">   
	<div class="items">
	<asp:SqlDataSource ID="LottoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
	<asp:Repeater runat="server" ID="listaLotti" DataSourceID="LottoConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
	<ItemTemplate>
		<div>
			<p><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Lotto </span>:<span id="idlotto" runat="server" ><%#Eval("idlotto")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Anno</span>: <span id="annoLotto"><%# Eval("anno")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Condizione</span>: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Prezzo</span> : <span id="prezzoLotto" runat="server"><%# Eval("euro")%></span></p>
			<p id="descrizioneLotto" class="lottoOffertadescrizione" runat="server"><%# Eval("descrizione")%></p>
			<p class="lottoOfferta"><asp:LinkButton ID="linkBasket" runat="server">Aggiungi al carrello</asp:LinkButton><asp:Label runat="server" ID="linkBasketAdded" Visible="false">Lotto aggiunto al carrello</asp:Label>&nbsp;<%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%></p>            
		 </div>
	</ItemTemplate>
	</asp:Repeater>
	</div>
	</div>
	<a class="next browse right"></a>  
	<br clear="all" /> 
	<script type="text/javascript" language="javascript">
	$(document).ready(function () {
	$("#chained").scrollable({ circular: true, mousewheel: true }).navigator().autoscroll({interval: 3000});
	});
	</script> 
</asp:Content>
