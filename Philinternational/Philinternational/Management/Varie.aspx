<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Varie.aspx.cs" Inherits="Philinternational.Styles.Varie" %>
<asp:Content ID="VarieHead" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    #loadLotti { display:none; }
    #loadImage { display:none; }
    ul.insidelista {padding:5px}
    ul.insidelista li{line-height:30px;border:1px dashed #ccc;margin:0px 0px 2px 0px;text-align:center;text-transform:uppercase}
    
</style>
</asp:Content>
<asp:Content ID="VarieMain" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="titlePanel">Varie</h3>
<fieldset>
    <legend>Lotti</legend>
    <ul class="insidelista">
        <li><asp:LinkButton runat="server" ID="allineaImmagine" OnClick="aggiornaDatabase" Text="Aggiorna DataBase Immagini"></asp:LinkButton></li>
        <li><a href="#" id="toggle1">Carica il file dei lotti</a></li>
        <li><a href="#" id="toggle2">Carica le immagini dei lotti</a></li>
    </ul>    
    <script type="text/javascript">
        $("#toggle1").click(function () { $("#loadLotti").slideToggle("slow", function () { $("#spoolTesto").html(""); $("#loadImage").css("display", "none"); }); });
        $("#toggle2").click(function () { $("#loadImage").slideToggle("slow", function () { $("#spoolTesto").html(""); $("#loadLotti").css("display", "none"); }); });
    </script>
</fieldset>

<div id="loadLotti">
    <fieldset>
        <legend>Seleziona il file in formato .txt</legend>
        <p><asp:FileUpload ID="FileLotto" runat="server"  />
        <asp:Button ID="btnFile" runat="server" Text="Carica" onclick="loadLotti" /><br /></p>
    </fieldset>
</div>
<div id="loadImage">
    <fieldset>
        <legend>Seleziona la cartella di riferimento</legend>
        <p><asp:FileUpload ID="FileUpload1" runat="server"  />
        <asp:Button ID="btnImage" Visible="false" runat="server" Text="Carica" onclick="loadImmagini" /><br /></p>
        <p>Work in progress</p>
    </fieldset>
</div>
<p id="spoolTesto"><asp:Label runat="server" ID="esitoElaborazione" ></asp:Label></p>
</asp:Content>
