<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UploadLotti.aspx.cs" Inherits="Philinternational.Management.UploadLotti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"><style
    type="text/css">
                                                                                 .style1
                                                                                 {
                                                                                     width: 91px;
                                                                                 }
                                                                                 .style2
                                                                                 {
                                                                                     width: 227px;
                                                                                 }
                                                                             </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h3
    class="titlePanel">Caricamento Asta</h3>
    <fieldset><legend>Seleziona il file in formato .txt</legend><p></p>
        <br />
        <table>
            <tr class="commandPanel">
                <td class="style2">
                    <asp:FileUpload ID="FileLotto" runat="server" />
                </td>
                <td class="style1">
                    <asp:ImageButton ID="ibtnUploadLotti" runat="server" ToolTip="Carica i lotti da file in formato text (txt)"
                        ImageUrl="~/images/commands/uploadlotto.png" OnClick="ibtnUploadLotti_Click" />
                </td>
                <td>
                    Carica i lotti
                </td>
            </tr>
        </table>
        <asp:Label runat="server" ID="esitoUpload" CssClass="messaggi"></asp:Label></p>
    </fieldset>
</asp:Content>
