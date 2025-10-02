<?php
    
    require "config.php";
    if (isset($_COOKIE['id'])) {
        $sql = "SELECT * FROM felhasznalok WHERE id = " . intval($_COOKIE['id']);
        $result = $conn->query($sql);
        $user = $result->fetch_assoc();
    } else {
        $user = ['id' => 0];
    }
    echo '
        <nav>
            <a href="index.php">Főoldal</a>
            <a href="felhasznalo.php?userid=' . $user['id'] . '">Profilom</a>
            <a href="rendezvény_letrehozasa.php">Rendezvény létrehozása</a>
            <a href="kosar.php">Kosár</a>
            <a href="logout.php">Kijelentkezés</a>
        </nav>
    ';