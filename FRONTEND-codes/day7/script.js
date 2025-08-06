function checkPrime() {
    const input = document.getElementById('numInput').value.trim();
    const resultBox = document.getElementById('primeResult');

    // Validate input
    if (input === "" || isNaN(input)) {
        resultBox.textContent = "Please enter a valid number.";
        resultBox.style.color = "#FF4081";
        return;
    }

    const num = parseInt(input);

    if (num <= 1) {
        resultBox.textContent = "Number must be greater than 1.";
        resultBox.style.color = "#FF4081";
        return;
    }

    if (num === 2) {
        resultBox.textContent = "Number is PRIME!";
        resultBox.style.color = "#00C896";
        return;
    }

    if (num % 2 === 0) {
        resultBox.textContent = "Number is NOT PRIME!";
        resultBox.style.color = "#FF4081";
        return;
    }

    // Check divisibility up to square root of num
    const sqrt = Math.sqrt(num);
    for (let i = 3; i <= sqrt; i += 2) {
        if (num % i === 0) {
            resultBox.textContent = "Number is NOT PRIME!";
            resultBox.style.color = "#FF4081";
            return;
        }
    }

    // Prime if no factors found
    resultBox.textContent = "Number is PRIME!";
    resultBox.style.color = "#00C896";
}

function checkSqrt() {
    const input = document.getElementById("sqrtInput").value;
    const resultBox = document.getElementById("sqrtResult");

    if (input === "" || isNaN(input)) {
        resultBox.textContent = "Please enter a valid number.";
        resultBox.style.color = "#FF4081";
    } else if (input < 0) {
        resultBox.textContent = "Cannot calculate square root of a negative number.";
        resultBox.style.color = "#FF4081";
    } else {
        const sqrt = Math.sqrt(parseFloat(input)).toFixed(2);
        resultBox.textContent = `√${input} = ${sqrt}`;
        resultBox.style.color = "#00C896";
    }
}