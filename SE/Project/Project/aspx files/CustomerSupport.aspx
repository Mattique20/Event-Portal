<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSupport.aspx.cs" Inherits="SE.CustomerSupport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChatGPT Customer Support</title>
    <style>
        /* Styles for the chatbot interface */
        #chat-container {
            width: 300px;
            height: 400px;
            border: 1px solid #ccc;
            overflow-y: scroll;
            margin-bottom: 20px;
            padding: 10px;
            background-color: #f9f9f9;
        }

        #input-container {
            width: 100%;
        }

        #user-input {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            margin-top: 10px;
        }

        #send-button {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            margin-top: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="chat-container"></div>
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
