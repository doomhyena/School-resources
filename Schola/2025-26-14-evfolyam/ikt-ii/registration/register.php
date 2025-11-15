<!DOCTYPE html>
<html lang='en'>
   <head>
       <title>Register</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
       <script src="http://code.jquery.com/jquery-latest.js"></script>
       <script src="https://kit.fontawesome.com/086e7cefb3.js" crossorigin="anonymous"></script>
   </head>
   <body>
    <h1>Register</h1>
    <form>
        <label id="email-msg"></label>
        <input type="email" name="email" placeholder="Email" id="email-input" required><br><br>
        <input type="text" name="username" placeholder="Felhasználónév" required><br><br>
        <label id="length"><span id="length-check"></span> A jelszó legyen minumum 8 karakter hosszú!</label>
        <br><br>
        <label id="upper"><span id="upper-check"></span> Tartalmazzon minumum egy nagy betűt!</label>
        <br><br>
        <label id="num"><span id="num-check"></span> Tartalmazzon minumum egy számot!</label>
        <input type="password" name="pass1" id="pass1" placeholder="Jelszó" required>
        
        <br><br>
        <input type="checkbox" onchange="showpass">
        <br><br>
        
        <input type="password" name="pass2" id="pass2" placeholder="Jelszó Mégegyszer" required><br><br>
        <input type="button" value="Register"><br><br>
    </form>
   </body>
   <script src="assets/js/script.js"></script>
</html>