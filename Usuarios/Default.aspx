<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Usuarios_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="heading">
        Gerenciamento de Usuários</h1>
    <div class="entry">
        <ul>
            <li><a href="Senhas.aspx">Alterar senha</a></li>
            <li><a href="CadUsuario.aspx">Cadastrar usuário</a></li>
            <li><a href="Gerenciamento.aspx">Administrar contas</a></li>
        </ul>
    </div>
    <!-- entry -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

