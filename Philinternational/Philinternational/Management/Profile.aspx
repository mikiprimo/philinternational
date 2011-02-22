<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="Philinternational.Management.Profile" %>

<%@ Register Src="~/UserControls/UserProfileMask.ascx" TagName="UserProfileMask"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><uc1:UserProfileMask
    ID="userProfileMask" runat="server" />
</asp:Content>
