<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="InfoRelationship.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relationship.InfoRelationship" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <span class="border border-dark">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Novo Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lbEnterpriseInfo" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="ddlEnterprise" CssClass="form-control" DataTextField="CorporateActivity" DataValueField="IdEnterprise" runat="server" AppendDataBoundItems="True">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEnterprise" 
                            InitialValue="0" 
                            SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"          
                            ErrorMessage="Empresa obrigatória!"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbUserName" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUser" CssClass="form-control" DataTextField="Name"   DataValueField="IdUser" runat="server"  AppendDataBoundItems="True"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUser" 
                            InitialValue="0"
                            SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"          
                            ErrorMessage="Usuário obrigatório!"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
    </span>
</asp:Content>