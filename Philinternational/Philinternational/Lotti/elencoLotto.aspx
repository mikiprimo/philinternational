<%@ Page Title="Elenco Lotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elencoLotto.aspx.cs" Inherits="Philinternational.elencoLotto" %>
<%@ OutputCache CacheProfile="Cache24Hours" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title><asp:Literal runat="server" ID="testoTitle"></asp:Literal></title>
</asp:Content>
<asp:Content ID="MainElenco" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="navigazioneOutput"></div>
    <div runat="server" id="numPagineOutput"></div>
    <asp:SqlDataSource ID="LottoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:Repeater runat="server" ID="listaLotti" DataSourceID="LottoConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
        <ItemTemplate>
            <div class="elencoLotto" style="width:100%;clear:both;border-bottom:1px solid #707070;height:180px;background-color:#eee;">
            <div style="clear:both;">
                <div style="height:140px;width:20%;float:left;text-align:center;padding:2px 0px 0px 0px"><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></div>
                <div style="width:49%;float:left;line-height:14px;text-align: justify;padding:2px"><p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p></div>
                <div style="width:30%;float:right;text-align:left;">
                    <p style="line-height:20px"><span style="text-decoration:underline">Anno:</span>&nbsp;<span id="annoLotto"><%# Eval("anno")%></span></p>
                    <p style="line-height:20px"><span style="text-decoration:underline">Condizione:</span>&nbsp;<span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
                    <p style="line-height:20px"><span style="text-decoration:underline">Prezzo base:</span>&nbsp;<span id="prezzoLotto" runat="server" style="text-align:right"><b><%# Eval("prezzo_base")%></b>&nbsp;&euro;</span></p>
                    <p><span style="text-decoration:underline">Lotto</span>&nbsp;<span id="idlotto" runat="server" style="font-size:1.6em;font-weight:bold"><%#Eval("idlotto")%></span></p>
                </div>
            </div>
            <div style="width:100%;clear:both;float:left;line-height:25px">
                <asp:LinkButton ID="linkBasket" runat="server">Aggiungi al carrello</asp:LinkButton>
                <asp:Label runat="server" ID="linkBasketAdded" Visible="false">Lotto aggiunto al carrello</asp:Label>
                <%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%>
            </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <div class="elencoLotto" style="width:100%;clear:both;border-bottom:1px solid #707070;height:180px;">
            <div style="clear:both;">
                <div style="height:140px;width:20%;float:left;text-align:center"><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></div>
                <div style="width:49%;float:left;line-height:14px;text-align: justify;padding:2px"><p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p></div>
                <div style="width:30%;float:right;text-align:left;">
                    <p style="line-height:20px"><span style="text-decoration:underline">Anno:</span>&nbsp;<span id="annoLotto"><%# Eval("anno")%></span></p>
                    <p style="line-height:20px"><span style="text-decoration:underline">Condizione:</span>&nbsp;<span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
                    <p style="line-height:20px"><span style="text-decoration:underline">Prezzo base:</span>&nbsp;<span id="prezzoLotto" runat="server" style="text-align:right"><b><%# Eval("prezzo_base")%></b>&nbsp;&euro;</span></p>
                    <p><span style="text-decoration:underline">Lotto</span>&nbsp;<span id="idlotto" runat="server" style="font-size:1.6em;font-weight:bold"><%#Eval("idlotto")%></span></p>
                </div>
            </div>
            <div style="width:100%;clear:both;float:left;line-height:25px">
                <asp:LinkButton ID="linkBasket" runat="server">Aggiungi al carrello</asp:LinkButton>
                <asp:Label runat="server" ID="linkBasketAdded" Visible="false">Lotto aggiunto al carrello</asp:Label>
                <%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%>
            </div>        
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</asp:Content>
