<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_AcessoRapido.ascx.cs" Inherits="Adm_WUC_AcessoRapido" %>
<div class="entry">
<h5>
    Atalho para PÁGINAS PRINCIPAIS</h5>
<ul>
    <asp:DataList ID="DataListPaginas" runat="server" DataSourceID="DsPaginas" EnableViewState="False"
        ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <li><a href="<%# Eval("pag_cod", "CadPagina.aspx?codpagina={0}") %>">
                <%# Eval("pag_nome")%></a> </li>
        </ItemTemplate>
    </asp:DataList>
</ul>
<asp:ObjectDataSource ID="DsPaginas" runat="server" SelectMethod="SelecionaPaginasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="pag_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="pag_nome" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<hr />
<h5>
    Atalho para SUBPÁGINAS</h5>
<ul>
    <asp:DataList ID="DataListSubPaginas" runat="server" DataSourceID="DsSubPaginas"
        EnableViewState="False" ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <li><a href="<%# Eval("sub_cod", "Cadsubpagina.aspx?codsubpagina={0}") %>">
                <%# Eval("sub_nome")%></a> </li>
        </ItemTemplate>
    </asp:DataList>
</ul>
</div>
        <!-- entry -->
<asp:ObjectDataSource ID="DsSubPaginas" runat="server" SelectMethod="SelecionaSubPaginasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="sub_cod" Type="Int32" />
        <asp:Parameter Name="pag_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="sub_nome" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
