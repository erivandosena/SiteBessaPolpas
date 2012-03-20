<%@ WebHandler Language="C#" Class="HandlerImagemLogo" %>

using System;
using System.IO;
using System.Web;
using Rwd.BLL;

public class HandlerImagemLogo : IHttpHandler {
    
    public void ProcessRequest(HttpContext context)
    {
        // Configure as definições de resposta
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;
        // Configuração do Tamanho Parâmetro
        TamanhoImagem size;
        switch (context.Request.Params["tamanho"])
        {
            case "M":
                size = TamanhoImagem.Miniatura;
                break;
            case "N":
                size = TamanhoImagem.Normal;
                break;
            case "A":
                size = TamanhoImagem.Ampliado;
                break;
            default:
                size = TamanhoImagem.Miniatura;
                break;
        }
        
        // Instalação do PhotoID Parâmetro
        Int32 id = -1;
        Stream stream = null;

        // Imagem site
        if (context.Request.QueryString["imgsit"] != null && context.Request.QueryString["imgsit"] != "")
        {
            id = Convert.ToInt32(context.Request.QueryString["imgsit"]);
            stream = BusinessLogic.ExibeFotoSite(id);
        }

        // Tire a foto do banco de dados, se nada for devolvido, receber o padrão "placeholder" foto
        if (stream == null) stream = BusinessLogic.ExibeFotoPasta(size);

        // Escreve imagem stream para a resposta stream
        const int buffersize = 1024 * 16;
        byte[] buffer = new byte[buffersize];
        int count = stream.Read(buffer, 0, buffersize);
        while (count > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, count);
            count = stream.Read(buffer, 0, buffersize);
        }
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

}