<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="CadSubpagina.aspx.cs" Inherits="Adm_CadSubpagina" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="heading">
        Cadastro de Subpágina</h1>
    <div class="entry">
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Página principal:<br />
        <asp:DropDownList ID="DropDownList" runat="server">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Título para o link da página:<br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>Descrição para o link da página:<br />
        <asp:TextBox ID="TextBoxDesc" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Conteúdo da página:<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorPag" runat="server" 
        BasePath="~/fckeditor/" Height="700px" 
                                Width="100%"></FCKeditorV2:FCKeditor>
    </p>
    <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
    
    <asp:Button ID="Button1" runat="server" Text="Inserir/Atualizar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" /> 
    &nbsp;           
    <asp:Button ID="Button2" runat="server" Text="Voltar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button2_Click" 
               CausesValidation="False"/>
    &nbsp;           
    <asp:Button ID="Button3" runat="server" Text="Excluir" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button3_Click" 
               CausesValidation="False" Visible="False"/>

    </div>
    <!-- entry -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>
