<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Relationships.aspx.cs"
    Inherits="TesteSeusConhecimentos.Web.Infocast.Relationships" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <fieldset class="fSet">
            <h2 id="formStatus" runat="server">Relacionamento</h2>
            <div class="form-group">
                <asp:Label ID="lbEnterprise" runat="server" Text="Label">Empresa:</asp:Label>
                <asp:DropDownList
                    ID="ddlEnterprise"
                    CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label ID="lbUser" runat="server" Text="Label">Usuário:</asp:Label>
                <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSalvar" runat="server" Text="Relacionar" OnClick="btnSalvar_Click" />
            </div>
        </fieldset>
    </div>
</asp:Content>
