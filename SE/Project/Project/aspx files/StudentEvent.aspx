<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEvent.aspx.cs" Inherits="SE.StudentEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">
        // JavaScript function to filter events by department
        function filterByDepartment() {
            var department = document.getElementById('department').value;
            var cards = document.getElementsByClassName('card');

            for (var i = 0; i < cards.length; i++) {
                var card = cards[i];
                var cardDepartment = card.getAttribute('data-department');

                if (department === 'all' || cardDepartment === department) {
                    card.style.display = 'block';
                } else {
                    card.style.display = 'none';
                }
            }
        }

        // JavaScript function to search events
        function search() {
            var input = document.getElementById('searchInput').value.toLowerCase();
            var cards = document.getElementsByClassName('card');

            for (var i = 0; i < cards.length; i++) {
                var card = cards[i];
                var cardContent = card.innerText.toLowerCase();

                if (cardContent.includes(input)) {
                    card.style.display = 'block';
                } else {
                    card.style.display = 'none';
                }
            }
        }

        function addRegisterButtonToCards() {
            var cards = document.getElementsByClassName('card');

            for (var i = 0; i < cards.length; i++) {
                var card = cards[i];
                var button = document.createElement('button');
                button.innerHTML = 'Register';
                button.type = 'button';

                // Get the name of the card
                var cardName = card.querySelector('h3').innerText;

                // Set the card name as a data attribute
                button.setAttribute('data-card-name', cardName);

                button.onclick = function () {
                    // Retrieve the card name when the button is clicked
                    var cardName = this.getAttribute('data-card-name');
                    // Redirect to regEvent.aspx with the card title as a query parameter
                    window.location.href = 'regEvent.aspx?title=' + encodeURIComponent(cardName);
                };
                card.appendChild(button);
            }
        }

        
        function addBookmarkButtonToCards() {
            var cards = document.getElementsByClassName('card');

            for (var i = 0; i < cards.length; i++) {
                var card = cards[i];
                var button = document.createElement('button');
                button.innerHTML = 'Bookmark';
                button.type = 'button';

                // Get the name of the card
                var cardName = card.querySelector('h3').innerText;

                // Check if the card is already bookmarked
                if (isBookmarked(cardName)) {
                    button.innerHTML = 'Remove Bookmark';
                }

                // Set the card name as a data attribute
                button.setAttribute('data-card-name', cardName);

                button.onclick = function () {
                    // Retrieve the card name when the button is clicked
                    var cardName = this.getAttribute('data-card-name');
                    // Toggle bookmark status
                    toggleBookmarkStatus(cardName, this);
                };
                card.appendChild(button);
            }
        }

        function isBookmarked(cardName) {
            // Check if the item is bookmarked (you would implement this logic)
            // For demonstration, let's say we check a localStorage variable
            return localStorage.getItem(cardName) !== null;
        }

        function toggleBookmarkStatus(cardName, button) {
            if (isBookmarked(cardName)) {
                // Remove bookmark
                removeBookmark(cardName);
                button.innerHTML = 'Bookmark';
            } else {
                // Add bookmark
                addBookmark(cardName);
                button.innerHTML = 'Remove Bookmark';
            }
        }

        function addBookmark(cardName) {
            // Implement bookmark adding logic (e.g., store in localStorage)
            localStorage.setItem(cardName, 'bookmarked');
        }

        function removeBookmark(cardName) {
            // Implement bookmark removal logic (e.g., remove from localStorage)
            localStorage.removeItem(cardName);
        }








        // Call the function when the page loads
        window.onload = function () {
            addRegisterButtonToCards();
            addBookmarkButtonToCards();
        };

        function viewRegisteredEvents() {
            window.location.href = "RegisteredEvents.aspx";
        }

        function viewBookmarkedEvents() {
            window.location.href = "BookmarkedEvents.aspx";
        }

        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Filter Dropdown -->
            <div class="filter-section">
                <label for="department">Department:</label>
                <select id="department" onchange="filterByDepartment()">
                    <option value="all">All Departments</option>
                    <option value="EE">EE</option>
                    <option value="FSM">FSM</option>
                    <option value="CS">CS</option>
                </select>
                
                <!-- Search Bar -->
                <input type="text" id="searchInput" placeholder="Search...">
                <button type="button" onclick="search()">Search</button>
                
                
                <button type="button" onclick="viewRegisteredEvents()">View Registered Events</button>
                <button type="button" onclick="viewBookmarkedEvents()">View Bookmarked Events</button>
            </div>
            
            <!-- Event Cards -->
            <div class="event-cards" id="eventContainer" runat="server">
                <!-- Events will be dynamically added here -->
            </div>
        </div>
    </form>
</body>
</html>
