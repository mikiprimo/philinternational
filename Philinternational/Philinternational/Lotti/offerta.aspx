<%@ Page Title="Offerta per lotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="offerta.aspx.cs" Inherits="Philinternational.offerta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="testoH1" runat="server" style="text-transform:uppercase;color:#000"></h1>
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
