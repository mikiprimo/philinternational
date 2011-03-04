<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Varie.aspx.cs" Inherits="Philinternational.Styles.Varie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="titlePanel">Varie</h3>
<fieldset>
    <legend>Lotti</legend>
    <asp:LinkButton runat="server" ID="allineaImmagine" OnClick="aggiornaDatabase" Text="Aggiorna DataBase Immagini"></asp:LinkButton>
    <asp:Label runat="server" ID="esitoImmagine" ></asp:Label>
</fieldset>
</asp:Content>
