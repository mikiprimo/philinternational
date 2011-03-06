<%@ Page Title="Gestione delle news" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Philinternational.Management.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Elenco news</h3>
    <br />
    <asp:ImageButton ID="ibtnCreaNews" runat="server" AlternateText="Crea nuova news"
        CssClass="cleanButtons" ImageUrl="~/images/commands/creanuova.png" OnClick="ibtnCreaNews_Click" />&nbsp;<asp:ImageButton
            ID="ibtnCancellaNews" runat="server" AlternateText="Cancella news selezionate"
            ToolTip="Cancella le news selezionate" CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png"
            OnClick="ibtnCancellaNews_Click" /><br />
    <br />
    <table style="width: 100%">
        <asp:Repeater ID="repeaterNews" runat="server" DataMember="DefaultView">
            <ItemTemplate>
                <tr class="alternate">
                    <td width="18px">
                        <asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idnews")%>' />
                    </td>
                    <td style="width: 15%">
                        <a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%# Eval("data_pubblicazione")%></a>
                    </td>
                    <td>
                        <%#Eval("titolo")%>
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idnews")%>'
                            OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td width="18px">
                        <asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idnews")%>' />
                    </td>
                    <td style="width: 15%">
                        <a href="newsDetail.aspx?cod=<%#Eval("idnews")%>"><%# Eval("data_pubblicazione")%></a>
                    </td>
                    <td>
                        <%#Eval("titolo")%>
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idnews")%>'
                            OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Crea nuova news"
        CssClass="cleanButtons" ImageUrl="~/images/commands/creanuova.png" OnClick="ibtnCreaNews_Click" />&nbsp;<asp:ImageButton
            ID="ImageButton2" runat="server" AlternateText="Cancella news selezionate" ToolTip="Cancella le news selezionate"
            CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png" OnClick="ibtnCancellaNews_Click" /><br />
</asp:Content>
