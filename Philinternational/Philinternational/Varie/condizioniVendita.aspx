<%@ Page Title="Condizioni di vendita per offerta filateliaca philinternational.it" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="condizioniVendita.aspx.cs" Inherits="Philinternational.condizioniVendita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    p,ul li,ol li{text-align:justify;padding:0px 5px; line-height:20px}
    p:hover,ul li:hover, ol li:hover{background-color:#eee}
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h1>CONDIZIONI DI VENDITA</h1>
<ol>
    <li>Tutto il materiale offerto è di proprietà di terzi che hanno dato regolare mandato di vendita alla PHIL INTERNATIONAL s.r.l. socio unico</li>
    <li>Ogni lotto ha un prezzo base (espresso in Euro), sotto al quale non si accettano offerte.  L’offerta effettuata tramite questo sito indicherà  la cifra massima (escluso 20%) che si garantisce pagare per ogni singolo lotto. Le offerte devono pervenire entro la data di scadenza indicata. Si accettano offerte telefoniche  o via mail (<asp:HyperLink runat="server" ID="sendMail" NavigateUrl="~/Varie/contatti.aspx">info@philinternational.it</asp:HyperLink> ), in particolare negli ultimi giorni precedenti la chiusura della vendita. Devono però essere al più presto convalidate con l’ordine d’acquisto firmato.</li>
    <li>L’assegnazione sarà fatta al maggior offerente, al prezzo dell’offerta subito precedente aumentata del 10%. (Esempio: se per un lotto le due offerte più alte sono € 50,00 e € 100,00, il lotto sarà assegnato a chi ha offerto € 100,00 al prezzo di € 55,00).</li>
    <li>AL PREZZO DI ASSEGNAZIONE SONO DA AGGIUNGERE SOLO:<br />
        <ul style="list-style-type:disc">
            <li>IL 20%</li>
            <li>LE SPESE POSTALI E DI IMBALLO (AL COSTO)</li>
            <li>LE SPESE PER L’ASSICURAZIONE COMPLEMENTARE SULLA SPEDIZIONE – FACOLTATIVA – VEDI PUNTO 10</li>
        </ul>
    </li>
    <li>
        <p>Il pagamento dei lotti assegnati dovrà avvenire <strong>entro 15 giorni dalla data di assegnazione</strong>. Trascorsi 30 giorni la PHIL INTERNATIONAL si riserva di rivalersi in qualsiasi modo ritenga opportuno nei confronti degli inadempienti.</p>
        <p>Il pagamento potrà essere effettuato a mezzo:<br /></p>
            <ul style="list-style-type:circle">
            <li>Assegno di conto corrente personale</li>
            <li>Assegno circolare</li>
            <li>Bonifico Bancario con accredito sul nostro conto corrente c/o Banca Intesa IBAN: IT 20 W030 6909 449615315689075</li>
            <li>Bonifico Bancario con accredito sul nostro conto corrente c/ o BNL IBAN: IT 06 A010 0501 6040 0000 0000 172</li>
            <li>Vaglia Postale – intestato a Phil International srl</li>
            <li>Carta di credito – compilando l’apposito modulo che verrà inviato a richiesta</li>
            <li>Contrassegno: dovrà essere specificato con l’ordine. Le spese postali saranno necessariamente più elevate</li>
            <li>E’ possibile concordare, di volta in volta, un pagamento rateizzato. Salvo accordi contrari i lotti verranno inviati dopo aver ricevuto l’ultima rata.</li>
            </ul>
        <p>SPEDIZIONE DEI LOTTI AVVERRA’ NON APPENA CI SARA’ PERVENUTO IL PAGAMENTO RELATIVO.<br /></p>
    </li>
    <li>E’ gradito l’invio di un acconto proporzionale all’entità delle prenotazioni fatte. Tale acconto dà diritto di priorità nell’assegnazione di quei lotti che abbiano avuto identiche offerte. In mancanza di acconto i lotti con identica offerta saranno assegnati alla prima prenotazione arrivata. Gli acconti saranno integralmente restituiti, in caso di mancata assegnazione, al momento della chiusura della vendita.</li>
    <li>Il materiale è descritto con la massima cura ed obiettività. E’ comunque possibile prendere visione dei lotti previo appuntamento telefonico.<br />
        Eventuali fotocopie o scansioni di lotti non fotografati (con l’esclusione delle collezioni e dei lotti voluminosi) possono essere richieste inviando € 2,50 per rimborso spese postali e segreteria. Il pagamento dovrà essere anticipato e potrà essere effettuato con francobolli italiano in euro.<br />
        In nessun caso si inviano lotti in visione.</li>
<li>Eventuali verifiche peritali aggiuntive potranno essere richieste dall’acquirente, a proprie spese, al momento dell’offerta. In tal caso dovrà essere anticipato un acconto pari a circa il 30% del prezzo base del lotto in oggetto. Qualora il lotto non venisse assegnato verrà restituito l’acconto. <br />
	E’ a discrezione della PHIL INTERNATIONAL s.r.l. accettare la suddetta estensione peritale.</li>
<li><b>RECLAMI</b><br />
<p>Non potremo in nessun caso accettare reclami, neppure per fondati motivi, trascorsi 60 giorni dalla data di chiusura della vendita. In tale momento vengono pagati ai conferenti i lotti venduti. E’ quindi importante provvedere per tempo al ritiro dei lotti assegnati.</p>

<p>Si accettano reclami – solo se motivati – all’atto della consegna dei lotti per chi ritira di persona, oppure entro e non oltre quindici giorni dalla spedizione postale.</p>
<p>Per contestazioni in merito all’originalità, nessun reclamo sarà preso in considerazione se privo del parere di un perito riconosciuto. E’ facoltà della PHIL INTERNATIONAL ricorrere ad un perito di sua fiducia prima di accettare il reclamo. </p>
<p>Qualora il reclamo, esposto nei termini sopra indicati, sia accolto, il cliente avrà diritto al rimborso integrale solo del prezzo pagato complessivamente per quel lotto. Non saranno riconosciuti rimborsi per eventuali danni o mancati guadagni o per eventuali spese, anche postali, sostenute, e non potrà essere pretesa la sostituzione, neanche parziale del lotto in oggetto.</p>
<p>Non si accettano reclami per i seguenti motivi:</p>
<ol style="list-style-type:lower-roman">
    <li>Riguardo a centratura, dentellatura, marginatura ed annulli, dei lotti fotografati, in quanto la foto è parte integrante della descrizione.</li>
    <li>Per i lotti descritti come seconda scelta, difettosi, di qualità mista, da esaminare.</li>
    <li>Per i lotti la cui base è inferiore al 20% del catalogo preso a riferimento. (esempio: catalogo € 50,00 prezzo base € 10,00 o meno).</li>
    <li>Per tutti quei lotti composti da collezioni o da più esemplari non appartenenti alla medesima serie.</li>
    <li>Per tutti quei lotti che risultassero, dopo la consegna, lavati o trattati chimicamente o manipolati in qualunque modo o deturpati da segni di qualunque tipo, anche segni di periti, qualora tale perizia non sia stata da noi preventivamente autorizzata.</li>
</ol>
</li>
<li>
    <p>merce viaggia a rischio e pericolo del committente, e comunque si intende consegnata al momento della presentazione all’ufficio postale.</p>
    <p>Allo scopo di superare i danni per eventuali furti o smarrimenti siamo riusciti ad attivare una apposita polizza presso la RAS che ci consente di assicurare ogni singola spedizione per l’intero valore. Restano a nostro carico l’importo della polizza ed i costi per l’attivazione della garanzia in occasione di ogni singola spedizione, a carico degli acquirenti l’importo (peraltro modesto) relativo ad ogni invio. La somma aggiuntiva da pagare sarà indicata sulla nota di aggiudicazione. Aderire a questa estensione assicurativa è  facoltativo  e comunque ogni invio è coperto fino ad € 50,00, spedendo noi esclusivamente tramite assicurata per quell’importo.</p></li>
</ol>
<br />
<p>PER OGNI CONTROVERSIA E’ COMPETENTE ESCLUSIVAMENTE IL FORO DI MILANO</p>
<p>IL PAGAMENTO DEI LOTTI ASSEGNATI DOVRA’ AVVENIRE ENTRO 15 GIORNI DALLA COMUNICAZIONE DELL’ASSEGNAZIONE. </p>
<p>LA SPEDIZIONE DEI LOTTI AVVERRA’ SUBITO DOPO</p>
<br />
</asp:Content>
