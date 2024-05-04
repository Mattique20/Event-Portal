<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSupport.aspx.cs" Inherits="SE.CustomerSupport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChatGPT Customer Support</title>
   <link href="../CSS/chat.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <header>
      <img src="../Images/logo.png" alt="FAST Logo" class="header-logo">  
        <h1>Fast Event Portal</h1>
      <nav>  
        <asp:Button ID="btnHome" runat="server" Text="Home" />
        <asp:Button ID="btnevents" runat="server" Text="Events" />
      </nav>
    </header>
        <h1 style="text-align: center;">ChatGPT Customer Support</h1>
        <div>
            
            <div id="chat-container">
                

            </div>
            <div id="input-container">
                <input type="text" id="user-input" placeholder="Type your message here..." />
                <button type="button" id="send-button">Send</button>
            </div>
        </div>
    </form>

    <script>
        // Function to append messages to the chat container
        function appendMessage(message, sender) {
            var chatContainer = document.getElementById('chat-container');
            var messageElement = document.createElement('div');
            messageElement.innerHTML = '<strong>' + sender + ':</strong> ' + message;
            chatContainer.appendChild(messageElement);
            chatContainer.scrollTop = chatContainer.scrollHeight;
        }

        // Function to handle user input and send it to ChatGPT
        function sendMessage() {
            var userInput = document.getElementById('user-input').value;
            appendMessage(userInput, 'You');
            document.getElementById('user-input').value = ''; // Clear the input field

            // Send the user input to ChatGPT API
            fetch('/api/ChatGPT/Chat', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ message: userInput }),
            })
                .then(response => response.json())
                .then(data => {
                    appendMessage(data.message, 'ChatGPT');
                })
                .catch((error) => {
                    console.error('Error:', error);
                });
        }

        // Event listener for the send button
        document.getElementById('send-button').addEventListener('click', function () {
            sendMessage();
        });

        // Event listener for pressing Enter key
        document.getElementById('user-input').addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                sendMessage();
            }
        });
    </script>
</body>
</html>
