﻿<%@ Page Title="Elenco Lotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elencoLotto.aspx.cs" Inherits="Philinternational.elencoLotto" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title runat="server" id="titlePage"></title>
</asp:Content>
<asp:Content ID="MainElenco" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="navigazioneOutput"></div>
    <hr />
    <div runat="server" id="numPagineOutput"></div>
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
