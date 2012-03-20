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
using Rwd.BLL;
using Npgsql;

public partial class Adm_CadSite : System.Web.UI.Page
{
    byte[] logo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ os botoes: salvar, excluir, remove
        //if (Roles.IsUserInRole("Administrador") == true)
        //{
            Button1.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
        //}
        //else
        //{
        //    Button1.Enabled = false;
        //    Button3.Enabled = false;
        //    Button4.Enabled = false;
        //}

        if (!IsPostBack)
        {
            CarregaCadastro();
        }
    }

    private void CarregaCadastro()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaSiteDr())
        {
            while (dr.Read())
            {

                Label1.Text = dr["sit_cod"].ToString();

                TextBoxNome.Text = dr["sit_titulo"].ToString();
              //  TextBoxSlogan.Text = dr["sit_slogan"].ToString();
                TextBox1.Text = dr["sit_endereco"].ToString();
                TextBox2.Text = dr["sit_cep"].ToString();
                TextBoxCidade.Text = dr["sit_cidade"].ToString();
                TextBoxEstado.Text = dr["sit_estado"].ToString();
                TextBoxTel1.Text = dr["sit_telefone"].ToString();
                TextBoxEmail1.Text = dr["sit_email"].ToString().ToLower();
                //TextBoxEmail2.Text = dr["sit_skype"].ToString().ToLower();
                //TextBoxEmail3.Text = dr["sit_twitter"].ToString().ToLower();
                //TextBoxEmail4.Text = dr["sit_orkut"].ToString().ToLower();
                //TextBoxEmail5.Text = dr["sit_youtube"].ToString().ToLower();
                FCKeditorImg.Value = dr["sit_banner1"].ToString();
                FCKeditorFlash.Value = dr["sit_banner2"].ToString();
                FCKeditorPub.Value = dr["sit_publicidade"].ToString();
                Image1.ImageUrl = "/HandlerImgs.ashx?imgsit=" + Label1.Text;

                logo = dr["sit_logo"] as byte[];
                if (logo != null)
                {
                    Button4.Visible = true;
                }

                Button1.Text = "Atualizar";
                Button3.Visible = true;
            }
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {

                string sit_titulo = TextBoxNome.Text;
             //   string sit_slogan = TextBoxSlogan.Text;
                string sit_endereco = TextBox1.Text;
                string sit_cidade = TextBoxCidade.Text;
                string sit_estado = TextBoxEstado.Text;
                string sit_cep = TextBox2.Text;
                string sit_telefone = TextBoxTel1.Text;
                string sit_email = TextBoxEmail1.Text.ToLower();
                //string sit_skype = TextBoxEmail2.Text;
                //string sit_twitter = TextBoxEmail3.Text;
                //string sit_orkut = TextBoxEmail4.Text;
                //string sit_youtube = TextBoxEmail5.Text;
                string sit_banner1 = FCKeditorImg.Value;
                string sit_banner2 = FCKeditorFlash.Value;
                string sit_publicidade = FCKeditorPub.Value;

                if (FileUpload1.HasFile)
                {
                    logo = FileUpload1.FileBytes;
                }
                else
                {
                    logo = null;
                }

                if (Label1.Text == string.Empty)
                {
                    //Insere
                    BusinessLogic.InsereSite(
                        sit_titulo,
                        sit_endereco,
                        sit_cidade,
                        sit_estado,
                        sit_cep,
                        sit_telefone,
                        sit_email,
                        sit_banner1,
                        sit_banner2,
                        sit_publicidade,
                        logo);
                    LblMsg.Text = "Cadastrado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }
                else
                {
                    //Atualiza
                    if (FileUpload1.HasFile)
                    {
                        logo = FileUpload1.FileBytes;
                        BusinessLogic.AtualizaSiteImagem(int.Parse(Label1.Text), logo);
                    }
                    BusinessLogic.AtualizaSite(
                        int.Parse(Label1.Text),
                        sit_titulo,
                        sit_endereco,
                        sit_cidade,
                        sit_estado,
                        sit_cep,
                        sit_telefone,
                        sit_email,
                        sit_banner1,
                        sit_banner2,
                        sit_publicidade);
                    LblMsg.Text = "Cadastro atualizado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }

                CarregaCadastro();
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic.ExcluiSite(int.Parse(Label1.Text));

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Text = "Salvar";
            Button3.Visible = false;

            LblMsg.Text = "Cadastro excluído com sucesso!";

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
    protected void Button4_Click(object sender, EventArgs e)
    {
        logo = null;
        BusinessLogic.AtualizaSiteImagem(int.Parse(Label1.Text), logo);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
