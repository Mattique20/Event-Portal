const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate__animated', 'animate__fadeUp');
        }
    });
});

document.querySelectorAll('.fade-up').forEach(el => observer.observe(el));
