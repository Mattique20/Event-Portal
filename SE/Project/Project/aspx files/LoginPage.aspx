<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SE.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="..\css\Login.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="Title" runat="server" Text="Login"></asp:Label>
                <asp:Panel ID="Panel2" runat="server">
                    <label for="TextBox1">Username:</label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <label for="TextBox2">Password:</label>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                    <asp:Button ID="toReg" runat="server" Text="Go to Register" OnClick="toReg_Click" />
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
