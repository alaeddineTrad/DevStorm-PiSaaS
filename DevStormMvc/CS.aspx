<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
    <hr />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
        <Columns>
            <asp:BoundField DataField="Text" />
            <asp:ImageField  DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
