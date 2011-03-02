<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="news.aspx.cs" Inherits="Philinternational.Management.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="titlePanel">Elenco news</h3>
    <fieldset>
        <legend>Opzioni</legend>
        <asp:HyperLink ID="hlNewNews" runat="server"  CssClass="bottone" ToolTip="Inserisci una nuova news" NavigateUrl="newsDetail.aspx">Inserisci una nuova news</asp:HyperLink>
        <asp:LinkButton ID="btnEraseSelectedNews" CssClass="bottone" runat="server" ToolTip="Cancella le News selezionate" OnClick="btnEraseSelectedNews_OnClick">Cancella le News selezionate</asp:LinkButton>
    </fieldset>
     <table style="width:100%">
<%--        <tr>
            <th align="center">&nbsp;</th>
            <th>Data</th>
            <th>Titolo</th>
            <th>Stato</th>
        </tr>--%>
        <asp:Repeater ID="repeaterNews" runat="server"  DataMember="DefaultView">
            <ItemTemplate>
                <tr class="alternate">
                    <td><asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idnews")%>' /></td>
                    <td style="width:15%"><a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%# Eval("data_pubblicazione")%></a></td>
                    <td><%#Eval("titolo")%></td>
                    <td style="text-align:left"><asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idnews")%>' OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" /></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <tr>
                    <td><asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idnews")%>' /></td>
                    <td style="width:15%"><a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%# Eval("data_pubblicazione")%></a></td>
                    <td><%#Eval("titolo")%></td>
                    <td style="text-align:left;"><asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idnews")%>' OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" /></td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
<%--        <asp:SqlDataSource ID="NewsConnector" runat="server" ProviderName="MySql.Data.MySqlClient">
        </asp:SqlDataSource>DataSourceID="NewsConnector"--%>
        </table>
</asp:Content>
