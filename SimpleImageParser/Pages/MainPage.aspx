<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SimpleImageParser.Pages.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Put url of html you want to parse images from"></asp:Label>
            <div></div>
            <asp:TextBox runat="server" ID="TextUrl" Width="500"></asp:TextBox>
            <div></div>
            <asp:Button runat="server" Text="Parse Images" OnClick="Unnamed_Click"/>
            <asp:Table runat="server" ID="aspElements">
                
            </asp:Table>
        </div>
    </form>
</body>
</html>
