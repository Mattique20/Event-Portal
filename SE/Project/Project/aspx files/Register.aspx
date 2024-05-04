<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SE.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="..\css\Register.css">
    <style>
        body {
    font-family: Arial, sans-serif; /* Good font choice */
    background: url('../images/Background.jpg') no-repeat center center fixed;
    background-size: cover;
}

    /* Style the panel */
    #Panel1 {
    position: relative;
    width: 420px;
    height: 580px; /* Reduced height for a more compact layout (optional) */
    background-color: transparent;
    border: 2px solid rgba(255, 255, 255, .1);
    border-radius: 20px;
    backdrop-filter: blur(30px);
    box-shadow: 0 0 10px rgba(0,0,0,.2);
    color: royalblue;
    margin: auto; /* Centering the wrapper horizontally */
    margin-top: 60px; /* Adjust this value to control the vertical position */
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
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Title" runat="server" Text="Register"></asp:Label>
            <div>
                <label for="name">Name:</label>
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="email">Email:</label>
                <asp:TextBox ID="email" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="gender">Gender:</label>
                <asp:TextBox ID="gender" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="rollNumber">Roll Number:</label>
                <asp:TextBox ID="rollNumber" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="reg" runat="server" Text="Register" OnClick="reg_Click" />
            <asp:Button ID="toLogin" runat="server" Text="Go to Login" OnClick="toLogin_Click" />
        </asp:Panel>
    </form>
</body>
</html>
