<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StoricoOfferte.aspx.cs" Inherits="Philinternational.Management.StoricoOfferte" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="titlePanel">Storico Offerte </h3>
    <fieldset>
        <legend>Opzioni</legend>
    </fieldset>
    <fieldset runat="server" id="fldMessaggi">
        <legend>Messaggi</legend>
        <asp:LinkButton runat="server" id="estraiStorico" OnClick="estraiDati" CssClass="bottone">Estrai Storico</asp:LinkButton>
        <span id="esitoEstrazione" runat="server" class="messaggi" style="display:block"></span>
    </fieldset>
    <asp:SqlDataSource ID="OfferteConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <table>
        <tr>
            <th>Asta</th>
            <th>Persona</th>
            <th>Data Inserimento</th>
        </tr>    
    <asp:Repeater runat="server" ID="listaLotti" DataSourceID="OfferteConnector">
        <ItemTemplate>
            <tr>
                <td><label id="numero_asta" runat="server"><%#Eval("numero_asta")%></label></td>
                <td><%#Eval("persona")%></td>
                <td><%#Eval("data_inserimento")%></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
