<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offerta.aspx.cs" Inherits="Philinternational.Styles.Offerta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="OfferteElenco" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Proposte ricevute</h3>
    <fieldset>
        <legend>Opzioni</legend>
        <asp:LinkButton runat="server" id="estraiLotto" OnClick="estraiDati" CssClass="bottone">Estrai Lotti</asp:LinkButton>&nbsp;
        <asp:LinkButton runat="server" id="elencoCompleto" OnClick="showElencoCompleto" CssClass="bottone">Mostra elenco completo</asp:LinkButton>
    </fieldset>
    <fieldset runat="server" id="fldMessaggi">
        <legend>Messaggi</legend>
    <span id="esitoEstrazione" runat="server" class="messaggi"></span>
    </fieldset>
    <asp:SqlDataSource ID="OfferteConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:Repeater runat="server" ID="listaLotti" DataSourceID="OfferteConnector" OnItemDataBound="R1_ItemDataBound" OnItemCommand="R_ItemCommand">
        <HeaderTemplate>
            <table>
            <tr>
                <th>Lotto</th>
                <th>Persona</th>
                <th>Data</th>
                <th>Prezzo Offerto</th>
                <th>&nbsp;</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align:right"><%#Eval("idlotto")%></td>
                <td><%#Eval("persona")%></td>
                <td><%#Eval("data_inserimento")%></td>
                <td style="text-align:right"><%#Eval("prezzo_offerto")%> &euro;</td>
                <td><asp:LinkButton ID="assegnaLotto" runat="server" myIdLotto='<%#Eval("idlotto")%>' myIdOfferta='<%#Eval("idofferta")%>' myIdAnagrafica='<%#Eval("idanagrafica")%>'>Assegna</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
    <tr class="alternate">
                <td style="text-align:right"><%#Eval("idlotto")%></td>
                <td><%#Eval("persona")%></td>
                <td><%#Eval("data_inserimento")%></td>
                <td style="text-align:right"><%#Eval("prezzo_offerto")%></td>
                <td><asp:LinkButton ID="assegnaLotto" runat="server" myIdLotto='<%#Eval("idlotto")%>' myIdOfferta='<%#Eval("idofferta")%>' myIdAnagrafica='<%#Eval("idanagrafica")%>'>Assegna</asp:LinkButton></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
