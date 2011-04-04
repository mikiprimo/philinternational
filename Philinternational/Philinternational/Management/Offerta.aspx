<%@ Page Title="Elenco Offerta Finale Lotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offerta.aspx.cs" Inherits="Philinternational.OffertaFinale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="titlePanel">Proposte ricevute</h3>
    <fieldset>
        <legend>Opzioni</legend>
        <asp:LinkButton runat="server" id="estraiLotto" OnClick="estraiDati" CssClass="bottone">Estrai Lotti</asp:LinkButton>&nbsp;
        <asp:LinkButton runat="server" id="elencoCompleto" OnClick="showElencoCompleto" CssClass="bottone">Mostra elenco completo</asp:LinkButton>
        <asp:LinkButton runat="server" id="elencoAssegnati" OnClick="showElencoAssegnati" CssClass="bottone">Mostra elenco assegnati</asp:LinkButton>
    </fieldset>
    <fieldset runat="server" id="fldMessaggi">
        <legend>Messaggi</legend>
        <span id="esitoEstrazione" runat="server" class="messaggi"></span>
    </fieldset>
    <asp:SqlDataSource ID="OfferteConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <table>
        <tr>
            <th>Lotto</th>
            <th>Persona</th>
            <th>Data Offerta</th>
            <th>Offerta</th>
            <th>&nbsp;</th>
        </tr>    
    <asp:Repeater runat="server" ID="listaLotti" DataSourceID="OfferteConnector" OnItemCommand="R_ItemCommand" OnItemDataBound="R1_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td style="text-align:right"><label id="idlotto" runat="server"><%#Eval("idlotto")%></label></td>
                <td><%#Eval("persona")%></td>
                <td><%#Eval("data_inserimento")%></td>
                <td style="text-align:right"><%#Eval("prezzo_offerto")%> &euro;</td>
                <td style="text-align:center">
                    <asp:LinkButton ID="assegnaLotto" runat="server" myIdLotto='<%#Eval("idlotto")%>' myIdOfferta='<%#Eval("idofferta")%>' myIdAnagrafica='<%#Eval("idanagrafica")%>'>Assegna</asp:LinkButton>
                    <asp:Label runat="server" ID="lottoAssegnato" Visible="false">Già assegnato</asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
