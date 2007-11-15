using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Npgsql;
using Rwd.BLL;

public partial class Conteudo : System.Web.UI.Page
{
    public string MetaDescription
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "description";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    public string MetaKeywords
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "keywords";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    string Pagina = null;
    string SubPagina = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        Pagina = Request.QueryString["pag"];
        SubPagina = Request.QueryString["sub"];

        CarregaDadosWebsite();

        if (!string.IsNullOrEmpty(Pagina) && string.IsNullOrEmpty(SubPagina))
        {
            CarregaConteudo();
        }

        if (!string.IsNullOrEmpty(SubPagina) && string.IsNullOrEmpty(Pagina))
        {
            CarregaSubConteudo();
        }

        if (string.IsNullOrEmpty(LabelPagina.Text.Trim()))
        {
            Response.Redirect("#");
        }
    }

    private void CarregaConteudo()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaPaginasDr(int.Parse(Pagina), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Header.Title = Page.Title + " - " + dr["pag_nome"].ToString();
                    LabelPagina.Text = dr["pag_conteudo"].ToString();

                    //Adiciona description Meta control 
                    MetaDescription = Page.Header.Title + " - " + dr["pag_descricao"].ToString();
                }
            }
        }
    }

    private void CarregaSubConteudo()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSubPaginasDr(int.Parse(SubPagina), 0, null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Header.Title = Page.Title + " - " + dr["sub_nome"].ToString();
                    LabelPagina.Text = dr["sub_conteudo"].ToString();

                    //Adiciona description Meta control 
                    MetaDescription = Page.Header.Title + " - " + dr["sub_descricao"].ToString();
                }
            }
        }
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["sit_titulo"].ToString();
                    Label1.Text = dr["sit_publicidade"].ToString();

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaPaginasNomesDs())
                    {
                        MetaKeywords = DatasetToString(ds, dr["sit_estado"].ToString());
                    }
                }
            }
        }
    }

    private string DatasetToString(DataSet ds, string strFixo)
    {
        Int32 i = 0;
        String str = strFixo;
        using (DataTable dt = ds.Tables[0])
        {
            while (i < dt.Rows.Count)
            {
                str += ", " + dt.Rows[i][0].ToString() + ", " + dt.Rows[i][1].ToString();
                i++;
            }
            return (str);
        }
    }
}