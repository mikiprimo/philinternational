<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Philinternational._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-size:2em;text-align:center;padding:10px;letter-spacing:2px;line-height:30px">Phil International è un sito di offerta Filatelica per corrispondenza</div>
    <p style="padding:10px;font-size:20px">In questo momento è attiva l'asta numero <span style="color:red;font-weight:bold">53</span></p>
    <p style="padding:10px;font-size:20px">Data di scadenza <span style="color:red;font-weight:bold">01 gennaio 2011</span></p>
    <p style="padding:10px;font-size:20px">Prima di registrarsi, leggere attentamente le condizioni di vendita etc etc etc</p>
    <br />
    <hr style="background-color:#000;height:2px;border:1px dashed #eee"/>
    <div style="width:100%;clear:both">
        <div id="info" class="block">
				<ul id="ticker">
					<li>						
						<span >Titolo Lorem Ipsum 1</span>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec suscipit, ante id porttitor faucibus, odio 
							eros pellentesque sapien, at consectetur mi nibh at massa.
					</li>
					<li>
						<span>Titolo Lorem Ipsum 4</span>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec suscipit, ante id porttitor faucibus, odio 
							eros pellentesque sapien, at consectetur mi nibh at massa.
					</li>

					<li>
						<span>Titolo Lorem Ipsum 5</span>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec suscipit, ante id porttitor faucibus, odio 
							eros pellentesque sapien, at consectetur mi nibh at massa.
					</li>

				</ul>
			</div>
        <div style="float:right;width:35%;height:150px;text-align:center;font-size:2.5em">
            <asp:HyperLink runat="server" NavigateUrl="~/Account/Login.aspx" Text="Effettua il login" style="display:block;padding:20px 0px"></asp:HyperLink>
            <asp:HyperLink ID="registrati" runat="server" NavigateUrl="~/Account/Register.aspx" Text="Registrati" style="display:block;padding:20px 0px"></asp:HyperLink>
        </div>
    </div>
    <br />
    <h3 style="clear:both">Alcuni lotti della nostra asta</h3>
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
