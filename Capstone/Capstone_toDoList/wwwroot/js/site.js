const modal = document.getElementById("addTaskModal");
const btn = document.getElementById("addTaskBtn");
const span = document.getElementsByClassName("close")[0];

btn.onclick = () => modal.style.display = "flex";
span.onclick = () => modal.style.display = "none";
window.onclick = (event) => { if (event.target == modal) modal.style.display = "none"; }