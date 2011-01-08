<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elencoLotto.aspx.cs" Inherits="Philinternational.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div title="Zoom Lotto" id="dialog"></div>

    <h1>NOME ARGOMENTO</h1>
    <h2>per chieregatti!!!! Bisogna fare la multipagina...12 per pagina credo che possa andare bene</h2>
    <div class="bloccoLotto">
    <h4>1</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..."  />
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>2</h4>
    <a href="#" onclick="zoom_immagine('2')" id="opener2"><img src="images/asta/2.jpg" width="100" height="100" alt="Lotto 1..."  /> </a>
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>3</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..."/>
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>4</h4>
    <img src="images/asta/4.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>

<div class="bloccoLotto">
    <h4>5</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta offerta_fatta">Offerta già effettuata</p>
</div>
<div class="bloccoLotto">
    <h4>6</h4>
    <img src="images/asta/6.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>7</h4>
    <img src="images/asta/7.jpg"" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>8</h4>
    <img src="images/asta/8.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div  class="bloccoLotto">
    <h4>9</h4>
    <img src="images/asta/9.jpg"" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>10</h4>
    <img src="images/immagine_non_disponibile.jpg" height="100" width="100" alt="Lotto 1..."/>
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div  class="bloccoLotto">
    <h4>11</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>12</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..."/> 
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>

</asp:Content>
