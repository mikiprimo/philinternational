<%@ Page Title="Gestione delle aste" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Aste.aspx.cs" Inherits="Philinternational.Styles.Aste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Gestione Aste</h3>
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Crea una nuova asta"
        OnClick="ibtnCreateAsta_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/creanuova.png" />&nbsp;<asp:ImageButton
            ID="ImageButton2" runat="server" OnClick="ibtnDeleteSelectedAste_Click" AlternateText="Cancella le aste selezionate"
            CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png" />
    <br />
    <br />
    <asp:GridView ID="gvAste" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="idasta" EmptyDataText="Nessuna asta attualmente presente." GridLines="None"
        ShowHeader="False" OnPageIndexChanged="gvAste_PageIndexChanged" OnPageIndexChanging="gvAste_PageIndexChanging"
        OnRowEditing="gvAste_RowEditing" OnRowUpdating="gvAste_RowUpdating" PageSize="15">
        <RowStyle CssClass="RowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><asp:ImageButton ID="ibtnEditAste" runat="server" CausesValidation="False"
                    CommandName="Edit" ImageUrl="~/images/selectfull.png" />
                </ItemTemplate>
                <EditItemTemplate><asp:ImageButton ID="ibtnUpdateAste" runat="server" CausesValidation="False"
                    CommandName="Update" ImageUrl="~/images/accept.png" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblEditData" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Eval("data_fine")) %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblEditDataUpdate" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Eval("data_fine")) %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox ID="chkStatus" runat="server" Enabled="False" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </ItemTemplate>
                <EditItemTemplate><asp:CheckBox ID="chkUpdateStatus" runat="server" Checked='<%# Philinternational.Layers.Commons.GetStatoBoolean(Convert.ToInt32(Eval("stato"))) %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:ImageButton ID="ibtnCreateAsta" runat="server" AlternateText="Crea una nuova asta"
        OnClick="ibtnCreateAsta_Click" CssClass="cleanButtons" ImageUrl="~/images/commands/creanuova.png" />&nbsp;<asp:ImageButton
            ID="ibtnDeleteSelectedAste" runat="server" OnClick="ibtnDeleteSelectedAste_Click"
            AlternateText="Cancella le aste selezionate" CssClass="cleanButtons" ImageUrl="~/images/commands/cancella.png" />
</asp:Content>
