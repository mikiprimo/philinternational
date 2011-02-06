<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
        <ItemTemplate>
            <div class="bloccoLotto">
                <h4 id="idlotto" runat="server" ><%#Eval("idlotto")%></h4>
                <p><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></p>
                <p>Anno: <span id="annoLotto"><%# Eval("anno")%></span></p>
                <p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p>
                <p>Condizione: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
                <p>Prezzo: <span id="prezzoLotto" runat="server"><%# Eval("euro")%></span></p>
                <p class="lottoOfferta"><asp:LinkButton ID="linkBasket" runat="server">Aggiungi al carrello</asp:LinkButton><asp:Label runat="server" ID="linkBasketAdded" Visible="false">Lotto aggiunto al carrello</asp:Label></p>
                <p class="lottoOfferta"><%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%></p>
            </div>  
        </ItemTemplate>    
    </asp:Repeater>
</asp:Content>
