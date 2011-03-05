<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordineGilardiFilatelia.aspx.cs" Inherits="Philinternational.ordinaToGilardiFilatelia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Modulo ordine del lotto presente su www.gilardifilatelia.it</title>
    <style type="text/css">
        .spanText{height:20px;width:250px;display:block;font-size:1.2em;font-style:italic}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Ordine Lotto presente sul sito www.gilardifilatelia.it</h1>
<fieldset runat="server" visible="false" id="fldMessaggio">
        <legend>Esito Messaggio</legend>
        <asp:Label runat="server" ID="esitoMessaggio"></asp:Label>
    </fieldset>
<fieldset>
    <legend>Ordine Lotto</legend>
    <asp:ValidationSummary ID="SendMailValidationSummary" runat="server" CssClass="failureNotification" ValidationGroup="SendMailValidationGroup"/>
    <p>
    <asp:Label ID="lblNomeCognome" runat="server" CssClass="spanText" AssociatedControlID="txtNomeCognome">Riferimento</asp:Label>
    <asp:TextBox ID="txtNomeCognome" runat="server" MaxLength="60" style="width:250px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="NomeCognomeRequired" runat="server" ControlToValidate="txtNomeCognome"
                    CssClass="failureNotification" ErrorMessage="Un nome di riferimento é richiesto" ToolTip="Un nome di riferimento é obbligatorio"
                    ValidationGroup="SendMailValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
    <asp:Label ID="LblMail" runat="server" CssClass="spanText" AssociatedControlID="txtEMail">e-mail</asp:Label>
    <asp:TextBox ID="txtEMail" runat="server" MaxLength="60" style="width:250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="la posta elettronica é richiesta"
                    ToolTip="la posta elettronica é obbligatoria" ValidationGroup="SendMailValidationGroup">*</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="EmailRegEx" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ValidationExpression="\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b"
                    ValidationGroup="SendMailValidationGroup" ErrorMessage="Indirizzo di posta elettronica formalmente errato">*</asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Label ID="lblSubject" runat="server" CssClass="spanText" AssociatedControlID="ListaOggetto">Oggetto</asp:Label>
        <asp:DropDownList runat="server" ID="ListaOggetto">
            <asp:ListItem Value="" Text="<Selezionare una voce>"></asp:ListItem>
            <asp:ListItem Value="0" Text="Ordine Lotto"></asp:ListItem>
            <asp:ListItem Value="1" Text="Richiesta informazioni"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="SubjectRequired" runat="server" ControlToValidate="ListaOggetto" 
                    CssClass="failureNotification" ErrorMessage="Selezionare una voce" ToolTip="Selezionare una voce"
                    ValidationGroup="SendMailValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
    <asp:Label ID="lblTesto" runat="server" CssClass="spanText" AssociatedControlID="txtTesto">Testo</asp:Label>
        <asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="8" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="TestoRequired" runat="server" ControlToValidate="txtTesto"
                    CssClass="failureNotification" ErrorMessage="il testo della mail é richiesto" ToolTip="Il testo della mail é richiesto"
                    ValidationGroup="SendMailValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p><label style="font-style:italic">Inviami una copia della mail: </label><asp:CheckBox  runat="server" ID="chksendCopia"/></p>
    <p><asp:Button runat="server" ID="sendMail" Text="Invia" ValidationGroup="SendMailValidationGroup" /></p>    
</fieldset>
</asp:Content>
