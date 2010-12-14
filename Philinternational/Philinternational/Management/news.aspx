<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Philinternational.Management.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Elenco delle news</h1>
    <p><a href="newsDetail.aspx" title="Inserisci una nuova news">Inserisci una nuova news</a></p>
    <div style="width:100%">
        <asp:Repeater ID="repeaterNews" runat="server" DataSourceID="ConnectionDB" 
            DataMember="DefaultView" >
            <HeaderTemplate>
            <table>
                    <tr>
                        <th>Data Pubblicazione</th>
                        <th>Titolo</th>
                        <th>Stato</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%#Eval("data_pubblicazione")%></a></td>
                        <td><%#Eval("titolo")%></td>
                        <td><%#Eval("stato")%></td>
                    </tr>

            </ItemTemplate>
            <AlternatingItemTemplate>
                    <tr class="alternate">
                        <td><a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%#Eval("data_pubblicazione")%></a></td>
                        <td><%#Eval("titolo")%></td>
                        <td><%#Eval("stato")%></td>
                        <td>
                            <asp:HyperLink ID="eliminaRiga" runat="server">Elimina</asp:HyperLink></td>
                    </tr>

            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <asp:SqlDataSource ID="ConnectionDB" runat="server" 
            ProviderName="MySql.Data.MySqlClient" ></asp:SqlDataSource>

</div></asp:Content>
