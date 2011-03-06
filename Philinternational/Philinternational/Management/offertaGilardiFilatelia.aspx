<%@ Page Title="Elenco offerte GilardiFilatelia.it" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="offertaGilardiFilatelia.aspx.cs" Inherits="Philinternational.Management.offertaGilardiFilatelia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Offerte Gilardi Filatelia</h3>
    <br />
    <asp:ImageButton ID="ibtnNuovaOfferta" runat="server" AlternateText="Inserisci un nuovo lotto dal sito Gilardi Filatelia"
        ToolTip="Inserisci un nuovo lotto dal sito Gilardi Filatelia" CssClass="cleanButtons"
        ImageUrl="~/images/commands/creanuova.png" OnClick="ibtnNuovaOfferta_Click" />
    <asp:ImageButton ID="ibtnCancellaNewsSelezionati" runat="server" AlternateText="Cancella i lotti selezionati"
        ToolTip="Cancella i lotti selezionati" CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png"
        OnClick="ibtnCancellaNewsSelezionati_Click" /><br />
    <br />
    <table style="width: 100%">
        <asp:Repeater ID="repeaterGeneral" runat="server" DataMember="DefaultView">
            <ItemTemplate>
                <tr class="alternate">
                    <td>
                        <asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idofferta")%>' />
                    </td>
                    <td style="width: 15%">
                        <a href="<%=Page.ResolveClientUrl("~/Management/offertaGilardiFilateliaDetail.aspx?cod=")%><%#Eval("idofferta")%>">
                            <%# Eval("idlotto")%></a>
                    </td>
                    <td>
                        <%#Eval("anno")%>
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idofferta")%>'
                            OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkErase" runat="server" MyIDNewsToErase='<%#Eval("idofferta")%>' />
                    </td>
                    <td style="width: 15%">
                        <a href="<%=Page.ResolveClientUrl("~/Management/offertaGilardiFilateliaDetail.aspx?cod=")%><%#Eval("idofferta")%>">
                            <%# Eval("idlotto")%></a>
                    </td>
                    <td>
                        <%#Eval("anno")%>
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true" MyIDNews='<%#Eval("idofferta")%>'
                            OnDataBinding="chkStatus_OnDataBinding" OnCheckedChanged="chkStatus_OnCheckedChanged" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
