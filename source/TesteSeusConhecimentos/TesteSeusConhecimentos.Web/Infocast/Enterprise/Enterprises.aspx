<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enterprises.aspx.cs"  MasterPageFile="~/Site.Master"  Inherits="TesteSeusConhecimentos.Web.Infocast.Enterprise.Enterprise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEnterprises" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
                  OnRowCommand="grdUsers_RowCommand"
    >
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lbCodigo" Text='<%# Eval("IdEnterprise")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Endereço">
                <ItemTemplate>
                    <asp:Label ID="lbStreetAdress" Text='<%# Eval("StreetAdress")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cidade">
                <ItemTemplate>
                    <asp:Label ID="lbCity" Text='<%# Eval("City")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lbState" Text='<%#Eval("State") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cep">
                <ItemTemplate>
                    <asp:Label ID="lbZipCode" Text='<%#Eval("ZipCode") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbCorporateActivity" Text='<%#Eval("CorporateActivity") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Opções">
                <ItemTemplate>                
                    <asp:Button runat="server" ID="deleteButtom" Text="Excluir" OnClientClick="javascript:if (!confirm('Confirma a exclusão do registro?')) return false;" CommandName="Remove" CommandArgument='<%#Eval("IdEnterprise")%>' />
                    <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdEnterprise")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Nova Empresa" OnClick="btnNovo_Click" />
</asp:Content>
