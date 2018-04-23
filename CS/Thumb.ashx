<%@ WebHandler Language="C#" Class="Thumb" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Thumb : IHttpHandler {
    readonly string FileManagerRootFolder = HttpContext.Current.Server.MapPath("~\\");
    
    public void ProcessRequest(HttpContext context) {
        string key = HttpContext.Current.Request.QueryString["key"];
        if(!string.IsNullOrEmpty(key)) {
            using(Image thumb = ThumbHelper.GetThumbnail(FileManagerRootFolder + ThumbHelper.GetPath(key)))
                thumb.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            context.Response.ContentType = "image/png";
        }
    }

    public bool IsReusable { get { return true; } }
}