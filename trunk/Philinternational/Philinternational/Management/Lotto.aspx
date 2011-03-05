<%@ Page Title="Gestione singoli Lotti" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Lotto.aspx.cs" Inherits="Philinternational.Management.Lotto" %>

<%@ Import Namespace="System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="titlePanel">Gestione Lotti
    <asp:Label ID="lblLottiSection" runat="server" Text="Pubblicati"></asp:Label></h3>
    <br />
    <asp:Panel ID="pnlChooseView" runat="server" ClientIDMode="Static" Direction="LeftToRight"
        HorizontalAlign="Left" ViewStateMode="Enabled" Wrap="False"><span style="text-align: center;">
            Seleziona i lotti che vuoi visualizzare:
            <asp:DropDownList ID="ddlSelectedView" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectedView_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Lotti</asp:ListItem>
                <asp:ListItem Value="1">Lotti temporanei</asp:ListItem>
                <asp:ListItem Value="2">Lotti scartati</asp:ListItem>
            </asp:DropDownList>
        </span></asp:Panel>
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="txtStringaRicerca" runat="server" />
    &nbsp;<asp:ImageButton ID="ibtnCercaLotto" runat="server" AlternateText="Cerca" OnClick="ibtnCercaLotto_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/cerca.png" />
    <br />
    <asp:MultiView ID="mvLotti" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewLottiPubblicati" runat="server"><br /><asp:ImageButton ID="ibtnCancellaLottiSelezionati"
            runat="server" AlternateText="Cancella lotti selezionati" OnClick="ibtnCancellaLottiSelezionati_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png" />&nbsp;
            <asp:ImageButton ID="ibtnAttivaLottiSelezionati" runat="server" AlternateText="Attiva lotti selezionati"
                OnClick="ibtnAttivaLottiSelezionati_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/attiva.png" />&nbsp;
            <asp:ImageButton ID="ibtnInsertNewLotto" runat="server" AlternateText="Inserisci lotto"
                OnClick="ibtnInsertNewLotto_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/creanuovo.png" />&nbsp;
            <asp:ImageButton ID="ibtnDisassociaLotti" runat="server" 
                AlternateText="Disassocia lotti selezionati" 
                onclick="ibtnDisassociaLotti_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/disassocia.png" />&nbsp;
            <br />
            <br />
            <asp:GridView ID="gvLottiPubblicati" runat="server" AllowPaging="True" EnableTheming="True"
                OnPageIndexChanged="gvLottiPubblicati_PageIndexChanged" OnPageIndexChanging="gvLottiPubblicati_PageIndexChanging"
                AutoGenerateColumns="False" DataKeyNames="idlotto" OnRowDataBound="gvLottiPubblicati_RowDataBound"
                GridLines="None" EmptyDataText="Non é presente alcun lotto." PageSize="50">
                <RowStyle CssClass="RowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="lotto">
                        <ItemTemplate>
                            <asp:Label ID="lblIdLotto" runat="server" Text='<%# Bind("idlotto") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="descrizione">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditLotto" runat="server" NavigateUrl='<%# "~/Management/LottoDetail.aspx?type=pub&id=" + DataBinder.Eval (Container.DataItem,"idlotto")%>'>
                                <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>'
                                    Text='<%# " [ " + GeneralUtilities.SubString(((String)Eval("descrizione")), 15) + "... ] " %>'></asp:Label>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="anno">
                        <ItemTemplate>
                            <asp:Label ID="lblAnno" runat="server" Text='<%# Bind("anno") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="€ base">
                        <ItemTemplate>
                            <asp:Label ID="lblPrezzoBase" runat="server" Text='<%# Bind("prezzo_base") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="€">
                        <ItemTemplate>
                            <asp:Label ID="lblEuro" runat="server" Text='<%# Bind("euro") %>'></asp:Label></ItemTemplate>
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
        <asp:View ID="viewLottiTemporanei" runat="server"><br /><asp:ImageButton ID="ibtnCancellaLottiTemporaneiSelezionati"
            runat="server" AlternateText="Cancella lotti selezionati" OnClick="ibtnCancellaLottiTemporaneiSelezionati_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png" />&nbsp;
            <asp:ImageButton ID="ibtnTransferLotto" runat="server" AlternateText="Trasferisci lotto nella tabella lotti"
                OnClick="ibtnTransferLotto_Click" Visible="false" CssClass="cleanButtons" ImageUrl="~/images/commands/trasferisci.png"/>&nbsp;
            <asp:ImageButton ID="ibtnOpenTransferPanel" runat="server" AlternateText="Trasferisci lotti..."
                OnClick="ibtnOpenTransferPanel_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/trasferisci.png" />
            <div id="divTransferOptionsPanel" runat="server" visible="false">
                <table>
                    <tr>
                        <td>
                            Paragrafo:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPar" runat="server" DataValueField="idparagrafo" DataTextField="descrizione"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPar_SelectedIndexChanged" OnDataBound="ddlPar_DataBound">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <div id="divArgPanel" runat="server" visible="false">
                        <tr>
                            <td>
                                Argomento
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlArg" runat="server" DataValueField="idargomento" DataTextField="descrizione"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlArg_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                    </div>
                    <div id="divSubArgPanel" runat="server" visible="false">
                        <tr>
                            <td>
                                SubArgomento
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubArg" runat="server" DataValueField="idsub_argomento"
                                    DataTextField="descrizione" AutoPostBack="true"></asp:DropDownList>
                                <asp:Label ID="lblNotPresentSubArg" runat="server" Visible="false">Nessun sub argomento presente</asp:Label>
                            </td>
                        </tr>
                    </div>
                    <div id="divAttivaFinalPanel" runat="server" visible="false">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkAtt" runat="server" Text="Attiva i trasferiti" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtnTranferMultipleLottiAction" runat="server" AlternateText="Trasferisci"
                                    OnClick="ibtnTranferMultipleLottiAction_Click" Width="16px" />
                            </td>
                        </tr>
                    </div>
                </table>
            </div>
            <asp:GridView ID="gvLottiTemporanei" runat="server" AllowPaging="True" OnPageIndexChanged="gvLottiTemporanei_PageIndexChanged"
                OnPageIndexChanging="gvLottiTemporanei_PageIndexChanging" AutoGenerateColumns="false"
                DataKeyNames="idcatalogo" GridLines="None" EmptyDataText="Non é presente alcun lotto temporaneo."
                PageSize="50">
                <RowStyle CssClass="RowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="lotto">
                        <ItemTemplate>
                            <asp:Label ID="lblIdCatalogo" runat="server" Text='<%# Bind("idcatalogo") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="descrizione">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditLottoTemp" runat="server" NavigateUrl='<%# "~/Management/LottoDetail.aspx?type=tmp&id=" + DataBinder.Eval (Container.DataItem,"idcatalogo")%>'>
                                <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>'
                                    Text='<%# " [ " + GeneralUtilities.SubString(((String)Eval("descrizione")), 15) + "... ] " %>'></asp:Label>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="anno">
                        <ItemTemplate>
                            <asp:Label ID="lblAnno" runat="server" Text='<%# Bind("anno") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="€ base">
                        <ItemTemplate>
                            <asp:Label ID="lblPrezzoBase" runat="server" Text='<%# Bind("prezzo_base") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="€">
                        <ItemTemplate>
                            <asp:Label ID="lblEuro" runat="server" Text='<%# Bind("euro") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="viewLottiScartati" runat="server">
            <asp:GridView ID="gvLottiScartati" runat="server" AllowPaging="True" OnPageIndexChanged="gvLottiScartati_PageIndexChanged"
                OnPageIndexChanging="gvLottiScartati_PageIndexChanging" AutoGenerateColumns="false"
                DataKeyNames="idlotto_scartato" GridLines="None" EmptyDataText="Non é presente alcun lotto scartato."
                PageSize="50">
                <RowStyle CssClass="RowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="descrizione">
                        <ItemTemplate>
                            <asp:Label ID="lblDescrizione" runat="server" ToolTip='<%# Bind("descrizione") %>'
                                Text='<%# " [ " + ((String)Eval("descrizione")).Substring(0, 15) + "... ] " %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
