<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEnterpriseUser.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEnterpriseUser" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Relacionamento</h2>

         <div class="form-group">
            <asp:Label ID="lbName" runat="server" Text="Label">Empresa:</asp:Label>
             <asp:DropDownList ID="dpdEnterprise" CssClass="form-control"  runat="server"   DataTextField="Name" DataValueField="IdEnterprise" ></asp:DropDownList>
              
        </div>
        <div class="form-group">
            <asp:Label ID="lbEndereco" runat="server" Text="Label">Usuário:</asp:Label> 
            <asp:DropDownList ID="dpdUser" CssClass="form-control"  runat="server" DataTextField="Name" DataValueField="Iduser" ></asp:DropDownList>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1"
            ControlToValidate="dpdUser"
            ErrorMessage="Required"
            runat="server"/>

        </div>


        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div> 
    </div>
</asp:Content>
