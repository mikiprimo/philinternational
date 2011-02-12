<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registrazione.aspx.cs" Inherits="Philinternational.Account.Registrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="divTitolo" runat="server">
        <h2>Registrati per poter fare le tue offerte. </h2>
        <hr />
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
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">E-mail:</asp:Label>
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
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification" ErrorMessage="La password é richiesta" ToolTip="La password é obbligatoria"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblConfermaPassword" runat="server" AssociatedControlID="txtConfermaPassword">Confirm Password:</asp:Label>
                <asp:TextBox ID="txtConfermaPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtConfermaPassword" CssClass="failureNotification"
                    Display="Dynamic" ErrorMessage="La conferma password é richiesta" ID="ConfirmPasswordRequired"
                    runat="server" ToolTip="La conferma password é obbligatoria" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                    CssClass="failureNotification" ControlToValidate="txtConfermaPassword" Display="Dynamic"
                    ErrorMessage="La password e la conferma password non corrispondono" ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
            </p>
            <p>
                <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome">Nome:</asp:Label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NomeRequired" runat="server" ControlToValidate="txtNome"
                    CssClass="failureNotification" ErrorMessage="Il nome é richiesto" ToolTip="Il nome é obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCognome" runat="server" AssociatedControlID="txtCognome">Cognome:</asp:Label>
                <asp:TextBox ID="txtCognome" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CognomeRequired" runat="server" ControlToValidate="txtCognome"
                    CssClass="failureNotification" ErrorMessage="Il cognome è richiesto." ToolTip="Il cognome è obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCodiceFiscale" runat="server" AssociatedControlID="txtCodiceFiscale">Codice fiscale:</asp:Label>
                <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="textEntry" MaxLength="18"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodiceFiscaleRequired" runat="server" ControlToValidate="txtCodiceFiscale"
                    CssClass="failureNotification" ErrorMessage="Il codice fiscale richiesto." ToolTip="Il codice fiscale é obbligatorio"
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="CodiceFiscaleRegEx" runat="server" ControlToValidate="txtCodiceFiscale"
                    ValidationExpression="^[A-Z,a-z]{6}[\d]{2}[A-Z,a-z][\d]{2}[A-Z,a-z][\d]{3}[A-Z,a-z]$"
                    ValidationGroup="RegisterUserValidationGroup" ErrorMessage="Codice fiscale formalmente errato">*</asp:RegularExpressionValidator>
            </p>
            <!--DATI FACOLTATIVI-->
            <legend>Indirizzo di Residenzand><p>
                <asp:Label ID="lblVia" runat="server" AssociatedControlID="txtVia">Via:</asp:Label>
                <asp:TextBox ID="txtVia" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
            </p>
                <p>
                    <asp:Label ID="lblIndirizzo" runat="server" AssociatedControlID="txtIndirizzo">Indirizzo:</asp:Label>
                    <asp:TextBox ID="txtIndirizzo" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblNumCivico" runat="server" AssociatedControlID="txtNumCivico">Numero civico:</asp:Label>
                    <asp:TextBox ID="txtNumCivico" runat="server" MaxLength="6" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblCap" runat="server" AssociatedControlID="txtCap">Cap:</asp:Label>
                    <asp:TextBox ID="txtCap" runat="server" MaxLength="5" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblProvincia" runat="server" AssociatedControlID="txtProvincia">Provincia:</asp:Label>
                    <asp:TextBox ID="txtProvincia" runat="server" MaxLength="2" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblCitta" runat="server" AssociatedControlID="txtCitta">Citta:</asp:Label>
                    <asp:TextBox ID="txtCitta" runat="server" MaxLength="20" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblNazione" runat="server" AssociatedControlID="txtNazione">Nazione:</asp:Label>
                    <asp:TextBox ID="txtNazione" runat="server" MaxLength="50" CssClass="textEntry"></asp:TextBox>
                </p>
                <asp:UpdatePanel ID="updPanel" runat="server">
                    <ContentTemplate>Residenza diversa da domicilio? <br />
                        <asp:RadioButton ID="rbSi" runat="server" Text="Si" Checked="false" GroupName="DomicilioGroup"
                            OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                        <br />
                        <asp:RadioButton ID="rbNo" runat="server" Text="No" Checked="true" GroupName="DomicilioGroup"
                            OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                        <br />
                        <div id="divDomicilio" runat="server">
                            <legend>Indirizzo di domicilio</legend><p>
                                <asp:Label ID="lblViaDom" runat="server" AssociatedControlID="txtViaDom">Via:</asp:Label>
                                <asp:TextBox ID="txtViaDom" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblIndirizzoDom" runat="server" AssociatedControlID="txtIndirizzoDom">Indirizzo:</asp:Label>
                                <asp:TextBox ID="txtIndirizzoDom" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblNumCivicoDom" runat="server" AssociatedControlID="txtNumCivicoDom">Numero civico:</asp:Label>
                                <asp:TextBox ID="txtNumCivicoDom" runat="server" MaxLength="6" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblCapDom" runat="server" AssociatedControlID="txtCapDom">Cap:</asp:Label>
                                <asp:TextBox ID="txtCapDom" runat="server" MaxLength="5" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblProvinciaDom" runat="server" AssociatedControlID="txtProvinciaDom">Provincia:</asp:Label>
                                <asp:TextBox ID="txtProvinciaDom" runat="server" MaxLength="2" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblCittaDom" runat="server" AssociatedControlID="txtCittaDom">Citta:</asp:Label>
                                <asp:TextBox ID="txtCittaDom" runat="server" MaxLength="20" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="lblNazioneDom" runat="server" AssociatedControlID="txtNazioneDom">Nazione:</asp:Label>
                                <asp:TextBox ID="txtNazioneDom" runat="server" MaxLength="50" CssClass="textEntry"></asp:TextBox>
                            </p>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <p class="submitButton">
                    <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Registrati"
                        ValidationGroup="RegisterUserValidationGroup" OnClick="CreateUserButton_Click" />
                </p></fieldset>
    </div>
    <div id="divSuccess" runat="server">
        <h1>REGISTRAZIONE EFFETTUATA CON SUCCESSO!</h1>
        <hr />
        <br />
        <p>Nelle prossime ore la tua posizione verrà verificata e attivata.</p>
        <br />
    </div>
    <br />
</asp:Content>
