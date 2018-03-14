<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoEnterprise.aspx.cs"  MasterPageFile="~/Site.Master"  Inherits="TesteSeusConhecimentos.Web.Infocast.Enterprise.InfoEnterprise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Nova Empresa</h2>
         <div class="form-group">
            <asp:Label ID="LbCorporateActivity" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:TextBox ID="TxtCorporateActivity" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Empresa obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="TxtCorporateActivity">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbStreetAdress" runat="server" Text="Label">Endereço:</asp:Label>
            <asp:TextBox ID="txtStreetAdress" CssClass="form-control" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Endereço obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtStreetAdress">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbCity" runat="server" Text="Label">Cidade:</asp:Label>
            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Cidade obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtCity">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbState" runat="server" Text="Label">Estado:</asp:Label>
            <asp:TextBox ID="txtState" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Estado obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="txtState">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbZipCode" runat="server" Text="Label">Cep:</asp:Label>
            <asp:TextBox ID="TxtZipCode" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Cep obrigatório!" 
                    SetFocusOnError="true" Display="Dynamic" ForeColor="#B50128" Font-Size="10"  Font-Bold="true"
                    ControlToValidate="TxtZipCode">
            </asp:RequiredFieldValidator>
        </div>
       
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>