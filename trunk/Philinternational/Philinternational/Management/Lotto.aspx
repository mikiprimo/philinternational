<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lotto.aspx.cs" Inherits="Philinternational.Management.Lotto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="mvLotti" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewLottiTemporanei" runat="server">
            <asp:GridView ID="gvLottiTemporanei" runat="server" AutoGenerateColumns="false" />
            <asp:ImageButton ID="ibtnPubblicaLottiSelezionati" runat="server" OnClick="ibtnPubblicaLottiSelezionati_Click" />
        </asp:View>
        <asp:View ID="viewLottiPubblicati" runat="server">
            <asp:GridView ID="gvLottiPubblicati" runat="server" AutoGenerateColumns="false" />
            <asp:ImageButton ID="ibtnAttivaSelezionati" runat="server" onclick="ibtnAttivaSelezionati_Click" />
            <asp:ImageButton ID="ibtnDisattivaSelezionati" runat="server" onclick="ibtnDisattivaSelezionati_Click" style="height: 16px" />
            <asp:TextBox ID="txtStringaRicerca" runat="server" />
            <asp:ImageButton ID="ibtnCercaLotto" runat="server" onclick="ibtnCercaLotto_Click" />
        </asp:View>
        <asp:View ID="viewLottiScartati" runat="server"></asp:View>
    </asp:MultiView>
</asp:Content>
