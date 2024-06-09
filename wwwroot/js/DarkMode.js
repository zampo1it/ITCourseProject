const themeToggle = document.getElementById('themeToggle');

document.getElementById("themeToggle").addEventListener("change", function () {
    var isChecked = this.checked;
    var theme = isChecked ? "dark" : "light";
    document.cookie = "theme=" + theme + "; path=/";
});

themeToggle.addEventListener('click', () => {
    document.body.classList.toggle('dark');
});

// Save the theme preference in local storage
themeToggle.addEventListener('click', () => {
    const isDarkMode = document.body.classList.contains('dark');
    localStorage.setItem('isDarkMode', isDarkMode);
});

// Load the theme preference from local storage
window.addEventListener('DOMContentLoaded', () => {
    const isDarkMode = localStorage.getItem('isDarkMode') === 'true';
    if (isDarkMode) {
        document.body.classList.add('dark');
    }
});