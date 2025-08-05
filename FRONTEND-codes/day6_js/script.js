// Age Checker Script
function checkAge() {
    const input = document.getElementById('ageInput').value.trim();
    const age = parseFloat(input);

    if (input === "" || isNaN(age)) {
        alert("Enter valid number or input!");
        return; 
    }

    if (age >= 18) {
        alert("You are legally an adult!");
    } else if (age >= 13 && age < 18) {
        alert("You are a teenager.");
    } else if (age >= 2 && age < 13) {
        alert("You are a child.");
    } else if (age <= 1) {
        alert("Invalid age input.");
    }
}
// Number Checker if odd or even
function checkEvenOdd() {
    const input = document.getElementById('numberInput').value.trim();
    const number = parseFloat(input);
    //checker if empty or di number
    if (input === "" || isNaN(number)) {
        alert("That is not a valid number!");
        return;
    }
    if (number % 2 === 0) {
        alert("The number is even.");
    } else {
        alert("The number is odd.");
    }
}