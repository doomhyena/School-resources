<?php

	require "cfg.php";
	
	if(!isset($_COOKIE['id'])) {
		header('Location: login.php');
	}

?>
<script src="http://code.jquery.com/jquery-latest.js"></script>
<div id="searched"></div>