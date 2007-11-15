<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contato.aspx.cs" Inherits="Contato" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="post">
        <h1 class="heading"></h1>
        <div class="entry">
<h2>
        Meios de contato</h2>
    <p>
        Endereço:
        <asp:Label ID="Label1" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>&nbsp;
        CEP:
        <asp:Label ID="Label2" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
        <br />
        Cidade:
        <asp:Label ID="LblCidade" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;Estado:
        <asp:Label ID="LblEstado" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
    </p>
    <p>
        Telefone:
        <asp:Label ID="LblTel1" runat="server" ForeColor="#333333" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;E-mail:
        <asp:Label ID="LblMail1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2>
                    Formulário de Contato</h2>
                <p>
                    Nome:
                    <br />
                    <asp:TextBox ID="TextBoxNome" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p>
                    E-mail:
                    <br />
                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p>
                    Telefone: (com DDD)
                    <br />
                    <asp:TextBox ID="TextBoxTelefone" runat="server"></asp:TextBox>
                </p>
                <p>
                    Assunto:
                    <br />
                    <asp:DropDownList ID="DropDownListAss" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Pedido</asp:ListItem>
                        <asp:ListItem Value="Informa&amp;ccedil;&amp;otilde;es">Informações</asp:ListItem>
                        <asp:ListItem>Elogio</asp:ListItem>
                        <asp:ListItem Value="Reclama&amp;ccedil;&amp;atilde;o">Reclamação</asp:ListItem>
                        <asp:ListItem>Sugestão</asp:ListItem>
                        <asp:ListItem>Outro</asp:ListItem>
                    </asp:DropDownList>
                </p>
                    Mensagem:
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" ToolbarStartExpanded="false" Height="125px" Width="319px">
                    </FCKeditorV2:FCKeditor>
                <p>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="this.disabled = true; this.value = 'Aguarde...';"
                        Text="Enviar" UseSubmitBehavior="False" />
                </p>
                    <p>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
        </div>
        <!-- entry -->
    </div>
    <!-- post -->
    <div id="sidebar">
    <div class="entry">
    <h2>Mapa de localização:</h2>
    <cc1:GMap ID="GMap1" runat="server" Height="350px" Key="ABQIAAAAtYIWZYuKGLZSXfbxtk_oxxSVZMAGqMc4COSYT8T6bBIEUQ7vlxTZAZQwWXUZRZ-HDEHNqjJvi9q71A" Width="100%" />
    </div>
        <!-- entry -->
    </div>
    <!-- sidebar -->
</asp:Content>

