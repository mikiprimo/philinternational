<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArgoAndSubArgomento.aspx.cs" Inherits="Philinternational.Styles.SubArgomento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"><style
    type="text/css">
                                                                                 .style1
                                                                                 {
                                                                                     width: 300px;
                                                                                 }
                                                                             </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                <asp:HyperLink ID="lnkSelectOtherParagraph" runat="server" NavigateUrl="~/Management/Paragrafo.aspx">Seleziona un altro paragrafo</asp:HyperLink>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:GridView ID="gvArguments" runat="server" AutoGenerateColumns="False" DataKeyNames="idargomento"
                    EmptyDataText="Nessun argomento associato al paragrafo" EnableModelValidation="True"
                    GridLines="None" OnRowEditing="gvArguments_RowEditing" OnRowUpdating="gvArguments_RowUpdating"
                    OnSelectedIndexChanging="gvArguments_SelectedIndexChanging" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate><asp:ImageButton ID="ibtnSelect" runat="server" CausesValidation="False"
                                CommandName="Select" Height="16px" ImageUrl="~/images/select.png" ToolTip="Seleziona questo argomento" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate><asp:ImageButton ID="ibtnEdit" runat="server" CausesValidation="False"
                                CommandName="Edit" Height="16px" ImageUrl="~/images/selectfull.png" ToolTip="Modifica questo argomento" />
                            </ItemTemplate>
                            <EditItemTemplate><asp:ImageButton ID="ibtnUpdate" runat="server" CausesValidation="False"
                                CommandName="Update" Height="16px" ImageUrl="~/images/accept.png" ToolTip="Aggiorna con le modifiche apportate" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblArgDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUpdateDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:TextBox>
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
            </td>
            <td>
                <asp:GridView ID="gvSubArguments" runat="server" AutoGenerateColumns="False" DataKeyNames="idsub_argomento"
                    EnableModelValidation="True" OnRowEditing="gvSubArguments_RowEditing" OnRowUpdating="gvSubArguments_RowUpdating"
                    ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate><asp:CheckBox ID="chkSubArgsUserSelection" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate><asp:ImageButton ID="ibtnEditSubArgument" runat="server" CausesValidation="False"
                                CommandName="Edit" Height="16px" ImageUrl="~/images/selectfull.png" ToolTip="Modifica questo argomento" />
                            </ItemTemplate>
                            <EditItemTemplate><asp:ImageButton ID="ibtnEditSubArgument" runat="server" CausesValidation="False"
                                CommandName="Update" Height="16px" ImageUrl="~/images/accept.png" ToolTip="Aggiorna con le modifiche apportate" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblSubArgDescription" runat="server" Text='<%# Bind("descrizione") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSubArgDescriptionEdit" runat="server" Text='<%# Bind("descrizione") %>'></asp:TextBox>
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
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:ImageButton ID="ibtnDeleteSelectedArgs" runat="server" AlternateText="Cancella selezionati"
                    ToolTip="Argomenti selezionati" /><br />
                <asp:ImageButton ID="ibtnCreateNewArgument" runat="server" AlternateText="Crea un nuovo argomento" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnDeleteSelectedSubArguments" runat="server" AlternateText="Cancella selezionati"
                    ToolTip="Sub argomenti selezionati" /><br />
                <asp:ImageButton ID="ibtnCreateNewSubArgument" runat="server" AlternateText="Crea un nuovo sub argomento" />
            </td>
        </tr>
    </table>
</asp:Content>
