<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Anagrafica.aspx.cs" Inherits="Philinternational.Styles.Anagrafica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Gestione Anagrafica </h1>
    <hr />
    <br />
    <asp:TextBox ID="txtStringaRicercaCognome" runat="server" />
    <asp:TextBox ID="txtStringaRicercaMail" runat="server" />
    <asp:ImageButton ID="ibtnCercaAnagrafica" runat="server" AlternateText="Cerca" OnClick="ibtnCercaAnagrafica_Click" />
    <asp:ImageButton ID="ibtnCancellaAnagraficheSelezionate" runat="server" AlternateText="Cancella lotti selezionati"
        OnClick="ibtnCancellaAnagraficheSelezionate_Click" />
    <br />
    <br />
    <asp:GridView ID="gvAnagrafica" runat="server" AllowPaging="True" EnableTheming="True"
        OnPageIndexChanged="gvAnagrafica_PageIndexChanged" OnPageIndexChanging="gvAnagrafica_PageIndexChanging"
        AutoGenerateColumns="False" ShowHeader="False" DataKeyNames="email" OnRowDataBound="gvAnagrafica_RowDataBound"
        GridLines="None" EmptyDataText="Non é presente alcuna anagrafica." PageSize="15">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox ID="chkUserSelection" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenIdAnagrafica" runat="server" Value='<%# Eval("idanagrafica") %>' />
                    <asp:Image ID="imgNewsletterStatus" runat="server" ImageUrl="~/images/newsletters/email_delete.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="hlEditAnagrafica" runat="server" NavigateUrl='<%# "~/Management/AnagraficaDetail.aspx?email=" + DataBinder.Eval (Container.DataItem,"email")%>'><%# DataBinder.Eval(Container.DataItem, "cognome") + " " + DataBinder.Eval(Container.DataItem, "nome")%></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblCognome" runat="server" Text='<%# Bind("cognome") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblData" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}",Eval("data_inserimento")) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:UpdatePanel ID="updPanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:HiddenField ID="hiddenIdStato" runat="server" Value='<%# Eval("stato") %>' />
                            <asp:HiddenField ID="HiddenEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:DropDownList ID="ddlStati" runat="server" OnSelectedIndexChanged="ddlStati_SelectedIndexChanged"
                                AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
