<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="news.aspx.cs" Inherits="Philinternational.Management.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/NewsScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Elenco
    news</h1>
    <asp:HyperLink ID="hlNewNews" runat="server" ToolTip="Inserisci una nuova news" NavigateUrl="newsDetail.aspx">Inserisci una nuova news</asp:HyperLink>
    <asp:LinkButton ID="btnEraseSelectedNews" runat="server" ToolTip="Cancella le News selezionate" OnClick="btnEraseSelectedNews_OnClick"></asp:LinkButton>
    <div style="width: 100%">
        <asp:Repeater ID="repeaterNews" runat="server" DataSourceID="NewsConnector" DataMember="DefaultView">
            <ItemTemplate>
                <div>
                    <br />
                    <strong><%#Eval("titolo")%></strong> <br />
                    <a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%# Eval("data_pubblicazione")%></a>
                    <br />
                    <%--                    stato: <input id="statusCheckBox_<%#Eval("idnews")%>" runat="server" type="checkbox" onclick="ChangeStatusCheckBox(<%#Eval("idnews")%>);" />
                    <div id="lblStatus_<%#Eval("idnews")%>"><%#ConvertiStato((int)Eval("stato"))%></div>--%>
                    <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idnews")%>'
                        OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" />
                    <br />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="NewsConnector" runat="server" ProviderName="MySql.Data.MySqlClient">
        </asp:SqlDataSource>
    </div>
</asp:Content>
