using DevExpress.BarCodes;
using DevExpress.Web;
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ASPxGridViewBarCode {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            Grid.DataSource = Enumerable.Range(0, 10).Select(i => new { ID = i, Text = "Some Column Text " + i });
            Grid.DataBind();
        }

        protected void BinaryImage_Init(object sender, EventArgs e) {
            var image = (ASPxBinaryImage)sender;
            var container = (GridViewDataItemTemplateContainer)image.NamingContainer;
            var value = container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Text" });
            if (value != null)
                image.ContentBytes = GetBarCodeImage(value.ToString());
        }

        public byte[] GetBarCodeImage(string parameter) {
            BarCode barCode = new BarCode();
            barCode.Symbology = Symbology.QRCode;
            barCode.CodeText = parameter;
            barCode.BackColor = Color.White;
            barCode.ForeColor = Color.Black;
            barCode.RotationAngle = 0;
            barCode.CodeBinaryData = Encoding.Default.GetBytes(barCode.CodeText);
            barCode.Options.QRCode.CompactionMode = QRCodeCompactionMode.Byte;
            barCode.Options.QRCode.ErrorLevel = QRCodeErrorLevel.Q;
            barCode.Options.QRCode.ShowCodeText = false;
            barCode.DpiX = 72;
            barCode.DpiY = 72;
            return ImageToByte(barCode.BarCodeImage);
        }

        public static byte[] ImageToByte(Image img) {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}