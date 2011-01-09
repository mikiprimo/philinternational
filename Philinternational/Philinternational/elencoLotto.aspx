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
            <h4 id="idlotto" runat="server" ><%# Eval("idlotto")%></h4>
            <asp:HyperLink  NavigateUrl="images/asta/2.jpg" rel="shadowbox;handleOversize:resize" runat="server" text="Lotto 2" id="shadowimages"><img src="images/asta/2.jpg" width="100" height="100" alt="Lotto 1..."  /></asp:HyperLink>
            <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..." runat="server" id="imagesNonDisponibile" />
            <p>Anno:<span id="annoLotto"><%# Eval("anno")%></span></p>
            <p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p>
            <p>Condizione: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
            <p>Prezzo: <span id="prezzLotto" runat="server"><%# Eval("euro")%></span></p>
            <p class="lottoOfferta"></p>
        </div>  
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
