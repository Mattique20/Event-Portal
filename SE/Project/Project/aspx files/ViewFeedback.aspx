<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="SE.ViewFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Search Section -->
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <br /><br />
            
            <!-- Feedback Grid -->
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="EventTitle" HeaderText="Event Title" />
                    <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                    <asp:BoundField DataField="Time" HeaderText="Time" />
                </Columns>
            </asp:GridView>
            
            <!-- Go Back Button -->
            <asp:Button ID="btnGoBack" runat="server" Text="Go Back" OnClick="btnGoBack_Click" />
        </div>
    </form>
</body>
</html>
