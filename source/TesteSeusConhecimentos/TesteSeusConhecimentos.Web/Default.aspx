<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteSeusConhecimentos.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1> O Desafio está lançado! </h1> <br /> <br />
                <h2> Antes de iniciar o teste, leia atentamente as instruções descritas abaixo! </h2>
            </hgroup>           
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">   
    <ol class="round">

        <li class="one">            
           Este projeto deverá conter operações CRUD (CREATE, READ, UPDATE e DELETE) de <b> Usuários </b> e
           <b> Empresas </b>. Todas as operações referentes aos <b> Usuários </b> já foram implemetadas. Para conferir, acesse o menu <b> Usuários</b>.
        </li>

        <li class="two">
            Você deverá implementar, assim como foi feito para <b> Usuários</b>, as operações CRUD para as <b> Empresas </b>. As informações de cada empresa deverá ser persistida em banco de dados
            e deverá conter os campos listados na <b>Figura 1</b>. <br />
            <font color="red"> <b> DICA: </b> Observe atentamente a maneira em que as funcionalidades dos usuários foram implementadas. </font>
        </li>

        <li class="three">
           Além disso, você deverá implementar uma funcionalidade que possibilita o relacionamento entre <b>Empresas</b> e <b>Funcionários</b> conforme ilustrado na <b>Figura 1</b>. O protótipo da tela responsável
           pelo relacionamento é ilustrado na <b> Figura 2 </b>;
        </li>
        
         <li class="four">
            Basicamente, tanto o fluxo para as operações com <b>Empresas</b> quanto as de <b>Relacionamentos</b>, seguem a mesma idéia do fluxo de <b>Usuários</b>, ou seja, 
            é apresentada uma tabela com todas as Empresas ou Relacionamentos cadastrados onde será possível efetuar todas as operações CRUD. <br />
            <b>OBS:</b> Para <b>Relacionamentos</b> a operação Cadastrar é substituída por Relacionar (Figura 2).
        </li> 
        
        <li class="five">
            <b>Importante:</b> O banco de dados está em SQLExpress e o arquivo do database está na pasta App_Data, não é necessário nenhuma instalação. Apenas confirme a connection string contida na classe TesteSeusConhecimentos.Infra caso tenha algum problema. 
        </li>     

    </ol>

    <div class="figura1"> <div class="legenda1"> <b>Figura 1: Modelo de Classes </b> </div> </div>
    <div class="figura2"> <div class="legenda2"> <b>Figura 2: Protótipo da Tela de Relacionamento </b> </div> </div>


    <div class="final">
      <h1> Boa Avaliação! </h1>     
    </div>

     <div class="boasorte"></div>
  </asp:Content>
