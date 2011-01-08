<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aste.aspx.cs" Inherits="Philinternational.Styles.Aste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvAste" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False"></asp:GridView>

</asp:Content>