<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelationship.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoRelationship" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lbEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="ddlEnterprise" runat="Server" DataTextField="StreetAdress" DataValueField="IdEnterprise" />
        </div>
        <div class="form-group">
            <asp:Label ID="lbUsers" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUsers" runat="Server" DataTextField="Name" DataValueField="IdUser" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>
