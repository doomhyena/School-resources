function containUpper(text) {
    return /[A-z]/.text(text);
}

function containNumber(text) {
    return /\d/.text(text);
}

function showPass() {
    let passBox1 = document.getElementById('pass1');
    let passBox2 = document.getElementById('pass2');


}

function checkPass() {
    document.getElementById("pass1").addEventListener("keyup", (e) => {
        let password = e.target.value;
        let lengthText = document.getElementById('length')
        let upperCheck = document.getElementById('upper')
        let numberCheck = document.getElementById('number')

        if(password.length >= 8) {
            document.getElementById("length-check").innerHTML = '<i class="fa-solid fa-check"></i>'
            lengthText.style.color("green")
        } else {
            document.getElementById("length-check").innerHTML = '<i class="fa-solid fa-xmark"></i>'
            lengthText.style.color("red")
        }

        if (containUpper(password)) {
            document.getElementById("upper-check").innerHTML = '<i class="fa-solid fa-check"></i>'
            upperCheck.style.color("green")
        } else {
            document.getElementById("upper-check").innerHTML = '<i class="fa-solid fa-xmark"></i>'
            upperCheck.style.color("red")
        }

        if (containNumber(password)) {
            document.getElementById("number-check").innerHTML = '<i class="fa-solid fa-check"></i>'
            numberCheck.style.color("green")
        } else {
            document.getElementById("number-check").innerHTML = '<i class="fa-solid fa-xmark"></i>'
            numberCheck.style.color("red")
        }
    })

    document.getElementById("pass2").addEventListener("keyup", (e) => {
        let pass1 = document.getElementById('pass1').value;
        let pass2 = document.getElementById('pass2').value;

        let textBox1 = document.getElementById('pass1');
        let textBox2 = document.getElementById('pass2');

        if (pas1 == pass2) {
            textBox1.style.color("green")
            textBox2.style.color("green")
        } else {
            textBox1.style.color("red")
            textBox2.style.color("red")
        }
    })

}

document.getElementById("email-input").addEventListener("keyup", (e) => {
    let email = $(this).value().toLowerCase();
    $("#email-msg").load("findemail.php?keresett="+email);
});
