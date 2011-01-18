<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lotto.aspx.cs" Inherits="Philinternational.Management.Lotto" %>
<%@ Import Namespace="System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:MultiView ID="mvLotti" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewLottiPubblicati" runat="server">
            <asp:GridView ID="gvLottiPubblicati" runat="server" AllowPaging="True" EnableTheming="True"
                OnPageIndexChanged="gvLottiPubblicati_PageIndexChanged" OnPageIndexChanging="gvLottiPubblicati_PageIndexChanging"
                AutoGenerateColumns="False" ShowHeader="False" 
                OnRowDataBound="gvLottiPubblicati_RowDataBound" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblAnno" runat="server" Text='<%# Bind("anno") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblTipoLotto" runat="server" Text='<%# Bind("tipo_lotto") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblNumeroPezzi" runat="server" Text='<%# Bind("numero_pezzi") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>' Text= '<%# " [ " + ((String)Eval("descrizione")).Substring(0, 15) + "... ] " %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPrezzoBase" runat="server" Text='<%# Bind("prezzo_base") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblRiferimentoSassone" runat="server" Text='<%# Bind("riferimento_sassone") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:UpdatePanel ID="updPanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hiddenIdStato" runat="server" Value='<%# Eval("stato") %>' />
                                    <asp:HiddenField ID="HiddenIdLotto" runat="server" Value='<%# Eval("idlotto") %>' />
                                    <asp:DropDownList ID="ddlStati" runat="server" 
                                        OnSelectedIndexChanged="ddlStati_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView><br />
            <asp:TextBox ID="txtStringaRicerca" runat="server" />
            <asp:ImageButton ID="ibtnCercaLotto" runat="server" OnClick="ibtnCercaLotto_Click" />
        </asp:View>
        <asp:View ID="viewLottiTemporanei" runat="server">
            <asp:GridView ID="gvLottiTemporanei" runat="server" AllowPaging="True" OnPageIndexChanged="gvLottiTemporanei_PageIndexChanged"
                OnPageIndexChanging="gvLottiTemporanei_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ImageButton ID="ibtnPubblicaLottiSelezionati" runat="server" OnClick="ibtnPubblicaLottiSelezionati_Click" />
        </asp:View>
        <asp:View ID="viewLottiScartati" runat="server"></asp:View>
    </asp:MultiView>
</asp:Content>
