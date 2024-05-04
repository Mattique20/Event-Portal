<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SE.LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../CSS/Login.css" rel="stylesheet" />
    <style>
        body {
    font-family: Arial, sans-serif; /* Good font choice */
    background: url('../images/Background.jpg') no-repeat center center fixed;
    background-size: cover;
}

/* Style the panel */
form div #Panel1 {
    position: relative;
    width: 420px;
    height: 380px;
    background-color: transparent;
    border: 2px solid rgba(255, 255, 255, .1);
    border-radius: 20px;
    backdrop-filter: blur(30px);
    box-shadow: 0 0 10px rgba(0,0,0,.2);
    color: royalblue;
    margin: auto; /* Centering the wrapper horizontally */
    margin-top: 100px; /* Adjust this value to control the vertical position */
    display: flex;
    align-items: center;
    justify-content: center; /* Align items horizontally to the center */
    overflow: hidden;
    flex-direction: column; /* Align items vertically */
}

    </style>
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
