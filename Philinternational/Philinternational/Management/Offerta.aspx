<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offerta.aspx.cs" Inherits="Philinternational.Styles.Offerta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="OfferteElenco" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="OfferteConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:Repeater runat="server" ID="listaLotti" DataSourceID="OfferteConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
        <ItemTemplate></ItemTemplate>
    </asp:Repeater>
</asp:Content>
