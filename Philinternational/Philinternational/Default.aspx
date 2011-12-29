<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>
<%@ OutputCache CacheProfile="Cache24Hours" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
        <title><asp:Literal runat="server" ID="testoTitle"></asp:Literal></title>
        <meta name="KEYWORDS" content ="filatelica, filatelia,asta, lotti, francobolli, gilardi,philinternational, offerta per corrispondenza" />
        <meta name="DESCRIPTION" content="PhilInternational è un sito di offerta filatelica per corrispondenza." />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div id="presentazione">
		<h1>Phil International è un sito di offerta Filatelica per corrispondenza</h1>
		<p class="lato1"><span id="testoAstaForNumero" runat="server" class="normal"></span><span id="numeroAsta" runat="server"></span></p>
		<p class="lato2"><span id="testoScadenza" runat="server" class="normal"></span><span id="dataScadenza" runat="server"></span></p>
		<div style="clear:both;width:100%">
			<p>Prima di registrarsi, leggere attentamente le <asp:HyperLink NavigateUrl="~/Varie/condizioniVendita.aspx" Text="condizioni di vendita" runat="server" ></asp:HyperLink> e di pagamento</p>
		</div>
	</div>
	<br />
	<div id="info" class="block"><div runat="server" id="infoOutput"></div></div>
	<br />
    <div style="text-align:center">
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="468" height="60" id="banner_segretidibacco_468_60" align="middle">
				<param name="movie" value="banner_segretidibacco_468_60.swf" />
				<param name="quality" value="high" />
				<param name="bgcolor" value="#ffffff" />
				<param name="play" value="true" />
				<param name="loop" value="true" />
				<param name="wmode" value="window" />
				<param name="scale" value="showall" />
				<param name="menu" value="true" />
				<param name="devicefont" value="false" />
				<param name="salign" value="" />
				<param name="allowScriptAccess" value="sameDomain" />
				<!--[if !IE]>-->
				<object type="application/x-shockwave-flash" data="banner_segretidibacco_468_60.swf" width="468" height="60">
					<param name="movie" value="banner_segretidibacco_468_60.swf" />
					<param name="quality" value="high" />
					<param name="bgcolor" value="#ffffff" />
					<param name="play" value="true" />
					<param name="loop" value="true" />
					<param name="wmode" value="window" />
					<param name="scale" value="showall" />
					<param name="menu" value="true" />
					<param name="devicefont" value="false" />
					<param name="salign" value="" />
					<param name="allowScriptAccess" value="sameDomain" />
				<!--<![endif]-->
					<a href="http://get.adobe.com/it/flashplayer/">
						<img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
					</a>
				<!--[if !IE]>-->
				</object>
				<!--<![endif]-->
			</object>    
    </div>
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
			<p style="line-height:20px"><span style="text-decoration:underline">Lotto </span>:<span id="idlotto" runat="server" style="font-size:1.6em;font-weight:bold"><%#Eval("idlotto")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Anno</span>: <span id="annoLotto"><%# Eval("anno")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Condizione</span>: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
			<p style="line-height:20px"><span style="text-decoration:underline">Prezzo</span> : <span id="prezzoLotto" runat="server" style="text-align:right"><b><%# Eval("prezzo_base")%></b>&nbsp;&euro;</span></p>
			<p id="descrizioneLotto" class="lottoOffertadescrizione" runat="server"><%# Eval("descrizione")%></p>
			<p class="lottoOfferta">
                <asp:LinkButton ID="linkBasket" runat="server" ToolTip="Aggiungi al carrello">Aggiungi al carrello</asp:LinkButton>
                <asp:Label runat="server" ID="linkBasketAdded" Visible="false" ToolTip="Lotto agginto al carrello">Lotto aggiunto al carrello</asp:Label>&nbsp;
                <%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%>
            </p>
		 </div>
	</ItemTemplate>
	</asp:Repeater>
	</div>
	</div>
	<a class="next browse right"></a>  
	<br style="clear:both" /> 
	<script type="text/javascript">
	$(document).ready(function () {
	$("#chained").scrollable({ circular: true, mousewheel: true }).navigator().autoscroll({interval: 3000});
	});
	</script> 
    <div style="width:100%;height:100px;margin:3px 0px">
    <a href="http://www.unificato.it"><img src="images/banner/unificato.gif" width="299" height="99"/></a></div>
</asp:Content>
