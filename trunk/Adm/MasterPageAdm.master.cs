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

public partial class Adm_MasterPageAdm : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDadosWebsite();
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Title = dr["sit_titulo"].ToString() + " - Administrativo";
                    ImageLogo.ImageUrl = "/HandlerImgs.ashx?imgsit=" + dr["sit_cod"].ToString();

                    byte[] logo = dr["sit_logo"] as byte[];
                    if (logo == null)
                    {
                        ImageLogo.Visible = false;
                    }
                }
            }
            else
            {
                Page.Title = "";
            }
        }
    }
}
