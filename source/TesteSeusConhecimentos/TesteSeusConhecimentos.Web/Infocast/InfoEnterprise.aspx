<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEnterprise.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEnterprise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Nova Empresa</h2>
        <div class="form-group">
            <asp:Label ID="lbCompany" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:TextBox ID="txtCompany" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
            <asp:Label ID="lbStreetAdress" runat="server" Text="Label">Endereço:</asp:Label>
            <asp:TextBox ID="txtStreetAdress" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbCity" runat="server" Text="Label">Cidade:</asp:Label>
            <asp:TextBox ID="txtCity" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbState" runat="server" Text="Label">Estado:</asp:Label>
            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                <asp:ListItem Value="">.:Selecione:.</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbZipCode" runat="server" Text="Label">ZipCode:</asp:Label>
            <asp:TextBox ID="txtZipCode" MaxLength="8" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbCorporateActivity" runat="server" Text="Label">Ramo de Atividade:</asp:Label>
            <asp:TextBox ID="txtCorporateActivity" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>
