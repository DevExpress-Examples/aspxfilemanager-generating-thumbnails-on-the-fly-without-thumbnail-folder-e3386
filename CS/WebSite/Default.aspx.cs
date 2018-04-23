using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using DevExpress.Web.ASPxFileManager;

public partial class _Default : System.Web.UI.Page {
    protected void ASPxFileManager1_CustomThumbnail(object source, DevExpress.Web.ASPxFileManager.FileManagerThumbnailCreateEventArgs e) {
        if(ThumbHelper.CanCreateThumbnail(e.File.Extension)) {
            string imageKey = ThumbHelper.GetHash(e.File.RelativeName);
            e.ThumbnailImage.Url = "Thumb.ashx?key=" + imageKey;
        }
    }
}