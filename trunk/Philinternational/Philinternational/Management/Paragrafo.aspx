<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Paragrafo.aspx.cs" Inherits="Philinternational.Styles.Paragrafo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gvParagrafi" runat="server" AllowPaging="True" EnableModelValidation="True"
    DataSourceID="ParagrafoConnector" AutoGenerateColumns="False" 
        DataKeyNames="idparagrafo" onrowupdating="gvParagrafi_RowUpdating">
    <Columns>
        <asp:BoundField DataField="idparagrafo" HeaderText="ID" ReadOnly="True" 
            SortExpression="idparagrafo" />
        <asp:CommandField ShowCancelButton="False" ShowEditButton="True">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
        </asp:CommandField>
        <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
        <asp:BoundField DataField="stato" HeaderText="Stato" />
    </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="ParagrafoConnector" runat="server" ProviderName="MySql.Data.MySqlClient"    
        UpdateCommand="UPDATE paragrafo SET descrizione = ?descrizione, stato =?stato WHERE idparagrafo = ?idparagrafo">
    </asp:SqlDataSource>
</asp:Content>
