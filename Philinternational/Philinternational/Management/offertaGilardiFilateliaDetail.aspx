<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="offertaGilardiFilateliaDetail.aspx.cs" Inherits="Philinternational.Management.offertaGilardiFilateliaDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Dettaglio Lotto GilardiFilatelia <label runat="server" id="titoloDettaglio"></label></h1>
    <p>
        <span class="failureNotification"><asp:Literal ID="ErrorMessage" runat="server"></asp:Literal></span>
    </p>
    <p>        <span class="failureNotification" runat="server" id="ErrorUploadFile"></span></p>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"  ValidationGroup="RegisterUserValidationGroup" />
<p>
        <label>
            Data Pubblicazione:</label><label style="font-weight: bold" runat="server" id="labelDataPubblicazione"></label>
        <asp:Label ID="lblDataPubblicazione" runat="server"></asp:Label>
    </p>
    <p>
        <label id="labelLotto" runat="server">N&deg;Lotto</label>
<asp:RequiredFieldValidator ID="txtLottoRequired" runat="server" ControlToValidate="txtLotto"
                    CssClass="failureNotification" ErrorMessage="Inserire il numero di lotto"   ToolTip="Il numero di lotto è obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="txtLotto" MaxLength="5" ></asp:TextBox>
    </p>
    <p>
        <label id="labelAnno" runat="server">Anno</label>
<asp:RequiredFieldValidator ID="txtAnnoRequired" runat="server" ControlToValidate="txtAnno"
                    CssClass="failureNotification" ErrorMessage="Inserire l'anno"   ToolTip="L'anno è obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="txtAnno"></asp:TextBox>
    </p>
    <p>
        <label>Carimento File</label>
        <asp:FileUpload  runat="server" ID="uploadLotto" />
        <br /><br />
    </p>
    <p>
        <label>Descrizione</label>
        <asp:RequiredFieldValidator ID="txtTestoRequired" runat="server" ControlToValidate="txtTesto"
                    CssClass="failureNotification" ErrorMessage="Inserire una descrizione"   ToolTip="La descrizione del lotto è obbligatoria" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox runat="server" ID="txtTesto" Rows="5" Columns="50" TextMode="MultiLine"></asp:TextBox>
          
    </p>
<p>
        <label id="labelPrezzo" runat="server">Prezzo</label>
<asp:RequiredFieldValidator ID="txtPrezzoRequired" runat="server" ControlToValidate="txtPrezzo"
                    CssClass="failureNotification" ErrorMessage="Inserire il prezzo"   ToolTip="il prezzo è obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="txtPrezzo"></asp:TextBox>
    </p>
    <p>
        <label style="line-height:25px">Stato</label>
        <asp:CheckBox runat="server" ID="chkStato" /><label id="labelStato" runat="server"></label>
    </p>
    <p><br />
        <asp:Button runat="server" Text="Conferma" ID="btnConferma" OnClick="conferma"  CssClass="bottone"  ValidationGroup="RegisterUserValidationGroup"/>&nbsp;
        <asp:Button runat="server" Text="Reset" ID="buttonReset" OnClick="pulisci"  CssClass="bottone"/>&nbsp;
        <asp:Button runat="server" Text="Torna Indietro" ID="btnComeBack" OnClick="comeBack"  CssClass="bottone"/>
    </p>
</asp:Content>
