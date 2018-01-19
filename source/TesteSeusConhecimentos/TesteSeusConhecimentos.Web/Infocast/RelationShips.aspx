<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RelationShips.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.RelationShips" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdUsers" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdUsers_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbEmpresa" Text='<%# Eval("NameCompany")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbUsuario" Text='<%# Eval("NameUser")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField  HeaderText="Opções">
            <ItemTemplate>                
              <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdUser")+"|"+ Eval("IdCompany")%>' />
              <%--<asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdUser")+"|"+ Eval("IdCompany")%>' />--%>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>
