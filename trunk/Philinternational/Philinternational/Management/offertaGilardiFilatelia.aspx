<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="offertaGilardiFilatelia.aspx.cs" Inherits="Philinternational.Management.offertaGilardiFilatelia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Offerte Gilardi Filatelia</h3>
<fieldset>
    <legend>Opzioni</legend>
    <asp:HyperLink runat="server" ID="insNuovaOfferta" ToolTip="Inserisci un nuovo lotto dal sito Gilardi Filatelia"  CssClass="bottone" NavigateUrl="~/Management/offertaGilardiFilateliaDetail.aspx?cod=-1">Inserisci una nuova offerta</asp:HyperLink>
        <asp:LinkButton ID="btnEraseSelectedNews" CssClass="bottone" runat="server" ToolTip="Cancella i Lotti selezionati selezionate" OnClick="btnEraseSelectedNews_OnClick">Cancella le News selezionate</asp:LinkButton>
</fieldset>
<table style="width:100%">
<%--        <tr>
            <th align="center">&nbsp;</th>
            <th>Data</th>
            <th>Titolo</th>
            <th>Stato</th>
        </tr>--%>
        <asp:Repeater ID="repeaterGeneral" runat="server"  DataMember="DefaultView">
            <ItemTemplate>
                <tr class="alternate">
                    <td><asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idofferta")%>' /></td>
                    <td style="width:15%"><a href="~/Management/offertaGilardiFilateliaDetail.aspx?cod=<%#Eval("idofferta")%>"><%# Eval("idlotto")%></a></td>
                    <td><%#Eval("anno")%></td>
                    <td style="text-align:left;"><asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idofferta")%>' OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" /></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <tr>
                    <td><asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idofferta")%>' /></td>
                    <td style="width:15%"><a href="~/Management/offertaGilardiFilateliaDetail.aspx?cod=<%#Eval("idofferta")%>"><%# Eval("idlotto")%></a></td>
                    <td><%#Eval("anno")%></td>
                    <td style="text-align:left;"><asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idofferta")%>' OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" /></td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
<%--        <asp:SqlDataSource ID="NewsConnector" runat="server" ProviderName="MySql.Data.MySqlClient">
        </asp:SqlDataSource>DataSourceID="NewsConnector"--%>
        </table>
</asp:Content>
