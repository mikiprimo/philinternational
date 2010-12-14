<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="news.aspx.cs" Inherits="Philinternational.Management.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Elenco news</h1>
    <asp:HyperLink ID="hlNewNews" runat="server" ToolTip="Inserisci una nuova news" NavigateUrl="newsDetail.aspx">Inserisci una nuova news</asp:HyperLink>
    <div style="width: 100%">
        <asp:Repeater ID="repeaterNews" runat="server" DataSourceID="NewsConnector" DataMember="DefaultView">
            <ItemTemplate>
                <div>
                    <strong><%#Eval("titolo")%></strong>
                    <br />
                    <a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"> <%#Eval("data_pubblicazione")%></a>
                    <br />
                    stato: <%#(ConvertiStato((int)Eval("stato"))) %>
                    <br />
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="alternate">
                    <strong><%#Eval("titolo")%></strong>
                    <br />
                    <a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%#Eval("data_pubblicazione")%></a>
                    <br />
                    stato: <%#(ConvertiStato((int)Eval("stato")))%>
                    <br />
                </div>
            </AlternatingItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="NewsConnector" runat="server" ProviderName="MySql.Data.MySqlClient">
        </asp:SqlDataSource>
    </div>
</asp:Content>
