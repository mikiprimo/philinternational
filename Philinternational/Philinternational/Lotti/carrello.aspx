<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="carrello.aspx.cs" Inherits="Philinternational.carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="carrelloMain" ContentPlaceHolderID="MainContent" runat="server"><h1>
    Carrello</h1>
    <br />
    <asp:SqlDataSource ID="CarrelloConnector" runat="server" ProviderName="MySql.Data.MySqlClient">
    </asp:SqlDataSource>
    <asp:Repeater runat="server" ID="elencoCarrello" DataSourceID="CarrelloConnector"
        DataMember="DefaultView" OnItemCommand="R_ItemCommand" ClientIDMode="AutoID"
        ViewStateMode="Enabled">
        <ItemTemplate><ul class="basket">
            <li class="basket_id"><p runat="server" id="idlotto"><%#Eval("idlotto")%></p>
            </li>
            <li class="basket_img"><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto"))%></li>
            <li class="basket_p"><p class="basket_height">Anno: <span id="annoLotto"><%# Eval("anno")%></span></p>
                <p id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p>
                <p class="basket_height">Condizione: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
                <p class="basket_height">Prezzo: <span id="prezzLotto" runat="server"><%# Eval("euro")%></span></p>
            </li>
        </ul>
            <div>
                <asp:TextBox ID="txt_offerta" runat="server" Width="60px"></asp:TextBox>
                <asp:Button runat="server" ID="btnOfferta" Text="Fai l'offerta" OnDataBinding="offerta_OnDataBinding"
                    CommandName="makeOffert" myIdLotto='<%#Eval("idlotto")%>' myIdcarrello='<%#Eval("idcarrello")%>' />
                <asp:LinkButton runat="server" ID="removeBasket" CssClass="remove" Text="Rimuovi dal carrello"
                    CommandArgument='<%#Eval("idcarrello")%>' CommandName="removeBasket"></asp:LinkButton>
            </div>
            <div style="line-height: 20px; background-color: transparent; color: #F00; font-weight: bold">
                <span id="esitoOfferta" runat="server">&nbsp;</span></div>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
