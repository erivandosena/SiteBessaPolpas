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

public partial class _Default : System.Web.UI.Page
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
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["sit_titulo"].ToString();

                    Label1.Text = dr["sit_banner1"].ToString();
                    Label2.Text = dr["sit_banner2"].ToString();

                    //Adiciona description Meta control 
                    MetaDescription = dr["sit_titulo"].ToString() + " - " + dr["sit_telefone"].ToString() + " , " + dr["sit_cidade"].ToString() + " - " + dr["sit_estado"].ToString();

                    //Adiciona keywords Meta control
                    using (DataSet ds = BusinessLogic.SelecionaPaginasNomesDs())
                    {
                        MetaKeywords = DatasetToString(ds, dr["sit_cidade"].ToString());
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
