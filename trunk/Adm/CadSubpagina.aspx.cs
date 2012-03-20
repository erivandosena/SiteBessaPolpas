﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Rwd.BLL;
using Npgsql;
using Rwd.Util;

public partial class Adm_CadSubpagina : System.Web.UI.Page
{
    string CodSubPagina = null;
    string CodPagina = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadpaginas.aspx
        //if (!Roles.IsUserInRole("Administrador") == true)
        //{
        //    Response.Redirect("/Adm/Default.aspx");
        //}


        CodSubPagina = Request.QueryString["CodSubPagina"];
        CodPagina = Request.QueryString["CodPagina"];

        if (string.IsNullOrEmpty(CodSubPagina))
        {
            Button1.Text = "Salvar";
            if (!IsPostBack)
            {
                RelacionaPaginas();
            }
        }
        else
        {
            if (!IsPostBack)
            {
                RelacionaPaginas();
                CarregaSubPagina();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
        }
    }

    private void RelacionaPaginas()
    {
        using (DataSet ds = BusinessLogic.SelecionaPaginasDs(0, "%"))
        {
            DropDownList.DataSource = ds;
            DropDownList.DataMember = ds.Tables[0].TableName;
            DropDownList.DataTextField = "pag_nome";
            DropDownList.DataValueField = "pag_cod";
            DropDownList.DataBind();
            DropDownList.Items.Add(new ListItem("", "0"));
            DropDownList.SelectedValue = "0";
        }
    }

    private void CarregaSubPagina()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSubPaginasDr(int.Parse(CodSubPagina), 0, null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["sub_cod"].ToString();
                    DropDownList.SelectedValue = dr["pag_cod"].ToString();
                    TextBoxNome.Text = dr["sub_nome"].ToString();
                    TextBoxDesc.Text = dr["sub_descricao"].ToString();
                    FCKeditorPag.Value = dr["sub_conteudo"].ToString();
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Valida campos
            LblMsg.Text = "";
            if (Util.valida(DropDownList.SelectedValue) != string.Empty)
            {
                LblMsg.Text = Util.valida(DropDownList.SelectedValue);
                LblMsg.Text = "Página principal - " + LblMsg.Text;
                DropDownList.Focus();
            }
            else
            if (Util.valida(TextBoxNome.Text) != string.Empty)
            {
                LblMsg.Text = Util.valida(TextBoxNome.Text);
                LblMsg.Text = "Título para o link da página - " + LblMsg.Text;
                TextBoxNome.Focus();
            }
            else
                if (Util.valida(TextBoxDesc.Text) != string.Empty)
                {
                    LblMsg.Text = Util.valida(TextBoxDesc.Text);
                    LblMsg.Text = "Descrição para o link da página - " + LblMsg.Text;
                    TextBoxDesc.Focus();
                }
                else
                    if (Util.valida(FCKeditorPag.Value) != string.Empty)
                    {
                        LblMsg.Text = Util.valida(FCKeditorPag.Value);
                        LblMsg.Text = "Conteúdo da página - " + LblMsg.Text;
                        FCKeditorPag.Focus();
                    }
                    else
                            if (IsValid)
                            {
                                int pag_cod = int.Parse(DropDownList.SelectedValue);
                                string sub_nome = TextBoxNome.Text;
                                string sub_descricao = TextBoxDesc.Text;
                                string sub_conteudo = FCKeditorPag.Value;

                                if (Label1.Text == string.Empty)
                                {
                                    //Insere
                                    BusinessLogic.InsereSubPaginas(pag_cod, sub_nome, sub_descricao, sub_conteudo);
                                    LblMsg.Text = "Página cadastrada com sucesso!";
                                    LimpaControles(this);
                                    Label1.Text = string.Empty;
                                }
                                else
                                {
                                    //Atualiza
                                    BusinessLogic.AtualizaSubPaginas(int.Parse(CodSubPagina), pag_cod, sub_nome, sub_descricao, sub_conteudo);
                                    LblMsg.Text = "Página atualizada com sucesso!";
                                    CarregaSubPagina();
                                }
                            }

        }
        catch (NpgsqlException ex)
        {
            LblMsg.Text = "Erro nos dados: " + ex.Message;
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Erro no sistema: " + ex.Message;
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is DropDownList) ((DropDownList)ctl).SelectedIndex = -1;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Subpaginas.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int sub_cod = int.Parse(CodSubPagina);

            BusinessLogic.ExcluiSubPaginas(sub_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;

            LblMsg.Text = "Página excluída com sucesso!";

        }
        catch (NpgsqlException ex)
        {
            LblMsg.Text = "Erro nos dados: " + ex.Message;
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Erro no sistema: " + ex.Message;
        }
    }
}
