<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Conteudo.aspx.cs" Inherits="Conteudo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="post">
        <h1 class="heading"></h1>
        <div class="entry">
            <asp:Label ID="LabelPagina" runat="server"></asp:Label>
        </div>
        <!-- entry -->
    </div>
    <!-- post -->
    <div id="sidebar">
    <div class="entry">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
        <!-- entry -->
    </div>
    <!-- sidebar -->
</asp:Content>

