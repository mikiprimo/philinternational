<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LottoDetail.aspx.cs" Inherits="Philinternational.Management.LottoDetail" %>

<%@ Register Src="../UserControls/LottoDetailEditingMask.ascx" TagName="LottoDetailEditingMask"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><uc1:LottoDetailEditingMask
    ID="LottoDetailEditingMask1" runat="server" />
</asp:Content>
