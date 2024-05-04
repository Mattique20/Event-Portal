<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HireOrganiser.aspx.cs" Inherits="SE.HireOrganiser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/HireOrganizer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="container">
        <header>
      <img src="../Images/logo.png" alt="FAST Logo" class="header-logo">  
        <h1>Fast Event Portal</h1>
      <nav>  
        <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
        <asp:Button ID="btnevents" runat="server" Text="Events" OnClick="btnevents_Click" />
      </nav>
    </header>
        <h1>Hire Organizer</h1>
        <div>
            <asp:Label ID="lblFacultyId" runat="server" Text="Faculty ID:"></asp:Label>
            <asp:TextBox ID="txtFacultyId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblFacultyName" runat="server" Text="Faculty Name:"></asp:Label>
            <asp:TextBox ID="txtFacultyName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblFacultyEmail" runat="server" Text="Faculty Email:"></asp:Label>
            <asp:TextBox ID="txtFacultyEmail" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblFacultyPassword" runat="server" Text="Faculty Password:"></asp:Label>
            <asp:TextBox ID="txtFacultyPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnHire" runat="server" Text="Hire" OnClick="btnHire_Click" />
        </div>
          </div>
    </form>
</body>
</html>
