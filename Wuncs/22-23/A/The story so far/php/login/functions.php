<?php

function check_login($con)
{
	if (isset($_SESSION['user_ID']))
	{
		$id = $_SESSION['user_ID'];
		$query = "select * from user where user_ID='$id' limit 1";
		
		$result = mysqli_query($con,$query);
		if ($result && mysqli_num_rows($result) >0)
		{
			$user_data = mysqli_fetch_assoc($result);
			return $user_data;
		}
	}
	
	header("Location: login.php");
	die;
	
}

function rnd($length)
{
	$rn = "";
	if ($length<5)
	{
		$length = 5;
	}
	
	$len = rand(4,$length);
	
	for($i = 0; $i < $len; $i++)
	{
		$rn .= rand(0,9);
	}
	
	return $rn;
}