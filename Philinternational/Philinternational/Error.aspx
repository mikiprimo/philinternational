<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Philinternational.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Error Main" ContentPlaceHolderID="MainContent" runat="server">
<p>Spiacenti ma la pagina richiesta non è stata trovata.</p>
<p>Se l'errore persiste potete segnalarcelo direttamente da <asp:HyperLink runat="server" ID="linkContatti" NavigateUrl="~/Varie/contatti.aspx" Text="questo link"></asp:HyperLink>  </p>
</asp:Content>
