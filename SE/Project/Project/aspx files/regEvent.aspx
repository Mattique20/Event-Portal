<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regEvent.aspx.cs" Inherits="No.regEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script>
      function confirmRegistration() {
          // You can add confirmation logic here if needed
          // For now, just submit the form
          document.getElementById('<%= btnConfirmRegistration.ClientID %>').click();
      }
  </script>
  <link href="../CSS/RegEvent.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <header>
      <img src="../Images/logo.png" alt="FAST Logo" class="header-logo">
      <h1>Fast Event Portal</h1>
      <nav>
        <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin" Text="Login" OnClick="btnLogin_Click" />
        <asp:Button ID="btnhome" runat="server" CssClass="btnhome" Text="Home" onClick="btnhome_Click" />
      </nav>
    </header>
    <div id="content" class="content"> <h1 id="pageTitle" runat="server"></h1>
      <asp:Button ID="btnConfirmRegistration" runat="server" Text="Confirm Registration" OnClick="btnConfirmRegistration_Click" Style="display: none;" />
    </div>
  </form>
</body>
</html>
