<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="CadSite.aspx.cs" Inherits="Adm_CadSite" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register src="WUC_AcessoRapido.ascx" tagname="WUC_AcessoRapido" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <h1 class="heading">Cadastro do Site</h1>
        <div class="entry">
            <p>
                Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
            <p>
                Título do site:<br />
                <asp:TextBox ID="TextBoxNome" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
            <p>
                Endereço:<br />
                <asp:TextBox ID="TextBox1" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
            <p>
                CEP:<br />
                <asp:TextBox ID="TextBox2" runat="server" Width="100px" MaxLength="10"></asp:TextBox></p>
            <p>
                Cidade:<br />
                <asp:TextBox ID="TextBoxCidade" runat="server" Width="300px" MaxLength="20"></asp:TextBox></p>
            <p>
                Estado:<br />
                <asp:TextBox ID="TextBoxEstado" runat="server" Width="300px" MaxLength="20"></asp:TextBox></p>
            <p>
                Telefone:<br />
                <asp:TextBox ID="TextBoxTel1" runat="server" Width="300px" MaxLength="14"></asp:TextBox></p>
            <p>
                E-mail:<br />
                <asp:TextBox ID="TextBoxEmail1" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
            <p>
                Banner imagem (página inicial): (Largura máxima permitida, 960 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorImg" runat="server" BasePath="~/fckeditor/"
                    Height="400px" Width="100%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p>
                Banner flash (página inicial): (Largura máxima permitida, 960 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorFlash" runat="server" BasePath="~/fckeditor/"
                    Height="400px" Width="100%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p>
                Publicidade&nbsp; (páginas): (Largura máxima permitida, 259 pixels)<br />
                <FCKeditorV2:FCKeditor ID="FCKeditorPub" runat="server" BasePath="~/fckeditor/"
                    Height="550px" Width="60%">
                </FCKeditorV2:FCKeditor>
            </p>
            <p> </p>
            <p>
                Logomarca:<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Image ID="Image1" runat="server" />
                &nbsp;
                <asp:Button ID="Button4" runat="server" Text="Remove" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                    UseSubmitBehavior="False" CausesValidation="False" Visible="False" OnClick="Button4_Click" />
            </p>
            <p>
                <asp:Label ID="LblMsg" runat="server"></asp:Label></p>
            <asp:Button ID="Button1" runat="server" Text="Salvar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" OnClick="Button1_Click" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="Voltar" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" OnClick="Button2_Click" CausesValidation="False" />
            &nbsp;
            <asp:Button ID="Button3" runat="server" Text="Excluir" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                UseSubmitBehavior="False" CausesValidation="False" Visible="False" OnClick="Button3_Click" />
        </div>
        <!-- entry -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_AcessoRapido ID="WUC_AcessoRapido1" runat="server" />
</asp:Content>

