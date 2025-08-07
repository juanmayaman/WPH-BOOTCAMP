const resultDisplay = document.getElementById("result");
const historyDisplay = document.getElementById("historyNum");

let expression = "";
let hasError = false;

function updateDisplay() {
  resultDisplay.textContent = expression || "0";
}

function showError(message) {
  resultDisplay.textContent = message;
  historyDisplay.textContent = expression || "";
  expression = "";
  hasError = true;
}

function clearDisplay() {
  expression = "";
  resultDisplay.textContent = "0";
  historyDisplay.textContent = "";
  hasError = false;
}

function handleInput(input) {
  if (hasError) clearDisplay();

  try {
    const lastChar = expression.slice(-1);

    let displayInput = input;
    if (input === "*") displayInput = "×";
    if (input === "/") displayInput = "÷";
    if (input === "-") displayInput = "−";
    if (input === "sqrt") displayInput = "√";

    if ("+-×÷%^".includes(lastChar) && "+×÷%^".includes(displayInput)) {
      throw new Error("Cannot have two operators in a row");
    }

    if (expression === "" && "+×÷%^".includes(displayInput)) {
      throw new Error("Expression cannot start with an operator");
    }

    if (displayInput === ".") {
      const currentNumberMatch = expression.match(/[\d.]*$/);
      if (currentNumberMatch && currentNumberMatch[0].includes(".")) {
        throw new Error("Number already contains a decimal point");
      }
      if (expression === "" || "+-×÷%^(".includes(lastChar)) {
        expression += "0.";
        updateDisplay();
        return;
      }
    }

    if (displayInput === "√") {
      if (expression !== "" && (/[\d)]/.test(lastChar))) {
        expression += "×√(";
      } else {
        expression += "√(";
      }
    } else {
      if (displayInput === "(" && expression !== "" && (/[\d)]/.test(lastChar))) {
        expression += "×(";
      } else {
        expression += displayInput;
      }
    }

    updateDisplay();
  } catch (error) {
    showError(error.message);
  }
}

function calculateResult() {
  try {
    if (!expression) return;

    // Save the original expression before any mutation
    const originalExpression = expression;

    let evalExpr = expression
      .replace(/×/g, "*")
      .replace(/÷/g, "/")
      .replace(/−/g, "-")
      .replace(/√\(/g, "Math.sqrt(")
      .replace(/\^/g, "**");

    // Auto-close unmatched parentheses
    const openParens = (evalExpr.match(/\(/g) || []).length;
    const closeParens = (evalExpr.match(/\)/g) || []).length;
    evalExpr += ")".repeat(openParens - closeParens);

    // Handle percentage
    evalExpr = evalExpr.replace(/(\d+(\.\d+)?)%(?![\d(])/g, "($1/100)");

    // Prevent divide by zero
    if (/\/\s*0(?![\d.])/.test(evalExpr)) {
      throw new Error("Cannot divide by zero");
    }

    // Validate square roots of negative numbers
    const sqrtMatches = evalExpr.match(/Math\.sqrt\(([^()]+)\)/g);
    if (sqrtMatches) {
      for (const match of sqrtMatches) {
        const innerExpr = match.match(/Math\.sqrt\(([^()]+)\)/)[1];
        try {
          const innerValue = Function('"use strict";return (' + innerExpr + ')')();
          if (typeof innerValue !== "number" || isNaN(innerValue)) {
            throw new Error("Invalid value inside square root");
          }
          if (innerValue < 0) {
            throw new Error("Cannot calculate square root of a negative number");
          }
        } catch (e) {
          throw new Error("Cannot calculate square root of a negative number");
        }
      }
    }

    const result = eval(evalExpr);

    if (!isFinite(result)) {
      throw new Error("Result is too large or too small to display");
    }

    if (isNaN(result)) {
      throw new Error("Invalid mathematical operation");
    }

    // Display history correctly using saved original expression
    historyDisplay.textContent = originalExpression;
    expression = result.toString();
    hasError = false;
    updateDisplay();
  } catch (error) {
    if (error.message.includes("Cannot calculate square root of a negative number")) {
      showError("Cannot calculate square root of a negative number");
    } else if (error.message.includes("Cannot divide by zero")) {
      showError("Cannot divide by zero");
    } else if (error.message.includes("Result is too large")) {
      showError("Result is too large or too small to display");
    } else if (error.message.includes("Invalid mathematical operation")) {
      showError("Invalid mathematical operation");
    } else if (error.message.includes("Unexpected token")) {
      showError("Invalid expression format");
    } else if (error.message.includes("SyntaxError")) {
      showError("Invalid expression syntax");
    } else {
      showError("Calculation error - please check your input");
    }
  }
}

// Button Event Listeners
document.querySelectorAll(".number").forEach(btn => {
  btn.addEventListener("click", () => handleInput(btn.dataset.num));
});

document.querySelectorAll(".operator").forEach(btn => {
  btn.addEventListener("click", () => handleInput(btn.dataset.op));
});

document.querySelector(".clear").addEventListener("click", () => {
  if (hasError || expression === "") {
    clearDisplay();
  } else {
    if (expression.endsWith("√(")) {
      expression = expression.slice(0, -2);
    } else {
      expression = expression.slice(0, -1);
    }
    updateDisplay();
  }
});

document.querySelector(".equals").addEventListener("click", calculateResult);

// Keyboard Support
document.addEventListener("keydown", (e) => {
  const key = e.key;

  if (hasError && !["Escape", "Backspace", "Delete"].includes(key)) {
    clearDisplay();
  }

  if (/\d/.test(key) || key === ".") {
    handleInput(key);
  } else if (["+"].includes(key)) {
    handleInput(key);
  } else if (key === "-") {
    handleInput("−");
  } else if (key === "*") {
    handleInput("×");
  } else if (key === "/") {
    e.preventDefault();
    handleInput("÷");
  } else if (key === "%") {
    handleInput("%");
  } else if (key === "^") {
    handleInput("^");
  } else if (key === "(" || key === ")") {
    handleInput(key);
  } else if (key === "Enter") {
    e.preventDefault();
    calculateResult();
  } else if (key === "Escape" || key === "Delete") {
    clearDisplay();
  } else if (key === "Backspace") {
    if (expression.endsWith("√(")) {
      expression = expression.slice(0, -2);
    } else {
      expression = expression.slice(0, -1);
    }
    updateDisplay();
  } else if (key.toLowerCase() === "r") {
    handleInput("sqrt");
  }
});
