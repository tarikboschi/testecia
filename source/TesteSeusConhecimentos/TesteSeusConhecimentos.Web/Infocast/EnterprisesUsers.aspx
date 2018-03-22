<%@ Page Title="Relacionamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterprisesUsers.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.EnterprisesUsers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEnterprisesUsers" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdEnterprisesUsers_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="tbCodigo" Text='<%# Eval("EnterpriseName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbName" Text='<%# Eval("UserName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>


           <asp:TemplateField  HeaderText="Opções">
            <ItemTemplate>                
              <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdEnterpriseUser")%>' />
              <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdEnterpriseUser")%>' />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionameno" OnClick="btnNovo_Click" />
</asp:Content>
