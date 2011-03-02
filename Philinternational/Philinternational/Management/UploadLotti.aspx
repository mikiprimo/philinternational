<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadLotti.aspx.cs" Inherits="Philinternational.Management.UploadLotti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="titlePanel">Caricamento Asta</h3>
    <fieldset>
        <legend>Seleziona il file in formato .txt</legend>
        <p></p><asp:FileUpload ID="FileLotto" runat="server"  />
        <asp:Button ID="Button1" runat="server" Text="Carica" onclick="Button1_Click" /><br /></p>
        <p><br /><asp:Label runat="server" ID="esitoUpload" CssClass="messaggi"></asp:Label></p>
    </fieldset>
</asp:Content>
