<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEvent.aspx.cs" Inherits="SE.StudentEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/StudentEvent.css" rel="stylesheet" />
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
            <header>
             <img src="../Images/logo.png" alt="FAST Logo" class="header-logo">  
             <h1>Fast Event Portal</h1>
             <nav>  
             <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin" Text="Login" OnClick="btnLogin_Click" />
              <asp:Button ID="btnhome" runat="server" CssClass="btnhome" Text="Home" onClick="btnhome_Click"/>
             </nav>
         </header>
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
                
                
                <button type="button" onclick="viewRegisteredEvents()">Registered</button>
                <button type="button" onclick="viewBookmarkedEvents()">Bookmarks</button>
            </div>
            
            <!-- Event Cards -->
            <div class="event-cards" id="eventContainer" runat="server">
                <!-- Events will be dynamically added here -->
            </div>
        </div>
    </form>
</body>
</html>
