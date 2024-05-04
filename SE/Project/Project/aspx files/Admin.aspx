<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SE.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Event" runat="server" OnClick="Event_Click" Text="Manage Events" />
            <asp:Button ID="Hire" runat="server" OnClick="Hire_Click" Text="Hire Organiser" />
        </div>
    </form>
</body>
</html>
