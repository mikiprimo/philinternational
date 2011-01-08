<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Offerta Filatelica per corrsipondenza</h1>
    <p>Asta numero 53</p>
    <p>Data di scadenza 01 gennaio 2011</p>
    <p>Prima di registrarsi, leggere attentamente le condizioni di vendita etc etc etc</p>
    <br />
    <hr style="background:#000;height:2px"/>
    <div style="width:100%;clear:both">
        <div style="float:left;width:32%; height:150px;text-align:center;font-size:2.5em;"><a href="#" style="display:block;padding:20px 0px">Login</a></div>
        <div style="float:left;width:32%;height:150px;" id="News">
            <ul>            
                <li style="background-color:Green;height:150px;z-index:1000;">
                    <h3>Titolo News</h3>
                    <p style="padding:5px;">testo news</p>
                </li>
            <li style="background-color:violet;height:150px;z-index:1001;">
                <h3>Titolo News</h3>
                <p style="padding:5px;">testo news</p>
            </li>
            <li style="background-color:yellow;height:150px;z-index:1002;">
                <h3>Titolo News</h3>
                <p style="padding:5px;">testo news</p>
            </li>

            </ul>

        </div>
        <div style="float:right;width:32%;height:150px;text-align:center;font-size:2.5em"><a href="#" style="display:block;padding:20px 0px">Registrati</a></div>
        
    </div>
    <h3>Alcuni lotto della nostra asta</h3>
<div class="bloccoLotto">
    <h4>1</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..." />
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>1</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..." />
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
<div class="bloccoLotto">
    <h4>1</h4>
    <img src="images/immagine_non_disponibile.jpg" width="100" height="100" alt="Lotto 1..." />
    <p>Anno:<span>1915/16</span></p>
    <p>Pro Croce Rossa (N. 102/ 05). Catal. € 200,00</p>
    <p>Condizione: <span>buono</span></p>
    <p>Prezzo: <span>40 soldini</span></p>
    <p class="lottoOfferta"><a href="#">Fai offerta!</a></p>
</div>
</asp:Content>
