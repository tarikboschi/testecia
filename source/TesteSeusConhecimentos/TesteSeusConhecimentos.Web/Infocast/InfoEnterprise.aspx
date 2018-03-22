<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEnterprise.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEnterprise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Nova Empresa</h2>
         <div class="form-group">
            <asp:Label ID="lbName" runat="server" Text="Label">Nome:</asp:Label>
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" required ToolTip="Informe um nome"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbEndereco" runat="server" Text="Label">Endereço:</asp:Label>
            <asp:TextBox ID="txtEndereco" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="tbCidade" runat="server" Text="Label">Cidade:</asp:Label>
            <asp:TextBox ID="txtCidade" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="row form-group">
            <div class="col-md-2">
                <asp:Label ID="lbEstado" runat="server" Text="Label">Estado:</asp:Label>
                <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" MaxLength="2" ></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbCep" runat="server" Text="Label">CEP:</asp:Label>
                <asp:TextBox ID="txtCep" CssClass="form-control col-md-2" runat="server" MaxLength="8" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lbAtividade" runat="server" Text="Label">Atividade Corporativa:</asp:Label>
            <asp:TextBox ID="txtAtividade" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div> 
    </div>
</asp:Content>
