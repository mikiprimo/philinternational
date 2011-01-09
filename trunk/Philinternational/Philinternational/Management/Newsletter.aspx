<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="Philinternational.Styles.Newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Getione Newsletter</h1>
<asp:GridView
    ID="gvNewsletters" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="idnewsletter" GridLines="None" 
        ShowHeader="False"></asp:GridView>
</asp:Content>
