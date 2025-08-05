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

//script for the prime 4x4 grid
//eto function pang check kung prime number
function isPrime(n) {
    if (n < 2) return false;
    for (let i = 2; i <= Math.sqrt(n); i++) {
        if (n % i === 0) return false;
    }
    return true;
}
//eto function pang generate ng 4x4 grid ng prime numbers
function generatePrimeGrid() {
    const container = document.getElementById('primeGrid');
    container.innerHTML = ""; // clear existing grid

    let count = 0;
    let num = 2;

    while (count < 16) {
        if (isPrime(num)) {
            const box = document.createElement('div');
            box.className = 'grid-item';
            box.textContent = num;
            container.appendChild(box);
            count++;
        }
        num++;
    }
}

// Function to handle the button click in lists
function generateMultiples() {
  const list = document.getElementById('multiplesList');
  list.innerHTML = ""; 

  //loloop lang 1 - 10 kase first 10 multiples lang naman of 3
  for (let i = 1; i <= 10; i++) {
    const li = document.createElement('li');
    li.textContent = `${i * 3}`; 
    list.appendChild(li);//lalagay lang content
  }
}

function generateDivisibleByFive() {
  const list = document.getElementById('divisiblesList');
  list.innerHTML = ""; 
  let count = 0;
  for (let i = 100; i >= 1 && count < 10; i--) {//dahil last 10 daw so start sa 100
    if (i % 5 === 0) {
      const li = document.createElement('li');
      li.textContent = i;
      list.appendChild(li);
      count++;
    }
  }
}