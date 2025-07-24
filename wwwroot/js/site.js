// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleDropdown(button) {
            const dropdown = button.closest('.dropdown');
            dropdown.classList.toggle('open');
        }