// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleDropdown(button) {
            const dropdown = button.closest('.dropdown');
            dropdown.classList.toggle('open');
        }


document.addEventListener("DOMContentLoaded", function() {  //Aumentar foto do usuário.

        // Seleciona os elementos que vamos usar
        const avatarTrigger = document.getElementById('user-avatar-trigger');
        const imageModalElement = document.getElementById('image-viewer-modal');

        // Garante que o código só rode se os elementos existirem na página
        if (avatarTrigger && imageModalElement) {
            
            const modalImageContent = document.getElementById('modal-image-content');
            const imageModal = new bootstrap.Modal(imageModalElement);

            // Adiciona o "ouvinte" de clique no avatar
            avatarTrigger.addEventListener('click', function() {
                
                // Pega o caminho (src) da imagem do avatar que foi clicada
                const imageUrl = this.src;

                // Define o caminho da imagem grande dentro do modal
                modalImageContent.src = imageUrl;

                // Mostra o modal
                imageModal.show();
            });
        }
});
        