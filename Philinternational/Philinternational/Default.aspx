<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="<%= Page.ResolveClientUrl("~/Styles/default.css") %>" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div id="presentazione" style="border:1px solid #eee;padding:10px 5px;font-size:2.0em;letter-spacing:3px">
		<h1>Phil International è un sito di offerta Filatelica per corrispondenza</h1>
    </div>
    <div style="float:left;width:47%;padding:5px;font-size:1.5em;height:90px;text-align:center">
		<p>In questo momento è attiva l'asta numero <span style="font-size:2.0em;font-weight:bold;display:block" id="numeroAsta" runat="server"></span></p>
    </div>
    <div  style="float:right;width:47%;padding:5px;font-size:1.5em;height:90px;text-align:center">
		<p>Data di scadenza <span style="font-size:2.0em;font-weight:bold;display:block" id="dataScadenza" runat="server"></span></p>
    </div>
    <div style="clear:both;width:100%">
		<p>Prima di registrarsi, leggere attentamente le <asp:HyperLink NavigateUrl="~/Varie/condizioniVendita.aspx" Text="condizioni di vendita" runat="server" ></asp:HyperLink> e di pagamento</p>
	</div>
	<br />
	<hr style="background-color:#000;height:2px;border:1px solid #eee"/>
	<div id="info" class="block"><div runat="server" id="infoOutput"></div></div>
	<br />
	<h2 class="center">Alcuni lotti della nostra asta</h2>
	<div runat="server" id="esitoOperazione" class="esitoOperazione">&nbsp;</div>
    <!-- wrapper for navigator elements --> 
    <div class="navi"></div> 
        <!-- "previous page" action --> 
        <a class="prev browse left"></a> 
        <!-- root element for scrollable --> 
        <div class="scrollable" id="chained">   
            <div class="items">
	            <asp:SqlDataSource ID="LottoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
	            <asp:Repeater runat="server" ID="listaLotti" DataSourceID="LottoConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
                    <ItemTemplate>
                    <div><p><img src="images/immagine_non_disponibile.jpg" height="100" width="100" alt="immagine non disponibile" /></p></div>
                    </ItemTemplate>
                    
	            </asp:Repeater>
            </div>
        </div>         
        <!-- "next page" action --> 
        <a class="next browse right"></a>  
        <br clear="all" /> 
        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                $("#chained").scrollable({ circular: true, mousewheel: true }).navigator().autoscroll({interval: 3000});
            });
</script> 
</asp:Content>
