<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="Senhas.aspx.cs" Inherits="Usuarios_Senhas" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="heading">
        Senha</h1>
    <div class="entry">
        <ul>
            <li><a href="/Usuarios">Voltar</a></li></ul>
    </div>
    <!-- entry -->
    <p>
        <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="/Usuarios/Default.aspx"
            ContinueDestinationPageUrl="/Usuarios/Default.aspx" CreateUserUrl="/Usuarios/Default.aspx"
            DisplayUserName="True" SuccessPageUrl="/Usuarios/Default.aspx" CancelButtonText="Cancelar"
            ChangePasswordButtonText="Alterar Senha" ChangePasswordFailureText="Senha incorreta ou Nova Senha inválida. Novo comprimento mínimo de senha: {0}. Caracteres não-alfanuméricos requerido: {1}."
            ChangePasswordTitleText="" ConfirmNewPasswordLabelText="Confirmar Nova Senha:"
            ConfirmPasswordCompareErrorMessage="Confirme a nova senha que deve corresponder à nova entrada de senha."
            ConfirmPasswordRequiredErrorMessage="É necessário confirmar a nova senha. " NewPasswordLabelText="Nova Senha:"
            NewPasswordRegularExpressionErrorMessage="Por favor, digite uma senha diferente."
            NewPasswordRequiredErrorMessage="É necessária nova senha." PasswordLabelText="Senha:"
            PasswordRequiredErrorMessage="É exigido senha." SuccessText="Sua senha foi alterada!"
            SuccessTitleText="Alteração de senha completada." UserNameLabelText="Nome de usuário:"
            UserNameRequiredErrorMessage="É necessário nome de usuário.">
            <ChangePasswordTemplate>
                <table border="0" cellpadding="1" cellspacing="0" 
                    style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nome 
                                        de usuário:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Width="130px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="É necessário nome de usuário." 
                                            ToolTip="É necessário nome de usuário." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                            AssociatedControlID="CurrentPassword">Senha:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" 
                                            Width="130px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                            ControlToValidate="CurrentPassword" ErrorMessage="É exigido senha." 
                                            ToolTip="É exigido senha." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="NewPasswordLabel" runat="server" 
                                            AssociatedControlID="NewPassword">Nova Senha:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="130px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                            ControlToValidate="NewPassword" ErrorMessage="É necessária nova senha." 
                                            ToolTip="É necessária nova senha." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                            AssociatedControlID="ConfirmNewPassword">Confirmar Nova Senha:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" 
                                            Width="130px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                            ControlToValidate="ConfirmNewPassword" 
                                            ErrorMessage="É necessário confirmar a nova senha. " 
                                            ToolTip="É necessário confirmar a nova senha. " 
                                            ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                            ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                            Display="Dynamic" 
                                            ErrorMessage="Confirme a nova senha que deve corresponder à nova entrada de senha." 
                                            ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                            CommandName="ChangePassword" Text="Alterar Senha" 
                                            ValidationGroup="ChangePassword1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                            CommandName="Cancel" Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ChangePasswordTemplate>
        </asp:ChangePassword>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

