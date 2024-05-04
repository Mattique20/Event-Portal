const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate__animated', 'animate__fadeUp');
        }
    });
});

document.querySelectorAll('.fade-up').forEach(el => observer.observe(el));

const eventCards = [
    // Replace with your actual event data (title, description, image)
    {
        title: "Speed Programming",
        description: "Solve coding challenges under pressure, testing problem-solving, efficiency, and accuracy.",
        image: "../Images/speed.jpg" // Replace with your image path
    },
    {
        title: "Web Dev",
        description: "Design & build functional websites in a set time frame. Showcase creativity, UX, and technical skills to craft innovative user experiences.",
        image: "../Images/web.jpg" // Replace with your image path
    },
    {
        title: "App Dev",
        description: "Design & build apps in a set time frame. Showcase creativity, UX, and technical skills to craft innovative user experiences.",
        image: "../Images/app.jpg" // Replace with your image path (optional)
    },
    {
        title: "hackathon",
        description: "Code your way to glory at the [University Name] Hackathon!",
        image: "../Images/Hackathon.jpg" // Replace with your image path (optional)
    },
];

const eventCardContainer = document.querySelector(".event-card-container");

eventCards.forEach((event) => {
    const card = document.createElement("div");
    card.classList.add("event-card");
    card.innerHTML = `
    <div class="card-image">
      <img src="${event.image}" alt="${event.title}">
    </div>
    <div class="card-content">
      <h3>${event.title}</h3>
      <p>${event.description}</p>
    </div>
  `;
    eventCardContainer.appendChild(card);
});

// Add logic for button clicks to navigate the slider (example)
const prevButton = document.querySelector(".prev-button");
const nextButton = document.querySelector(".next-button");

prevButton.addEventListener("click", () => {
    eventCardContainer.scrollBy({ left: -250, behavior: "smooth" });
});

nextButton.addEventListener("click", () => {
    eventCardContainer.scrollBy({ left: 250, behavior: "smooth" });
});
