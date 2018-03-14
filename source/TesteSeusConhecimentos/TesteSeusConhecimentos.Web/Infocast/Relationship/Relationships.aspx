<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="Relationships.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relationship.Relationships" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdRelationships" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
                  OnRowCommand="grdRelationships_RowCommand" OnRowDataBound="grdRelationships_RowDataBound"
    >
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lbCodigo" Text='<%# Eval("IdRelationship")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                     <asp:Label ID="UserName" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="NomeEmpresa" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Endereço">
                <ItemTemplate>
                      <asp:Label ID="Logradouro" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Opções">
                <ItemTemplate>                
                    <asp:Button runat="server" ID="deleteButtom" Text="Excluir" OnClientClick="javascript:if (!confirm('Confirma a exclusão do registro?')) return false;"  CommandName="Remove" CommandArgument='<%#Eval("IdRelationShip")%>' />
                    <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdRelationShip")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>
