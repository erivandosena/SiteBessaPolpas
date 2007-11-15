<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="destaque-flash">
            <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <!-- destaque-flash -->
    <div class="sub-line">
    </div>
    <!-- sub-line-->
    <div id="flash-slide">
    <div class="entry">
        <asp:Label ID="Label2" runat="server"></asp:Label>
	</div>
        <!-- entry -->
    </div>
    <!-- flash-slide -->
</asp:Content>

