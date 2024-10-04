const toggleModeButton = document.getElementById('toggle-mode');
toggleModeButton.addEventListener('click', () => {
    document.body.classList.toggle('dark-mode');
    const icon = document.getElementById('icon');
    icon.classList.toggle('fa-sun');
    icon.classList.toggle('fa-moon');
});
