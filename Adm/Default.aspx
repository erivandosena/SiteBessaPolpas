<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Adm_Default" Title="Untitled Page" %>

<%@ Register Src="WUC_AcessoRapido.ascx" TagName="WUC_AcessoRapido" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h6 class="heading">
        Bem-vindo! 
        <asp:LoginName ID="LoginName1" runat="server" />
    </h6>
    <p>
    </p>
        <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="entry">
        <h5>
            Relatórios de acesso ao site</h5>
        <ul>
            <li><a href="http://stats.porta80.com.br" target="_blank">Estatísticas</a>
                <br />
                <i>Informações para acesso:</i><br />
                Site ID: <b>21652</b><br />
                Usuário: <b>bessapolpas</b><br />
                Senha: <span style="color: #CCCCCC">99754599</span></li>
        </ul>
        <p>
        </p>
        <h5>
            Contas de e-mail</h5>
        <ul>
            <li><a href="http://www.workspace.com.br/bessapolpas/" target="_blank">Meu Workspace</a>
                <br />
                <i>Informações para acesso:</i><br />
                Usuário: <b>bessapolpas</b><br />
                Senha: <span style="color: #CCCCCC">99754599</span></li>
        </ul>
    </div>
    <!-- entry -->
</asp:Content>

