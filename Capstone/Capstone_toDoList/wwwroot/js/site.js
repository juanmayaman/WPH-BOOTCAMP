// ADD TASK MODAL
const addModal = document.getElementById("addTaskModal");
const addBtn = document.getElementById("addTaskBtn");
const addCloseButtons = addModal.getElementsByClassName("close");

addBtn.onclick = () => addModal.style.display = "flex";

// Close Add Task modal when clicking any close button inside it
for (let i = 0; i < addCloseButtons.length; i++) {
    addCloseButtons[i].onclick = () => addModal.style.display = "none";
}

// EDIT TASK MODAL
const editModal = document.getElementById("editTaskModal");
const editClose = document.getElementById("editModalClose");
const editCancel = document.getElementById("editCancel");
const editBtns = document.querySelectorAll(".editBtn");

editBtns.forEach(btn => {
    btn.onclick = () => {
        document.getElementById("editTaskId").value = btn.dataset.id;
        document.getElementById("editTitle").value = btn.dataset.title;
        document.getElementById("editDescription").value = btn.dataset.description;
        document.getElementById("editCategory").value = btn.dataset.category;
        document.getElementById("editDueDate").value = btn.dataset.duedate;
        document.getElementById("editAssignedTo").value = btn.dataset.assigned;

        editModal.style.display = "flex";
    };
});

// Close Edit Task modal when clicking X or Cancel
editClose.onclick = editCancel.onclick = () => editModal.style.display = "none";

// Close modal when clicking outside (works for both Add and Edit)
window.onclick = (event) => {
    if (event.target == addModal) addModal.style.display = "none";
    if (event.target == editModal) editModal.style.display = "none";
};