Imports DevExpress.BarCodes
Imports DevExpress.Web
Imports System
Imports System.Drawing
Imports System.Linq
Imports System.Text

Namespace ASPxGridViewBarCode
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            Grid.DataSource = Enumerable.Range(0, 10).Select(Function(i) New With {Key .ID = i, Key .Text = "Some Column Text " & i})
            Grid.DataBind()
        End Sub

        Protected Sub BinaryImage_Init(ByVal sender As Object, ByVal e As EventArgs)
            Dim image = DirectCast(sender, ASPxBinaryImage)
            Dim container = CType(image.NamingContainer, GridViewDataItemTemplateContainer)
            Dim value = container.Grid.GetRowValues(container.VisibleIndex, New String() { "Text" })
            If value IsNot Nothing Then
                image.ContentBytes = GetBarCodeImage(value.ToString())
            End If
        End Sub

        Public Function GetBarCodeImage(ByVal parameter As String) As Byte()
            Dim barCode As New BarCode()
            barCode.Symbology = Symbology.QRCode
            barCode.CodeText = parameter
            barCode.BackColor = Color.White
            barCode.ForeColor = Color.Black
            barCode.RotationAngle = 0
            barCode.CodeBinaryData = Encoding.Default.GetBytes(barCode.CodeText)
            barCode.Options.QRCode.CompactionMode = QRCodeCompactionMode.Byte
            barCode.Options.QRCode.ErrorLevel = QRCodeErrorLevel.Q
            barCode.Options.QRCode.ShowCodeText = False
            barCode.DpiX = 72
            barCode.DpiY = 72
            Return ImageToByte(barCode.BarCodeImage)
        End Function

        Public Shared Function ImageToByte(ByVal img As Image) As Byte()
            Dim converter As New ImageConverter()
            Return DirectCast(converter.ConvertTo(img, GetType(Byte())), Byte())
        End Function
    End Class
End Namespace