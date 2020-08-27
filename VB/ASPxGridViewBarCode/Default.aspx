<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ASPxGridViewBarCode.Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ID" />
                    <dx:GridViewDataColumn>
                        <DataItemTemplate>
                            <dx:ASPxBinaryImage ID="BinaryImage" runat="server" OnInit="BinaryImage_Init"></dx:ASPxBinaryImage>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>

            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>