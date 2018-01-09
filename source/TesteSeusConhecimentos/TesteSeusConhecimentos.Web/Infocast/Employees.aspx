<%@ Page Title="Empregados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Employees" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEmployess" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdEmployees_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbCompany" Text='<%# Eval("Enterprise.Company")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label ID="lbName" Text='<%# Eval("User.Name") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="Sobrenome">
                <ItemTemplate>
                    <asp:Label ID="lbLastName" Text='<%# Eval("User.LastName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            
           <asp:TemplateField  HeaderText="Opções">
            
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>