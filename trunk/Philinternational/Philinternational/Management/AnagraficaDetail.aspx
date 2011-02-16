<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnagraficaDetail.aspx.cs" Inherits="Philinternational.Management.AnagraficaDetail" %>
<%@ Register src="~/UserControls/UserProfileMask.ascx" tagname="UserProfileMask" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UserProfileMask ID="UserProfileMask1" runat="server" />
</asp:Content>
