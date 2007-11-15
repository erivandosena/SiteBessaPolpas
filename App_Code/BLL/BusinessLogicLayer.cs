using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Rwd.DAL;
using Npgsql;

/// <summary>
/// Summary description for NoticiasBLL
/// </summary>
/// 

namespace Rwd.BLL
{

    [DataObject(true)]
    public class BusinessLogic
    {
        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE PÁGINAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InserePaginas(string pag_nome, string pag_descricao, string pag_conteudo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);

                db.ExecuteNonQuery("insere_paginas");
            }
        }
        //Atualiza
        public static void AtualizaPaginas(int pag_cod, string pag_nome, string pag_descricao, string pag_conteudo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);

                db.ExecuteNonQuery("atualiza_paginas");
            }
        }

        //Exclui
        public static void ExcluiPaginas(int pag_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);

                db.ExecuteNonQuery("exclui_paginas");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaPaginasDr(int pag_cod, string pag_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_paginas");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasDs(int pag_cod, string pag_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_paginas");
                return ds;
            }
        }

        //Seleciona nomes paginas por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_paginas_nome");
                return ds;
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE SUBPÁGINAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereSubPaginas(int pag_cod, string sub_nome, string sub_descricao, string sub_conteudo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);
                db.AddParameter("@sub_nome", sub_nome);
                db.AddParameter("@sub_descricao", sub_descricao);
                db.AddParameter("@sub_conteudo", sub_conteudo);

                db.ExecuteNonQuery("insere_subpaginas");
            }
        }
        //Atualiza
        public static void AtualizaSubPaginas(int sub_cod, int pag_cod, string sub_nome, string sub_descricao, string sub_conteudo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sub_cod", sub_cod);
                db.AddParameter("@pag_cod", pag_cod);
                db.AddParameter("@sub_nome", sub_nome);
                db.AddParameter("@sub_descricao", sub_descricao);
                db.AddParameter("@sub_conteudo", sub_conteudo);

                db.ExecuteNonQuery("atualiza_subpaginas");
            }
        }

        //Exclui
        public static void ExcluiSubPaginas(int sub_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sub_cod", sub_cod);

                db.ExecuteNonQuery("exclui_subpaginas");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaSubPaginasDr(int sub_cod, int pag_cod, string sub_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@sub_cod", sub_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@sub_nome", sub_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_subpaginas");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaSubPaginasDs(int sub_cod, int pag_cod, string sub_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@sub_cod", sub_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@sub_nome", sub_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_subpaginas");
                return ds;
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE SITE
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereSite(
            string sit_titulo,
            string sit_endereco,
            string sit_cidade,
            string sit_estado,
            string sit_cep,
            string sit_telefone,
            string sit_email,
            string sit_banner1,
            string sit_banner2,
            string sit_publicidade,
            byte[] sit_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_titulo", sit_titulo);
                db.AddParameter("@sit_slogan", null);
                db.AddParameter("@sit_endereco", sit_endereco);
                db.AddParameter("@sit_cidade", sit_cidade);
                db.AddParameter("@sit_estado", sit_estado);
                db.AddParameter("@sit_cep", sit_cep);
                db.AddParameter("@sit_telefone", sit_telefone);
                db.AddParameter("@sit_email", sit_email);
                db.AddParameter("@sit_skype", null);
                db.AddParameter("@sit_twitter", null);
                db.AddParameter("@sit_orkut", null);
                db.AddParameter("@sit_youtube", null);
                db.AddParameter("@sit_banner1", sit_banner1);
                db.AddParameter("@sit_banner2", sit_banner2);
                db.AddParameter("@sit_publicidade", sit_publicidade);

                if (sit_logo == null)
                {
                    db.AddParameter("@sit_logo", sit_logo);
                }
                else
                {
                    db.AddParameter("@sit_logo", ResizeImageFile(sit_logo, 273));
                }

                db.ExecuteNonQuery("insere_site");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaSiteDr()
        {
            using (DataAccess db = new DataAccess())
            {
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_site");
                return dr;
            }
        }

        //Atualiza
        public static void AtualizaSite(
            int sit_cod,
            string sit_titulo,
            string sit_endereco,
            string sit_cidade,
            string sit_estado,
            string sit_cep,
            string sit_telefone,
            string sit_email,
            string sit_banner1,
            string sit_banner2,
            string sit_publicidade)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);
                db.AddParameter("@sit_titulo", sit_titulo);
                db.AddParameter("@sit_slogan", null);
                db.AddParameter("@sit_endereco", sit_endereco);
                db.AddParameter("@sit_cidade", sit_cidade);
                db.AddParameter("@sit_estado", sit_estado);
                db.AddParameter("@sit_cep", sit_cep);
                db.AddParameter("@sit_telefone", sit_telefone);
                db.AddParameter("@sit_email", sit_email);
                db.AddParameter("@sit_skype", null);
                db.AddParameter("@sit_twitter", null);
                db.AddParameter("@sit_orkut", null);
                db.AddParameter("@sit_youtube", null);
                db.AddParameter("@sit_banner1", sit_banner1);
                db.AddParameter("@sit_banner2", sit_banner2);
                db.AddParameter("@sit_publicidade", sit_publicidade);

                db.ExecuteNonQuery("atualiza_site");
            }
        }

        //Atualiza imagem
        public static void AtualizaSiteImagem(int sit_cod, byte[] sit_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);

                if (sit_logo == null)
                {
                    db.AddParameter("@sit_logo", sit_logo);
                }
                else
                {
                    db.AddParameter("@sit_logo", ResizeImageFile(sit_logo, 273));
                }

                db.ExecuteNonQuery("atualiza_site_imagem");
            }
        }

        //Exclui
        public static void ExcluiSite(int sit_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@sit_cod", sit_cod);

                db.ExecuteNonQuery("exclui_site");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE TRATAMENTO DE IMAGEM
        ////////////////////////////////////////////////////////////////////
        //Helper Functions
        private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
            {
                Size newSize = CalculateDimensions(oldImage.Size, targetSize);                 //Format24bppRgb
                using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format64bppArgb))
                {
                    using (Graphics canvas = Graphics.FromImage(newImage))
                    {
                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                        MemoryStream m = new MemoryStream();

                        //Nível de compactação do conjunto JPEG
                        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                        Encoder myEncoder = Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 96L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        //

                        newImage.Save(m, jgpEncoder, myEncoderParameters); 
                        //newImage.Save(m, ImageFormat.Jpeg);
                        return m.GetBuffer();
                    }
                }
            }
        }

        //Encoder
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        //Dimensiona
        private static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }

        //Imagem site
        public static Stream ExibeFotoSite(int id)
        {

            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", id);
                object result = db.ExecuteScalar("seleciona_site_imagem");
                try
                {
                    return new MemoryStream((byte[])result);
                }
                catch
                {
                    return null;
                }
            }

        }

        //Trata erro relacionado á imagem
        public static Stream ExibeFotoPasta(TamanhoImagem size)
        {
            string path = HttpContext.Current.Server.MapPath("~/Images/");
            switch (size)
            {
                case TamanhoImagem.Miniatura:
                    path += "si_200.gif";
                    break;
                case TamanhoImagem.Normal:
                    path += "si_400.gif";
                    break;
                case TamanhoImagem.Ampliado:
                    path += "si_900.gif";
                    break;
                default:
                    path += "si_200.gif";
                    break;
            }
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        ////////////////////////////////////////////////////////////////////
    }
}

public enum TamanhoImagem
{
    Miniatura = 1,	//ex.: 200px
    Normal = 2,		//ex.: 500px
    Ampliado = 3	//ex.: 900px
}