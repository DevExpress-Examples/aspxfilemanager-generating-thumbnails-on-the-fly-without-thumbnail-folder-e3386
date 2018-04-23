Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>
''' Summary description for HashHelper
''' </summary>
Public NotInheritable Class ThumbHelper

    Private Sub New()
    End Sub

    Private Const Size As Integer = 90
    Private ReadOnly Shared ImageExtensions() As String = { ".png", ".gif", ".jpg", ".jpeg", ".ico", ".bmp" }

    Public Shared Function GetHash(ByVal path As String) As String
        Dim bytes() As Byte = Encoding.UTF8.GetBytes(path)
        Return Convert.ToBase64String(bytes)
    End Function
    Public Shared Function GetPath(ByVal hash As String) As String
        Dim bytes() As Byte = Convert.FromBase64String(hash)
        Return Encoding.UTF8.GetString(bytes)
    End Function
    Public Shared Function CanCreateThumbnail(ByVal ext As String) As Boolean
        Return ImageExtensions.Contains(ext)
    End Function
    Public Shared Function GetThumbnail(ByVal filePath As String) As Bitmap
        Using original As Image = Image.FromFile(filePath)
            Dim thumbnail As New Bitmap(Size, Size)

            Dim newHeight As Integer = original.Height
            Dim newWidth As Integer = original.Width
            If original.Height > Size OrElse original.Width > Size Then
                newHeight = If(original.Height > original.Width, Size, CInt(Size * original.Height \ original.Width))
                newWidth = If(original.Width > original.Height, Size, CInt(Size * original.Width \ original.Height))
            End If

            Dim g As Graphics = Graphics.FromImage(thumbnail)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(original, CInt(Size - newWidth) \ 2, CInt(Size - newHeight) \ 2, newWidth, newHeight)

            Return thumbnail
        End Using
    End Function
End Class