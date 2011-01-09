<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aste.aspx.cs" Inherits="Philinternational.Styles.Aste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvAste" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="idasta" EmptyDataText="Nessuna asta attualmente presente." GridLines="None"
        ShowHeader="False">
        <Columns>
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
                    <asp:Label ID="lblEditData" runat="server" Text='<%# Eval("data_fine") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblEditData" runat="server" Text='<%# Eval("data_fine") %>'></asp:Label>
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
</asp:Content>
