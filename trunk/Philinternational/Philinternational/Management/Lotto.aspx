<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Lotto.aspx.cs" Inherits="Philinternational.Management.Lotto" %>

<%@ Import Namespace="System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Gestione
    Lotti
    <asp:Label ID="lblLottiSection" runat="server" Text="Pubblicati"></asp:Label></h1>
    <hr />
    <br />
    <asp:Panel ID="pnlChooseView" runat="server" ClientIDMode="Static" Direction="LeftToRight"
        HorizontalAlign="Left" ViewStateMode="Enabled" Wrap="False"><span style="valign: center;">
            Seleziona i lotti che vuoi visualizzare:
            <asp:DropDownList ID="ddlSelectedView" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectedView_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Lotti</asp:ListItem>
                <asp:ListItem Value="1">Lotti temporanei</asp:ListItem>
                <asp:ListItem Value="2">Lotti scartati</asp:ListItem>
            </asp:DropDownList>
        </span></asp:Panel>
    <br />
    <hr />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="txtStringaRicerca" runat="server" />
    <asp:ImageButton ID="ibtnCercaLotto" runat="server" AlternateText="Cerca" OnClick="ibtnCercaLotto_Click" />
    <br />
    <asp:MultiView ID="mvLotti" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewLottiPubblicati" runat="server"><asp:ImageButton ID="ibtnCancellaLottiSelezionati"
            runat="server" AlternateText="Cancella lotti selezionati" OnClick="ibtnCancellaLottiSelezionati_Click" /><br />
            <asp:GridView ID="gvLottiPubblicati" runat="server" AllowPaging="True" EnableTheming="True"
                OnPageIndexChanged="gvLottiPubblicati_PageIndexChanged" OnPageIndexChanging="gvLottiPubblicati_PageIndexChanging"
                AutoGenerateColumns="False" ShowHeader="False" DataKeyNames="idlotto" OnRowDataBound="gvLottiPubblicati_RowDataBound"
                GridLines="None" EmptyDataText="Non é presente alcun lotto." PageSize="15">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditLotto" runat="server" NavigateUrl='<%# "~/Management/LottoDetail.aspx?type=pub&id=" + DataBinder.Eval (Container.DataItem,"idlotto")%>'>Modifica</asp:HyperLink>
                        </ItemTemplate>
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
                            <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>' Text='<%# " [ " + ((String)Eval("descrizione")).Substring(0, 15) + "... ] " %>'></asp:Label></ItemTemplate>
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
                                <ContentTemplate><asp:HiddenField ID="hiddenIdStato" runat="server" Value='<%# Eval("stato") %>' />
                                    <asp:HiddenField ID="HiddenIdLotto" runat="server" Value='<%# Eval("idlotto") %>' />
                                    <asp:DropDownList ID="ddlStati" runat="server" OnSelectedIndexChanged="ddlStati_SelectedIndexChanged"
                                        AutoPostBack="True"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="viewLottiTemporanei" runat="server"><asp:ImageButton ID="ibtnCancellaLottiTemporaneiSelezionati"
            runat="server" AlternateText="Cancella lotti selezionati" OnClick="ibtnCancellaLottiTemporaneiSelezionati_Click" />
            <asp:GridView ID="gvLottiTemporanei" runat="server" AllowPaging="True" OnPageIndexChanged="gvLottiTemporanei_PageIndexChanged"
                OnPageIndexChanging="gvLottiTemporanei_PageIndexChanging" AutoGenerateColumns="false"
                ShowHeader="false" DataKeyNames="idcatalogo" GridLines="None" EmptyDataText="Non é presente alcun lotto temporaneo."
                PageSize="15">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditLottoTemp" runat="server" NavigateUrl='<%# "~/Management/LottoDetail.aspx?type=tmp&id=" + DataBinder.Eval (Container.DataItem,"idcatalogo")%>'>Modifica</asp:HyperLink>
                        </ItemTemplate>
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
                            <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>' Text='<%# " [ " + ((String)Eval("descrizione")).Substring(0, 15) + "... ] " %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPrezzoBase" runat="server" Text='<%# Bind("prezzo_base") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblRiferimentoSassone" runat="server" Text='<%# Bind("riferimento_sassone") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="viewLottiScartati" runat="server">
            <asp:GridView ID="gvLottiScartati" runat="server" AllowPaging="True" OnPageIndexChanged="gvLottiScartati_PageIndexChanged"
                OnPageIndexChanging="gvLottiScartati_PageIndexChanging" AutoGenerateColumns="false"
                ShowHeader="false" DataKeyNames="idlotto_scartato" GridLines="None" EmptyDataText="Non é presente alcun lotto scartato."
                PageSize="15">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>' Text='<%# " [ " + ((String)Eval("descrizione")).Substring(0, 15) + "... ] " %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
