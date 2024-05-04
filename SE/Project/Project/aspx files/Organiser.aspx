<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organiser.aspx.cs" Inherits="SE.Organiser" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Event Organiser</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
            color: #333;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            border-radius: 10px;
            background-color: #fff;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }
        h1, h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        label {
            display: block;
            font-size: 18px;
            margin-bottom: 10px;
        }
        select, input[type="text"] {
            width: 100%;
            padding: 12px;
            font-size: 16px;
            border: 2px solid #ccc;
            border-radius: 8px;
            background-color: #f9f9f9;
            margin-bottom: 10px;
            transition: border-color 0.3s ease;
            box-sizing: border-box;
        }
        select:focus, input[type="text"]:focus {
            outline: none;
            border-color: #6c5ce7;
        }
        input[type="text"]::placeholder {
            color: #999;
        }
        select option {
            padding: 8px;
            font-size: 16px;
        }
        button {
            display: block;
            width: 100%;
            padding: 12px;
            font-size: 18px;
            color: #fff;
            background-color: #6c5ce7;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        button:hover {
            background-color: #4834d4;
        }
        .dropdown-container {
            text-align: center;
            margin-top: 20px;
        }
        .dropdown-container select {
            padding: 10px;
            font-size: 16px;
            width: 100%;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #fff;
            cursor: pointer;
        }
        /* CSS class for input text boxes with text only in background */
.text-background {
    color: transparent; /* Make text transparent */
    background-color: #f9f9f9; /* Background color */
    border: 2px solid #ccc;
    border-radius: 8px;
    padding: 12px;
    font-size: 16px;
    margin-bottom: 10px;
    transition: border-color 0.3s ease;
    box-sizing: border-box;
}

.text-background::placeholder {
    color: #999; /* Placeholder color */
}


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Event Organiser</h1>
            <div class="dropdown-container">
                <label for="ddlEvents">Select Event Type:</label>
                <asp:DropDownList ID="ddlEvents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div>
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
