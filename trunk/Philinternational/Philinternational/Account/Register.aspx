﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Philinternational.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Crea un nuovo account
    </h2>
    <p>
        Compila il modulo per la richiesta di un account personale.
    </p>
    <p>
        La Password deve avere almeno <%= Membership.MinRequiredPasswordLength %> caratteri.
        </p>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Informazioni richieste</legend>
            <p>
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                    CssClass="failureNotification" ErrorMessage="E-mail é obbligatoria." ToolTip="E-mail is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                    CssClass="failureNotification" ErrorMessage="La Password é obbligatoria." ToolTip="Password is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Conferma Password:</asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                    Display="Dynamic" ErrorMessage="La conferma della Password é obbligatoria." ID="ConfirmPasswordRequired"
                    runat="server" ToolTip="La conferma della Password é obbligatoria." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                    ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                    ErrorMessage="La Password e la Password di conferma devono coincidere." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="CreateUserButton" runat="server" Text="Richiedi registrazione."
                ValidationGroup="RegisterUserValidationGroup" 
                onclick="CreateUserButton_Click" />
        </p>
    </div>
</asp:Content>
