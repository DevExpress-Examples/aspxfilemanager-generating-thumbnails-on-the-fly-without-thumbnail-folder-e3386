<%@ WebHandler Language="vb" Class="Thumb" %>

Imports System
Imports System.Web
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Thumb
    Implements IHttpHandler

    Dim ReadOnly FileManagerRootFolder As String = HttpContext.Current.Server.MapPath("~\")

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim key As String = HttpContext.Current.Request.QueryString("key")
        If Not String.IsNullOrEmpty(key) Then
            Using thumb As Image = ThumbHelper.GetThumbnail(FileManagerRootFolder & ThumbHelper.GetPath(key))
                thumb.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png)
            End Using
            context.Response.ContentType = "image/png"
        End If
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property
End Class