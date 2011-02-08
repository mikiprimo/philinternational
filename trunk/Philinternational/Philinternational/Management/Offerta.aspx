<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offerta.aspx.cs" Inherits="Philinternational.Styles.Offerta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="OfferteElenco" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <asp:LinkButton runat="server" id="estraiLotto">Estrai Lotti</asp:LinkButton>
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
                <td><asp:LinkButton ID="assegnaLotto" runat="server">Assegna</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
    <tr class="alternate">
                <td style="text-align:right"><%#Eval("idlotto")%></td>
                <td><%#Eval("persona")%></td>
                <td><%#Eval("data_inserimento")%></td>
                <td style="text-align:right"><%#Eval("prezzo_offerto")%></td>
            </tr>
        
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
