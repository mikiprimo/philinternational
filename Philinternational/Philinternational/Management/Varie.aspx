<%@ Page Title="Funzionalità varie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Varie.aspx.cs" Inherits="Philinternational.Styles.Varie" %>
<asp:Content ID="VarieHead" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    #loadLotti { display:none; }
    ul.insidelista {padding:5px}
    ul.insidelista li{line-height:30px;border:1px dashed #ccc;margin:0px 0px 2px 0px;text-align:center;text-transform:uppercase}
    
</style>
</asp:Content>
<asp:Content ID="VarieMain" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="titlePanel">Varie</h3>
<fieldset>
    <legend>Lotti</legend>
    <ul class="insidelista">
        <li><a href="#" id="toggle1">Carica il file dei lotti</a></li>
        <li><asp:LinkButton runat="server" ID="allineaImmagine" OnClick="aggiornaDatabase" Text="Aggiorna DataBase Immagini"></asp:LinkButton></li>
        <li><asp:LinkButton runat="server" ID="creaAsta" OnClick="cleanAsta" Text="Pulisci sito per nuova Asta (Attenzione! Operazione irreversibile)"></asp:LinkButton></li>
    </ul>    
    <script type="text/javascript">
        $("#toggle1").click(function () { $("#loadLotti").slideToggle("slow", function () { $("#spoolTesto").html("");}); });
    </script>
</fieldset>
<div id="loadLotti">
    <fieldset>
        <legend>Seleziona il file in formato ".txt"</legend>
        <table>
            <tr class="commandPanel">
                <td><asp:FileUpload ID="FileLotto" runat="server"  />
                </td>
                <td><asp:ImageButton ID="ibtnFileLottoUpload" runat="server" ImageUrl="~/images/commands/uploadmarks.png" OnClick="loadLotti"/>
                </td>
            </tr>
        </table>

    </fieldset>
</div>
<p id="spoolTesto" runat="server" visible="false">
<h3 class="titlePanel">Esito elaborazione</h3>
<asp:Label runat="server" ID="esitoElaborazione" ></asp:Label></p>
</asp:Content>
