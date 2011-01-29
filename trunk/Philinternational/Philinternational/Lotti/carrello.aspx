<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrello.aspx.cs" Inherits="Philinternational.carrello" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carrello</h1>
    <hr />
    <asp:SqlDataSource ID="CarrelloConnector" runat="server" ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:Repeater runat="server" ID="elencoCarrello" DataSourceID="CarrelloConnector"  DataMember="DefaultView">
    <ItemTemplate>
            <ul style="list-style:none;border:0px;margin:2px 0px;display:block;clear:both">
                <li style="width:5%;float:left;display:inline;text-align:center;background-color:#eee;line-height:110px;"><%#Eval("idlotto")%></li>
                <li style="width:25%;float:left;display:inline;padding:2px 0px;text-align:center;height:110px"><%# loadImmagine(DataBinder.Eval(Container.DataItem, "idlotto"))%></li>
                <li style="width:50%;float:left;display:inline">
                    <p style="background-color:green;line-height:20px">Anno: <span id="annoLotto"><%# Eval("anno")%></span></p>
                    <p style="background-color:red;padding:4px" id="descrizioneLotto" runat="server"><%# Eval("descrizione")%></p>
                    <p style="background-color:yellow;line-height:20px"">Condizione: <span id="statoLotto" runat="server"><%# Eval("tipo_lotto")%></span></p>
                    <p style="background-color:gray;line-height:20px;">Prezzo: <span id="prezzLotto" runat="server"><%# Eval("euro")%></span></p>
                </li>
                <li style="width:20%;float:left;display:inline">
                    <p><asp:TextBox ID="TextBox1" runat="server" Width="60px"></asp:TextBox></p>
                    <p><asp:Button  text="Fai Offerta" runat="server" ID="btnOfferta"/></p>
                    <p><asp:LinkButton runat="server" ID="dd" Text="Rimuovi dal carrello"></asp:LinkButton></p>
                </li>
            </ul>
        
        
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
