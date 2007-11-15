<%@ Page Language="C#" MasterPageFile="~/Adm/MasterPageAdm.master" AutoEventWireup="true" CodeFile="CadUsuario.aspx.cs" Inherits="Usuarios_CadUsuario" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type='text/javascript'>
function iframeAutoHeight(quem){ 
    if(navigator.appName.indexOf("Internet Explorer")>-1){ //ie sucks
        var func_temp = function(){
            var val_temp = quem.contentWindow.document.body.scrollHeight + 15
            quem.style.height = val_temp + "px";
        }
        setTimeout(function() { func_temp() },100) //ie sucks
    }else{
        var val = quem.contentWindow.document.body.parentNode.offsetHeight + 15
        quem.style.height= val + "px";
    }    
}
</script>

    <h1 class="heading">
        Cadastro de Usuário</h1>
    <div class="entry">
        <ul>
            <li><a href="/Usuarios">Voltar</a></li></ul>
    </div>
    <!-- entry -->
    <p>
        <iframe name="IfNovoUsuario" align="middle" marginwidth="0" marginheight="0" src="NovoUsuario.aspx"
            frameborder="0" scrolling="auto" onload="iframeAutoHeight(this)" allowtransparency="true"
            width="550"></iframe>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

