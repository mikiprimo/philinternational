﻿<%@ Page Title="Registrazione al sito di oferta filateliaca philinternational.it" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registrazione.aspx.cs" Inherits="Philinternational.Account.Registrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="divTitolo" runat="server">
        <h2>Registrati per poter fare le tue offerte. </h2>
        <br />
        <p>Ti ricordiamo che la password deve avere almeno <%= Membership.MinRequiredPasswordLength %>caratteri.
        </p>
    </div>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span><asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />
    <div id="divRegPanel" runat="server">
        <fieldset class="register"><legend>Informazioni di registrazione </legend><!--DATI OBBLIGATORI-->
            <p>
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">E-mail:</asp:Label><br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="la posta elettronica é richiesta"
                    ToolTip="la posta elettronica é obbligatoria" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegEx" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ValidationExpression="\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b"
                    ValidationGroup="RegisterUserValidationGroup" ErrorMessage="Indirizzo di posta elettronica formalmente errato">*</asp:RegularExpressionValidator>
                <asp:Label ID="lblExistMail" runat="server" CssClass="failureNotification"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label><br />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification" ErrorMessage="La password é richiesta" ToolTip="La password é obbligatoria"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblConfermaPassword" runat="server" AssociatedControlID="txtConfermaPassword">Conferma Password:</asp:Label><br />
                <asp:TextBox ID="txtConfermaPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtConfermaPassword" CssClass="failureNotification"
                    Display="Dynamic" ErrorMessage="La conferma password é richiesta" ID="ConfirmPasswordRequired"
                    runat="server" ToolTip="La conferma password é obbligatoria" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                    CssClass="failureNotification" ControlToValidate="txtConfermaPassword" Display="Dynamic"
                    ErrorMessage="La password e la conferma password non corrispondono" ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
            </p>
            <p>
                <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome">Nome:</asp:Label><br />
                <asp:TextBox ID="txtNome" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NomeRequired" runat="server" ControlToValidate="txtNome"
                    CssClass="failureNotification" ErrorMessage="Il nome é richiesto" ToolTip="Il nome é obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCognome" runat="server" AssociatedControlID="txtCognome">Cognome:</asp:Label><br />
                <asp:TextBox ID="txtCognome" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CognomeRequired" runat="server" ControlToValidate="txtCognome"
                    CssClass="failureNotification" ErrorMessage="Il cognome è richiesto." ToolTip="Il cognome è obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCodiceFiscale" runat="server" AssociatedControlID="txtCodiceFiscale">Codice fiscale:</asp:Label><br />
                <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="textEntry" MaxLength="18"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodiceFiscaleRequired" runat="server" ControlToValidate="txtCodiceFiscale"
                    CssClass="failureNotification" ErrorMessage="Il codice fiscale richiesto." ToolTip="Il codice fiscale é obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="CodiceFiscaleRegEx" runat="server" ControlToValidate="txtCodiceFiscale"
                    CssClass="failureNotification" ValidationExpression="^[A-Z,a-z]{6}[\d]{2}[A-Z,a-z][\d]{2}[A-Z,a-z][\d]{3}[A-Z,a-z]$"
                    ValidationGroup="RegisterUserValidationGroup" ErrorMessage="Codice fiscale formalmente errato">*</asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="lblPiva" runat="server" AssociatedControlID="txtPiva">Partita iva:</asp:Label><br />
                <asp:TextBox ID="txtPiva" runat="server" CssClass="textEntry" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="PivaRegEx" runat="server" ControlToValidate="txtPiva"
                    CssClass="failureNotification" ValidationExpression="^\\d{11}$" ValidationGroup="RegisterUserValidationGroup"
                    ErrorMessage="Partita Iva formalmente errata">*</asp:RegularExpressionValidator>
            </p>
            <!--DATI FACOLTATIVI-->
            <legend>Indirizzo di Residenza</legend><p>
                <asp:Label ID="lblVia" runat="server" AssociatedControlID="txtVia">Via:</asp:Label><br />
                <asp:TextBox ID="txtVia" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblIndirizzo" runat="server" AssociatedControlID="txtIndirizzo">Indirizzo:</asp:Label><br />
                <asp:TextBox ID="txtIndirizzo" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="IndirizzoRequiredFieldValidator" runat="server" ControlToValidate="txtIndirizzo"
                    CssClass="failureNotification" ErrorMessage="L'indirizzo di residenza é richiesto"
                    ToolTip="L'indirizzo di residenza é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblNumCivico" runat="server" AssociatedControlID="txtNumCivico">Numero civico:</asp:Label><br />
                <asp:TextBox ID="txtNumCivico" runat="server" MaxLength="6" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NumCivicoRequiredFieldValidator" runat="server" ControlToValidate="txtNumCivico"
                    CssClass="failureNotification" ErrorMessage="Numero civico di residenza é richiesto"
                    ToolTip="Numero civico di residenza é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCap" runat="server" AssociatedControlID="txtCap">Cap:</asp:Label><br />
                <asp:TextBox ID="txtCap" runat="server" MaxLength="5" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CapRequiredFieldValidator" runat="server" ControlToValidate="txtCap"
                    CssClass="failureNotification" ErrorMessage="Cap di residenza é richiesto" ToolTip="Cap di residenza é obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblProvincia" runat="server" AssociatedControlID="txtProvincia">Provincia:</asp:Label><br />
                <asp:TextBox ID="txtProvincia" runat="server" MaxLength="2" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ProvinciaRequiredFieldValidator" runat="server" ControlToValidate="txtProvincia"
                    CssClass="failureNotification" ErrorMessage="Provincia di residenza é richiesto"
                    ToolTip="Provincia di residenza é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCitta" runat="server" AssociatedControlID="txtCitta">Citta:</asp:Label><br />
                <asp:TextBox ID="txtCitta" runat="server" MaxLength="20" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CittaRequiredFieldValidator" runat="server" ControlToValidate="txtCitta"
                    CssClass="failureNotification" ErrorMessage="Citta di residenza é richiesto"
                    ToolTip="Citta di residenza é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblNazione" runat="server" AssociatedControlID="txtNazione">Nazione:</asp:Label><br />
                <asp:TextBox ID="txtNazione" runat="server" MaxLength="50" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NazioneRequiredFieldValidator" runat="server" ControlToValidate="txtNazione"
                    CssClass="failureNotification" ErrorMessage="Nazione di residenza é richiesto"
                    ToolTip="Nazione di residenza é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <asp:UpdatePanel ID="updPanel" runat="server">
                <ContentTemplate>Residenza diversa da domicilio? 
                    <asp:RadioButton ID="rbSi" runat="server" Text="Si" Checked="false" GroupName="DomicilioGroup"
                        OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" Width="49px" st
                        TextAlign="Right" />
                    <asp:RadioButton ID="rbNo" runat="server" Text="No" Checked="true" GroupName="DomicilioGroup"
                        OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" width="100px" />
                    <br />
                    <div id="divDomicilio" runat="server">
                        <legend>Indirizzo di domicilio</legend><p>
                            <asp:Label ID="lblViaDom" runat="server" AssociatedControlID="txtViaDom">Via:</asp:Label><br />
                            <asp:TextBox ID="txtViaDom" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ViaDomRequiredFieldValidator" runat="server" ControlToValidate="txtViaDom"
                                CssClass="failureNotification" ErrorMessage="Via di domicilio é richiesto" ToolTip="Via di domicilio é obbligatorio"
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblIndirizzoDom" runat="server" AssociatedControlID="txtIndirizzoDom">Indirizzo:</asp:Label><br />
                            <asp:TextBox ID="txtIndirizzoDom" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="IndirizzoDomRequiredFieldValidator" runat="server"
                                ControlToValidate="txtIndirizzoDom" CssClass="failureNotification" ErrorMessage="Indirizzo di domicilio é richiesto"
                                ToolTip="Indirizzo di domicilio é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblNumCivicoDom" runat="server" AssociatedControlID="txtNumCivicoDom">Numero civico:</asp:Label><br />
                            <asp:TextBox ID="txtNumCivicoDom" runat="server" MaxLength="6" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NumCivicoDomRequiredFieldValidator" runat="server"
                                ControlToValidate="txtNumCivicoDom" CssClass="failureNotification" ErrorMessage="Numero civico di domicilio é richiesto"
                                ToolTip="Numero civico di domicilio é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblCapDom" runat="server" AssociatedControlID="txtCapDom">Cap:</asp:Label><br />
                            <asp:TextBox ID="txtCapDom" runat="server" MaxLength="5" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CapDomRequiredFieldValidator" runat="server" ControlToValidate="txtCapDom"
                                CssClass="failureNotification" ErrorMessage="Cap di domicilio é richiesto" ToolTip="Cap di domicilio é obbligatorio"
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblProvinciaDom" runat="server" AssociatedControlID="txtProvinciaDom">Provincia:</asp:Label><br />
                            <asp:TextBox ID="txtProvinciaDom" runat="server" MaxLength="2" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ProvinciaDomRequiredFieldValidator" runat="server"
                                ControlToValidate="txtProvinciaDom" CssClass="failureNotification" ErrorMessage="Provincia di domicilio é richiesto"
                                ToolTip="Provincia di domicilio é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblCittaDom" runat="server" AssociatedControlID="txtCittaDom">Citta:</asp:Label><br />
                            <asp:TextBox ID="txtCittaDom" runat="server" MaxLength="20" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CittaDomRequiredFieldValidator" runat="server" ControlToValidate="txtCittaDom"
                                CssClass="failureNotification" ErrorMessage="Citta di domicilio é richiesto"
                                ToolTip="Citta di domicilio é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="lblNazioneDom" runat="server" AssociatedControlID="txtNazioneDom">Nazione:</asp:Label><br />
                            <asp:TextBox ID="txtNazioneDom" runat="server" MaxLength="50" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NazioneDomRequiredFieldValidator" runat="server"
                                ControlToValidate="txtNazioneDom" CssClass="failureNotification" ErrorMessage="Nazione di domicilio é richiesto"
                                ToolTip="Nazione di domicilio é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate><p>
                    <table>
                        <tr>
                            <td class="style1">
                                <asp:CheckBox ID="chkAccettaCondizioni" runat="server" AutoPostBack="True" OnCheckedChanged="chkAccettaCondizioni_CheckedChanged" />
                                Accetto le <a href="#" onclick="javascript:window.open('CondizioniDiUtilizzo.htm');"> condizioni di utilizzo</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:CheckBox ID="chkNewsLetters" runat="server" Text="Iscriviti alle Newsletters" Checked="true" />
                            </td>
                        </tr>
                    </table>
                </p>
                    <p class="submitButton">
                        <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Registrati"
                            ValidationGroup="RegisterUserValidationGroup" OnClick="CreateUserButton_Click"
                            Visible="False" />
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>
    </div>
    <div id="divSuccess" runat="server">
        <h1>REGISTRAZIONE EFFETTUATA CON SUCCESSO</h1>
        <br />
        <br />
        <p>
        <h1>Nelle prossime ore la tua posizione verrà verificata e attivata.</h1></p>
        <br />
        <p style="text-align:center"><asp:HyperLink ID="hlHomePage" runat="server" NavigateUrl="~/Default.aspx">VAI ALL'HOME PAGE</asp:HyperLink></p>
        <br />
        
    </div>
    <br />
</asp:Content>
