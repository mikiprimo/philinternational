<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AstaDetail.aspx.cs" Inherits="Philinternational.Management.AstaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Nuova Asta
</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <p>
            <asp:TextBox ID="txtDataFine" runat="server" Enabled="False"></asp:TextBox>
            <asp:Calendar ID="calDataFine" runat="server" OnSelectionChanged="calDataFine_SelectionChanged">
            </asp:Calendar>
        </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:CheckBox ID="chkStatus" runat="server" /><br />
    <br />
    <p>
        <asp:Button ID="btnConferma" runat="server" Text="Conferma" OnClick="btnConferma_Click" />&nbsp;
        <asp:Button runat="server" Text="Reset" ID="buttonReset" OnClick="pulisci" />&nbsp;
        <asp:Button runat="server" Text="Torna Indietro" ID="btnComeBack" OnClick="comeBack" />
    </p>
</asp:Content>
