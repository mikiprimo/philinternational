<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LottoDetailEditingMask.ascx.cs"
    Inherits="Philinternational.UserControls.LottoDetailEditingMask" %>
<div id="divRegPanel" runat="server">
    <fieldset class="register"><legend>Modifica lotto</legend><br />
    <asp:HiddenField ID="hiddenIdLotto" runat="server" />
        <p>
            <asp:Label ID="lblConferente" runat="server" AssociatedControlID="txtConferente">Conferente: </asp:Label>
            <asp:TextBox ID="txtConferente" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ConferenteRequired" runat="server" ControlToValidate="txtConferente"
                CssClass="failureNotification" ErrorMessage="Il conferente é obbligatorio" ToolTip="Il conferente é obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblAnno" runat="server" AssociatedControlID="txtAnno">Anno: </asp:Label>
            <asp:TextBox ID="txtAnno" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="AnnoRequired" runat="server" ControlToValidate="txtAnno"
                CssClass="failureNotification" ErrorMessage="L'anno é obbligatorio" ToolTip="L'anno é obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblTipoLotto" runat="server" AssociatedControlID="txtTipoLotto">Tipo lotto: </asp:Label>
            <asp:TextBox ID="txtTipoLotto" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TipoLottoRequired" runat="server" ControlToValidate="txtTipoLotto"
                CssClass="failureNotification" ErrorMessage="Il tipo lotto é obbligatorio" ToolTip="Il tipo lotto é obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblNumeroPezzi" runat="server" AssociatedControlID="txtNumeroPezzi">Numero pezzi: </asp:Label>
            <asp:TextBox ID="txtNumeroPezzi" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NumeroPezziRequired" runat="server" ControlToValidate="txtNumeroPezzi"
                CssClass="failureNotification" ErrorMessage="Il numero di pezzi é obbligatorio"
                ToolTip="Il numero di pezzi é obbligatorio" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblDescrizione" runat="server" AssociatedControlID="txtDescrizione">Descrizione: </asp:Label>
            <asp:TextBox ID="txtDescrizione" runat="server" CssClass="textEntry"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblPrezzoBase" runat="server" AssociatedControlID="txtPrezzoBase">Prezzo base: </asp:Label>
            <asp:TextBox ID="txtPrezzoBase" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PrezzoBaseRequired" runat="server" ControlToValidate="txtPrezzoBase"
                CssClass="failureNotification" ErrorMessage="Il prezzo é obbligatorio" ToolTip="Il prezzo é obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblEuro" runat="server" AssociatedControlID="txtEuro">Euro: </asp:Label>
            <asp:TextBox ID="txtEuro" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EuroRequired" runat="server" ControlToValidate="txtPrezzoBase"
                CssClass="failureNotification" ErrorMessage="Campo obbligatorio" ToolTip="Campo obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblRiferimentoSassone" runat="server" AssociatedControlID="txtRiferimentoSassone">Riferimento Sassone: </asp:Label>
            <asp:TextBox ID="txtRiferimentoSassone" runat="server" CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RiferimentoSassoneRequired" runat="server" ControlToValidate="txtPrezzoBase"
                CssClass="failureNotification" ErrorMessage="Campo obbligatorio" ToolTip="Campo obbligatorio"
                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <br />
        <asp:ImageButton ID="ibtnUpdateLotto" runat="server" AlternateText="Aggiorna" 
            onclick="ibtnUpdateLotto_Click" />
    </fieldset>
</div>
