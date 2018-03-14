<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoUser.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoUser" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Novo Usuário</h2>
         <div class="form-group">
            <asp:Label ID="lbName" runat="server" Text="Label">Nome:</asp:Label>
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Nome obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtName">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbLastName" runat="server" Text="Label">Sobrenome:</asp:Label>
            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Sobrenome obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtLastName">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="tbEmail" runat="server" Text="Label">Email:</asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                 ErrorMessage ="Email incorreto!" SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Email obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtEmail">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>