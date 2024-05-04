<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="SE.FAQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAQ - Fast University Islamabad Events</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
            margin-top: 50px;
        }
        h1 {
            text-align: center;
            color: #333;
        }
        .faq-item {
            border-bottom: 1px solid #eee;
            padding: 20px 0;
        }
        .question {
            font-size: 18px;
            font-weight: bold;
            color: #333;
        }
        .answer {
            margin-top: 10px;
            color: #666;
        }
        .go-back {
            text-align: center;
            margin-top: 20px;
        }
        .go-back button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }
        .go-back button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Frequently Asked Questions</h1>
            <div class="faq-item">
                <div class="question">What events are happening at Fast University Islamabad?</div>
                <div class="answer">You can find a variety of events including workshops, seminars, cultural festivals, academic conferences, and more. Check our event calendar for upcoming events.</div>
            </div>
            <div class="faq-item">
                <div class="question">How can I register for an event?</div>
                <div class="answer">Registration for events can be done through our online portal. Simply navigate to the event page and follow the registration instructions provided.</div>
            </div>
            <div class="faq-item">
                <div class="question">Are there any fees for attending events?</div>
                <div class="answer">The majority of our events are free to attend. However, some special events or workshops may have a registration fee. This will be clearly mentioned on the event page.</div>
            </div>
            <div class="faq-item">
                <div class="question">Can I submit my own event?</div>
                <div class="answer">Yes, we welcome event submissions from students, faculty, and external organizations. Please contact our event management team for guidelines on submitting your event.</div>
            </div>
            <!-- Add more FAQ items as needed -->
            <div class="go-back">
                <a href="Home.aspx"><button>Go back</button></a>
            </div>
        </div>
    </form>
</body>
</html>
