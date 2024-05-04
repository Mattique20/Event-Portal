﻿
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Fast Event Portal</title>
    <link href="../CSS/Home.css" rel="stylesheet" />
    
</head>
<body>
  <form id="form1" runat="server">
    <header>
      <img src="../Images/logo.png" alt="FAST Logo" class="header-logo">  
        <h1>Fast Event Portal</h1>
      <nav>  
        <asp:Button ID="btnLogin" runat="server" Text="Login" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" />
      </nav>
    </header>

    <div class="container">
      <div class="div fade-up featured-div">
        <h2 class="animated-text">About Fast</h2>
        <p class="text-content" aria-dropeffect="move">FAST University is renowned for its vibrant campus life, academic excellence, and exciting opportunities. Discover a dynamic learning environment where students thrive, supported by modern facilities and expert faculty. Explore a wide range of academic programs and engage in innovative research and projects. Join a community committed to shaping future leaders and innovators in technology and business.</p>  
        <img src="../Images/Background.jpg" alt="FAST" class="featured-image">
      </div>
    </div>

    <div class="event-content">  
      <div class="event-div fade-up">
        <h2>Upcoming Events</h2>
        <p style="width: 540px; font-family: Arial; font-size: large; font-weight: 100; color: #021B6D; height: 234px; margin-left: 44px; margin-top: 60px;">Explore a world of exciting activities at FAST University. From workshops to cultural festivals, find events that ignite your passions. Connect with peers and industry experts, and dive into immersive experiences that enrich your journey. Stay updated on upcoming events and join us in creating memorable moments together. Discover, connect, and grow with FAST University&#39;s vibrant Events Exploration!</p>
                
        <div class="event-card-container"></div>
                
        <div class="event-slider">
          <asp:Button ID="btnPrev" runat="server" CssClass="prev-button" />
          <asp:Button ID="btnNext" runat="server" CssClass="next-button" />
          <asp:Button ID="btnExplore" runat="server" CssClass="explore-button" Text="Explore Events" />
        </div>
      </div>
    </div>
    
    <div class="div-reverse fade-up" style="color: #000000">
      <h2>About Us</h2>
      <p>Learn more about our mission and team.</p>
      <asp:HyperLink ID="lnkReadMore" runat="server" NavigateUrl="#">Read More</asp:HyperLink>
    </div>

    <script src="../CSS/Scripts.js"></script>
  </form>
</body>
</html>
