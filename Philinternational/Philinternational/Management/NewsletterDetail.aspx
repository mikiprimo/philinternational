<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NewsletterDetail.aspx.cs" Inherits="Philinternational.Management.NewsletterDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Nuova
    newsletter</h1>
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate><p>
            <asp:TextBox ID="txtDataCreazione" runat="server" Enabled="False"></asp:TextBox>
            <asp:Calendar ID="calDataCreazione" runat="server" OnSelectionChanged="calDataCreazione_SelectionChanged">
            </asp:Calendar>
        </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <p>
        <asp:Label ID="lblTitolo" runat="server">Titolo: </asp:Label>
        <asp:TextBox ID="txtTitolo" runat="server"></asp:TextBox>
    </p>
    <br />
    <p>
        <asp:Label ID="lblTesto" runat="server">Testo: </asp:Label>
        <asp:TextBox ID="txtTesto" runat="server"></asp:TextBox>
    </p>
    <br />
    <p>
        <asp:Button ID="btnConferma" runat="server" Text="Conferma" OnClick="btnConferma_Click" />&nbsp;
        <asp:Button ID="buttonReset" runat="server" Text="Reset" OnClick="pulisci" />&nbsp;
        <asp:Button ID="btnComeBack" runat="server" Text="Torna Indietro" OnClick="comeBack" />
    </p>
</asp:Content>
