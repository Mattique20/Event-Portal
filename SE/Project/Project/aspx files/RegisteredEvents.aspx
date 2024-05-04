<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisteredEvents.aspx.cs" Inherits="SE.RegisteredEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registered Events</title>
    <style>
        /* CSS for card layout */
        .card {
            background-color: #fff;
            border: 1px solid #eaeaea;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
            width: calc(33.33% - 20px);
            padding: 20px;
            box-sizing: border-box;
        }

        .card h3 {
            margin-top: 0;
            font-size: 18px;
            color: #333;
        }

        .card p {
            margin: 10px 0;
            font-size: 14px;
            color: #666;
        }

        body {
            font-family: Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .filter-section {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 20px;
        }

        .filter-section label {
            margin-right: 10px;
        }

        .filter-section select,
        .filter-section input[type="date"],
        .filter-section input[type="text"],
        .filter-section button {
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 14px;
        }

        .filter-section button {
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            border: none;
        }

        .filter-section button:hover {
            background-color: #0056b3;
        }

        .event-cards {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Event Cards -->
            <div class="event-cards" id="eventContainer" runat="server">
                <!-- Events will be dynamically added here -->
            </div>
            <!-- Go back button -->
            <button type="button" onclick="window.location.href='StudentEvent.aspx'">Go Back</button>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </form>

</body>
</html>
