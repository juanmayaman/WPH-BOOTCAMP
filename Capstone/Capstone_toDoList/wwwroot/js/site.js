const modal = document.getElementById("addTaskModal");
const btn = document.getElementById("addTaskBtn");
const closeButtons = document.getElementsByClassName("close");

btn.onclick = () => modal.style.display = "flex";

// Close when clicking any button with class "close" (X or Cancel)
for (let i = 0; i < closeButtons.length; i++) {
    closeButtons[i].onclick = () => modal.style.display = "none";
}

// Close if clicking outside the modal
window.onclick = (event) => {
    if (event.target == modal) modal.style.display = "none";
}