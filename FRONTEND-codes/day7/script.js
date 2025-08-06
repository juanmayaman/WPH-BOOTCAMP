function checkPrime() {
    const input = document.getElementById('numInput').value.trim();
    const num = parseFloat(input);

    if (isNaN(num)) {
        alert("Please enter a valid number.");
        return;
    }

    if (num <= 1) {
        alert("Number must be greater than 1");
        return;
    }

    if (num === 2) {
        alert("Number is PRIME!");
        return;
    }

    if (num % 2 === 0) {
        alert("Number is NOT PRIME!");
        return;
    }
    //checheck muna if may sqrt yung number,, skip even nums since di sila prime
    //chechck lang gang sqrt if may factor ba siya na divisible pag meron edi not prime
    const sqrt = Math.sqrt(num);
    for (let i = 3; i <= sqrt; i += 2) {
        if (num % i === 0) {
            alert("Number is NOT PRIME!");
            return;
        }
    }

    // If no divisor found
    alert("Number is PRIME!");
}