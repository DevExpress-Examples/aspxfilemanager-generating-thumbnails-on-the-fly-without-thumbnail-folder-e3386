Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports DevExpress.Web.ASPxFileManager

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ASPxFileManager1_CustomThumbnail(ByVal source As Object, ByVal e As DevExpress.Web.ASPxFileManager.FileManagerThumbnailCreateEventArgs)
        If ThumbHelper.CanCreateThumbnail(e.File.Extension) Then
            Dim imageKey As String = ThumbHelper.GetHash(e.File.RelativeName)
            e.ThumbnailImage.Url = "Thumb.ashx?key=" & imageKey
        End If
    End Sub
End Class