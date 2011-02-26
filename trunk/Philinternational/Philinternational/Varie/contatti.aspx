<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contatti.aspx.cs" Inherits="Philinternational.conttti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    .spanMail {width:150px;background-color:Aqua;height:30px;display:block}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Contatti</h1>
<p><asp:Label CssClass="spanMail" runat="server" ID="lblnomeCognome">nome e cognome</asp:Label><asp:TextBox runat="server" ID="nomeCognome" MaxLength="60"></asp:TextBox></p>
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

<p><asp:Label CssClass="spanMail" runat="server">telefono</asp:Label><asp:TextBox runat="server" ID="telefono"></asp:TextBox></p>
<p><asp:Label CssClass="spanMail" runat="server">Tipologia</asp:Label>
    <select id="tipologia">
        <option>fff</option>
        <option>ffeef</option>
        <option>ff2f</option>
    </select>
</p>
<p><asp:Label CssClass="spanMail" runat="server">Note</asp:Label><asp:TextBox row="10" Columns="10" runat="server" TextMode="MultiLine"></asp:TextBox></p>
<p><asp:Button runat="server" ID="sendMail" Text="Invia" /></p>
</asp:Content> 
