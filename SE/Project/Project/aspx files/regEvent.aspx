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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="pageTitle" runat="server"></h1>
            <asp:Button ID="btnConfirmRegistration" runat="server" Text="Confirm Registration" OnClick="btnConfirmRegistration_Click" Style="display: none;" />
        </div>
    </form>
</body>
</html>
