const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate__animated', 'animate__fadeUp');
        }
    });
});

document.querySelectorAll('.fade-up').forEach(el => observer.observe(el));
const eventCards = [
    // Replace with your actual event data (title, description, etc.)
    { title: "Event 1", description: "This is the description for event 1." },
    { title: "Event 2", description: "This is the description for event 2." },
    { title: "Event 3", description: "This is the description for event 3." },
];

const eventCardContainer = document.querySelector(".event-card-container");

eventCards.forEach((event) => {
    const card = document.createElement("div");
    card.classList.add("event-card");
    card.innerHTML = `<h3>${event.title}</h3><p>${event.description}</p>`;
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

