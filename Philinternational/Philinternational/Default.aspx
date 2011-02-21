<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="http://cdn.jquerytools.org/1.2.5/all/jquery.tools.min.js" type="text/javascript" language="javascript"></script>
    <link href="<%= Page.ResolveClientUrl("~/Styles/default.css") %>" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div id="presentazione">
		<h1>Phil International è un sito di offerta Filatelica per corrispondenza</h1>
		<p>In questo momento è attiva l'asta numero <span id="numeroAsta" runat="server"></span></p>
		<p>Data di scadenza <span id="dataScadenza" runat="server"></span></p>
		<p>Prima di registrarsi, leggere attentamente le <asp:HyperLink NavigateUrl="~/Varie/condizioniVendita.aspx" Text="condizioni di vendita" runat="server" ></asp:HyperLink> e di pagamento</p>
	</div>
	<br />
	<hr style="background-color:#000;height:2px;border:1px solid #eee"/>
	<div id="info" class="block">
		<div runat="server" id="infoOutput"></div>		 
		</div>
	<br />
	<h2 class="center">Alcuni lotti della nostra asta</h2>
	<div runat="server" id="esitoOperazione" class="esitoOperazione">&nbsp;</div>
	<asp:SqlDataSource ID="LottoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
	<asp:Repeater runat="server" ID="listaLotti" DataSourceID="LottoConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
    <HeaderTemplate>
        <a class="prev browse left"></a>
        <div class="scrollable">
            <div class="items">
    </HeaderTemplate>
	<ItemTemplate>
        <div><p><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></p></div>
	</ItemTemplate>
    <FooterTemplate>
            </div>
          </div>
         <a class="prev browse right"></a>
         <br clear="all" /> 
        <script type="text/javascript" language="javascript">
            $(function () {
                $(".scrollable").scrollable();
            });
        </script> 
    </FooterTemplate>
	</asp:Repeater>
</asp:Content>
