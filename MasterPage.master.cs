using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Npgsql;
using Rwd.BLL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LblSaldacao.Text = Saldacao();

        CarregaDadosWebsite();
        if (Page.Title == "Untitled Page")
        {
            if (Session["Titulo"] == null)
            {
                CarregaDadosWebsite();
            }
            Page.Title = Session["Titulo"].ToString();
        }
    }

    private static string Saldacao()
    {
        DateTime tempo = DateTime.Now;

        string mensagem = string.Empty;

        if (tempo.Hour > 6 && tempo.Hour < 12)
            mensagem = "Bom dia";
        else if (tempo.Hour >= 12 && tempo.Hour < 18)
            mensagem = "Boa tarde";
        else
            mensagem = "Boa noite";
        return mensagem;
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ImageLogo.ImageUrl = "/HandlerImgs.ashx?imgsit=" + dr["sit_cod"].ToString();
                    ImageLogo.AlternateText = dr["sit_titulo"].ToString();
                    LabelCopyright.Text = DateTime.Now.Year + " " + dr["sit_titulo"].ToString();
                    Session["Titulo"] = dr["sit_titulo"].ToString() + " - " + dr["sit_telefone"].ToString();

                    byte[] logo = dr["sit_logo"] as byte[];
                    if (logo == null)
                    {
                        ImageLogo.Visible = false;
                    }
                    else
                    {
                        ImageLogo.Visible = true;
                    }
                }
            }
            else
            {
                //Se não carregar dados a session é vazia
                Session["Titulo"] = "";
            }
        }
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)(e.Item.DataItem);
            int quantity = int.Parse(drv.Row["pag_cod"].ToString());

            using (DataSet ds = BusinessLogic.SelecionaSubPaginasDs(0, quantity,null))
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataList Dtl = (DataList)e.Item.FindControl("DataList2");
                    Dtl.DataSource = ds;
                    Dtl.DataBind();
                }
            }
        }

    }
}
