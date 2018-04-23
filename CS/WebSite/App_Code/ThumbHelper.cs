using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

/// <summary>
/// Summary description for HashHelper
/// </summary>
public static class ThumbHelper {
    const int Size = 90;
    readonly static string[] ImageExtensions = new string[] { ".png", ".gif", ".jpg", ".jpeg", ".ico", ".bmp" };

    public static string GetHash(string path) {
        byte[] bytes = Encoding.UTF8.GetBytes(path);
        return Convert.ToBase64String(bytes);
    }
    public static string GetPath(string hash) {
        byte[] bytes = Convert.FromBase64String(hash);
        return Encoding.UTF8.GetString(bytes);
    }
    public static bool CanCreateThumbnail(string ext) {
        return ImageExtensions.Contains(ext);
    }
    public static Bitmap GetThumbnail(string filePath) {
        using(Image original = Image.FromFile(filePath)) {
            Bitmap thumbnail = new Bitmap(Size, Size);

            int newHeight = original.Height;
            int newWidth = original.Width;
            if(original.Height > Size || original.Width > Size) {
                newHeight = (original.Height > original.Width) ? Size : (int)(Size * original.Height / original.Width);
                newWidth = (original.Width > original.Height) ? Size : (int)(Size * original.Width / original.Height);
            }

            Graphics g = Graphics.FromImage(thumbnail);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(original, (int)(Size - newWidth) / 2, (int)(Size - newHeight) / 2, newWidth, newHeight);

            return thumbnail;
        }
    }
}