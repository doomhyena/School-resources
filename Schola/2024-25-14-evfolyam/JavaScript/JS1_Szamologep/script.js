"use strict";

var input = document.getElementById('input'),
  number = document.querySelectorAll('.n'),
  operator = document.querySelectorAll('.o'),
  result = document.getElementById('result'),
  clear = document.getElementById('clear'),
  resultDisplayed = false;

function number_handler(event) {
  var currentString = input.innerHTML;
  var lastChar = currentString[currentString.length - 1];

  if (resultDisplayed === false) {
    input.innerHTML += event.target.innerHTML;
  } else if (resultDisplayed === true && lastChar === "+" || lastChar === "-" || lastChar === "×" || lastChar === "÷") {
    resultDisplayed = false;
    input.innerHTML += event.target.innerHTML;
  } else {
    resultDisplayed = false;
    input.innerHTML = "";
    input.innerHTML += event.target.innerHTML;
  }

}
for (var i = 0; i < number.length; i++) {
  number[i].addEventListener("click",number_handler );
}

function operator_handler(event) {
  var currentString = input.innerHTML;
  var lastChar = currentString[currentString.length - 1];

  if (lastChar === "+" || lastChar === "-" || lastChar === "x" || lastChar === "÷") {
    var newString = currentString.substring(0, currentString.length - 1) + event.target.innerHTML;
    input.innerHTML = newString;
  } else if (currentString.length == 0) {
    console.log("adj meg egy szamot");
  } else {
    input.innerHTML += event.target.innerHTML;
  }

}
for (var i = 0; i < operator.length; i++) {
  operator[i].addEventListener("click",operator_handler );
}

function windows_handler(event){
  if (parseInt(event.key)<=9 || parseInt(event.key)>=0) {
  var currentString = input.innerHTML;
  var lastChar = currentString[currentString.length - 1];

  if (resultDisplayed === false) {
    input.innerHTML += parseInt(event.key);
  } else if (resultDisplayed === true && lastChar === "+" || lastChar === "-" || lastChar === "×" || lastChar === "÷") {
    resultDisplayed = false;
    input.innerHTML += parseInt(event.key);
  } else {
    resultDisplayed = false;
    input.innerHTML = "";
    input.innerHTML += parseInt(event.key);
  }
  }
  else if(event.key === "+" || event.key === "-" || event.key === "x" || event.key === "÷" || event.key === "/"  ||  event.key === "*" ){
  var currentString = input.innerHTML;
  var lastChar = currentString[currentString.length - 1];
  var s=event.key;
  if(s=="/"){
    s="÷"
  }
  if(s=="*"){
    s=document.querySelector('.multiply_sign').textContent;
  }
  if (lastChar === "+" || lastChar === "-" || lastChar === "x" || lastChar === "÷") {
    var newString = currentString.substring(0, currentString.length - 1) + s;
    input.innerHTML = newString;
  } else if (currentString.length == 0) {
    console.log("adj meg egy szamot");
  } else {
    input.innerHTML +=  s;
  }
  }
}
window.addEventListener("keypress",windows_handler);

function output(){

  var inputString = input.innerHTML;

  var numbers = inputString.split(/\+|\-|\×|\÷/g);

  var operators = inputString.replace(/[0-9]|\./g, "").split("");

  console.log(inputString);
  console.log(operators);
  console.log(numbers);
  console.log("----------------------------");

  var divide = operators.indexOf("÷");
  while (divide != -1) {
    numbers.splice(divide, 2, numbers[divide] / numbers[divide + 1]);
    operators.splice(divide, 1);
    divide = operators.indexOf("÷");
  }

  var multiply = operators.indexOf("×");
  while (multiply != -1) {
    numbers.splice(multiply, 2, numbers[multiply] * numbers[multiply + 1]);
    operators.splice(multiply, 1);
    multiply = operators.indexOf("×");
  }

  var subtract = operators.indexOf("-");
  while (subtract != -1) {
    numbers.splice(subtract, 2, numbers[subtract] - numbers[subtract + 1]);
    operators.splice(subtract, 1);
    subtract = operators.indexOf("-");
  }

  var add = operators.indexOf("+");
  while (add != -1) {
    numbers.splice(add, 2, parseFloat(numbers[add]) + parseFloat(numbers[add + 1]));
    operators.splice(add, 1);
    add = operators.indexOf("+");
  }

  input.innerHTML = numbers[0];

  resultDisplayed = true;
}
result.addEventListener("click",output );

clear.addEventListener("click", function() {
  input.innerHTML = "";
})

window.onkeydown = function(event){
  let key = event.key;
  if (key === "Backspace") {
    input.innerHTML = "";
  }
  else if(key==="Enter"){
    output()
  }
}
