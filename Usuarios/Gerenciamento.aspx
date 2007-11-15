<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="Gerenciamento.aspx.cs" Inherits="Usuarios_Gerenciamento" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<h1 class="heading">
        Administração de contas</h1>
    <div class="entry">
        <ul>
            <li><a href="/Usuarios">Voltar</a></li></ul>

                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333"
                        GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
                        OnRowDeleting="GridView1_RowDeleting" PageSize="15" Width="100%">
                        <FooterStyle Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#E8EDDE" />
                        <Columns>
                            <asp:BoundField DataField="USERNAME" HeaderText="Nome de Usuário">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMAIL" HeaderText="E-mail">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" DeleteText="Excluir" HeaderText="Remover" ShowDeleteButton="true">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                        </Columns>
                        <PagerStyle BackColor="#595957" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#CFD9BB" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#595957" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#FF6600" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
   
                <p>
                    <asp:Label ID="LblMsg" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
                </p>
                        <h5>CONTROLE DE NÍVEL DE ACESSO DO USUÁRIO</h5>

                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <strong>Usuários(s):</strong>
                                </td>
                                <td>
                                    <strong>Regras:</strong>
                                </td>
                                <td align="center">
                                    <strong>Adicionar / Remover</strong>
                                </td>
                                <td>
                                    <strong>Regra(s) de
                                        <asp:Label ID="LabelUsuarioRegra" runat="server"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <strong>
                                        <asp:ListBox ID="ListBoxUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBoxUsuario_SelectedIndexChanged"
                                            Rows="8" />
                                    </strong>
                                </td>
                                <td valign="top">
                                    <asp:ListBox ID="ListBoxRegra" runat="server" Rows="8" SelectionMode="Multiple" 
                                        Width="170px">
                                    </asp:ListBox>
                                </td>
                                <td align="center">
                                    <asp:Button ID="BtnAdicionaRegra" runat="server" OnClick="BtnAdicionaRegra_Click"
                                        Text="&gt;&gt;" />
                                    <br />
                                    <br />
                                    <asp:Button ID="BtnRemoveRegra" runat="server" OnClick="BtnRemoveRegra_Click" 
                                        Text="&lt;&lt;" />
                                </td>
                                <td valign="top">
                                    <asp:ListBox ID="ListBoxUsuarioRegra" runat="server" Rows="8" 
                                        SelectionMode="Multiple"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="BtnExcluiRegra" runat="server" OnClick="BtnExcluiRegra_Click" 
                                        Text="-" Width="20px" />
                                    <asp:TextBox ID="TextBoxRegra" runat="server" MaxLength="20" Width="120px" />
                                    <asp:Button ID="BtnCriaRegra" runat="server" OnClick="BtnCriaRegra_Click" 
                                        Text="+" Width="20px" />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="Msg" runat="server" ForeColor="maroon" />
                                </td>
                            </tr>
                        </table>

    </div>
    <!-- entry -->     
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

