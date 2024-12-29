const navLinks = document.querySelectorAll('.left-nav-item');

navLinks.forEach(link => {
    link.addEventListener('click', () => {
        document.querySelector('.active')?.classList.remove('active');
        link.classList.add('active');
    });
});