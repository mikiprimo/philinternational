<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="offerta.aspx.cs" Inherits="Philinternational.offerta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="testoH1">ddd</h1>
    <div>
            <p id="LoadImmagineOutput" runat="server">Immagine</p>
            <p>Anno: <span id="annoLotto" runat="server"></span></p>
            <p id="descrizioneLotto" runat="server"></p>
            <p>Condizione: <span id="statoLotto" runat="server"></span></p>
            <p>Prezzo: <span id="prezzLotto" runat="server"></span></p>
            <p><asp:TextBox runat="server" ID="txtOfferta" ></asp:TextBox></p>
            <p><asp:Button Text="Efettua l'offerta" runat="server" /></p>
        </div>  
</asp:Content>
