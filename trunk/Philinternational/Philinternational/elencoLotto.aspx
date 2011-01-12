<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elencoLotto.aspx.cs" Inherits="Philinternational.elencoLotto" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title runat="server" id="titlePage">Titolo</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="nomeArgomento"></h1>
    <asp:SqlDataSource ID="LottoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:Repeater runat="server" ID="elencoLotti" DataSourceID="LottoConnector"  DataMember="DefaultView">
    <ItemTemplate>
        <div class="bloccoLotto">
            <h4 id="idlotto" runat="server" ><%#Eval("idlotto")%></h4>
            <p><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto")) %></p>
            <p>Anno: <span id="annoLotto"><%# Eval("anno")%></span></p>
            <p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p>
            <p>Condizione: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
            <p>Prezzo: <span id="prezzLotto" runat="server"><%# Eval("euro")%></span></p>
            <p class="lottoOfferta"><%# VerificaOfferta(DataBinder.Eval(Container.DataItem, "stato"), DataBinder.Eval(Container.DataItem, "idlotto"))%></p>
        </div>  
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
