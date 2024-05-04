<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organiser.aspx.cs" Inherits="SE.Organiser" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Event Organiser</title>
    <link href="../CSS/Organizer.css" rel="stylesheet" />
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
        
            <h1>Event Organiser</h1>
            <div class="dropdown-container">
                <label for="ddlEvents">Select Event Type:</label>
                <asp:DropDownList ID="ddlEvents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div id="blur">
                <h2>Events</h2>
                <asp:GridView ID="gvEvents" runat="server" >

                </asp:GridView>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Feedback" />
                <asp:TextBox ID="EventID" runat="server" placeholder="Enter EventID"></asp:TextBox>
                <asp:TextBox ID="EventTitle" runat="server" placeholder="Enter Title"></asp:TextBox>
                <asp:TextBox ID="EventDesc" runat="server" placeholder="Enter Description"></asp:TextBox>
                <asp:TextBox ID="Date" runat="server" placeholder="Enter Date"></asp:TextBox>
                <asp:TextBox ID="Time" runat="server" placeholder="Enter Time"></asp:TextBox>
                <asp:TextBox ID="venue" runat="server" placeholder="Enter Venue"></asp:TextBox>

                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>FSM</asp:ListItem>
                    <asp:ListItem>EE</asp:ListItem>
                    <asp:ListItem>CS</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="Category" runat="server" placeholder="Enter Category"></asp:TextBox>
                <asp:DropDownList ID="Registration" runat="server">
                    <asp:ListItem>Registeration Open</asp:ListItem>
                    <asp:ListItem>Registration Close</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="addevent" runat="server" OnClick="addevent_Click" Text="Add Event" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
                <asp:TextBox ID="DeleteEvent" runat="server"></asp:TextBox>
                <asp:Button ID="DelEvent" runat="server" OnClick="DelEvent_Click" Text="Delete Event" />
                <asp:TextBox ID="RegBox" runat="server"></asp:TextBox>
                <asp:Button ID="Close" runat="server" OnClick="Close_Click" Text="Close Registration" />
                <asp:Button ID="Open" runat="server" OnClick="Open_Click1" Text="Open Registration" />
            </div>

        </div>
    </form>
</body>
</html>
