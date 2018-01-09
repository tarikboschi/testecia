<%@ Page Title="Relacionamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEmployee.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEmployee" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lbEnterprise" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="ddlEnterprise" CssClass="form-control" runat="server">
                <asp:ListItem Value="">.:Selecione:.</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbUser" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server">
                <asp:ListItem Value="">.:Selecione:.</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnRelacionar" runat="server" Text="Relacionar" OnClick="btnRelacionar_Click" />
        </div>
    </div>
</asp:Content>