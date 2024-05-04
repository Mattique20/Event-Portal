const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate__animated', 'animate__fadeUp');
        }
    });
});

document.querySelectorAll('.fade-up').forEach(el => observer.observe(el));

const eventCards = [
    { title: "Speed Programming", image: "D:\project\Event-Portal\SE\Project\Project\Images\app.jpg", description: "Speed programming competitions test coding skills under time pressure, evaluating correctness, efficiency, and speed across multiple rounds." },
    { title: "Event 2", image: "event_2.jpg", description: "This is the description for event 2." },
    { title: "Event 3", image: "event_3.jpg", description: "This is the description for event 3." },
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
