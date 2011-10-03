<%@ Page Title="Offerta per singolo lotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="offerta.aspx.cs" Inherits="Philinternational.offerta" %>
<%@ OutputCache CacheProfile="Cache24Hours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title><asp:Literal runat="server" ID="testoTitle"></asp:Literal></title>
</asp:Content>
<asp:Content ID="OffertaMain" ContentPlaceHolderID="MainContent" runat="server">
    <h3 id="testoH1" runat="server" class="titlePanel" style="text-transform:uppercase;color:#000"></h3>
    <div class="bloccoOfferta">
        <p id="LoadImmagineOutput" runat="server">Immagine</p>
        <p>Anno: <span id="annoLotto" runat="server"></span></p>
        <p class="descrizioneLotto" id="descrizioneLotto" runat="server"></p>
        <p>Condizione: <span id="statoLotto" runat="server"></span></p>
        <p>Prezzo: <span id="prezzoLotto" runat="server"></span></p>
        <p id="showButton" runat="server">
           <asp:TextBox runat="server" ID="txtOfferta"  MaxLength="12" Rows="10" Width="100px"></asp:TextBox>&nbsp;
           <asp:Button Text="Effettua l'offerta" runat="server" ID="buttonOfferta" /></p>
        <p class="esitoOperazione" id="EsitoOperazione" runat="server"></p>
        <asp:HiddenField runat="server" id="codiceLotto" />
    </div>  
</asp:Content>
