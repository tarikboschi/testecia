<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relationchip.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relationchip" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Relacionar</h2>
         <div class="form-group">
            <asp:Label ID="lblEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
             <asp:DropDownList ID="ddlEmpresa" CssClass="form-control" runat="server" ></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUsuario" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
        <br />
        <br />
        <asp:GridView ID="grdRelationchip" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover" OnRowCommand="grdRelationchip_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Empresa">
                    <ItemTemplate>
                        <asp:Label ID="tbCodigo" Text='<%# Eval("[0]")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Usuário">
                    <ItemTemplate>
                        <asp:Label ID="lbName" Text='<%# Eval("[1]")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField  HeaderText="Opções">
                <ItemTemplate>                
                  <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("[2]")%>' />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
</asp:Content>