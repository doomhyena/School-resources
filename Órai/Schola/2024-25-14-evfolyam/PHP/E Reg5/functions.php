<?php 
	
	function Message($text){
		echo "<script>alert('$text')</script>";
	}
	
	function CodeGenerator(){
		
		$karakterek = array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
		
		$code = "";
		
		for($i=0;$i<5;$i++){
			
			$code .= $karakterek[rand(0, count($karakterek)-1)];
			
		}
		
		return $code;
		
	}
	
	function CodeChecker(){
		
		$conn = new mysqli("localhost", "root", "", "schola_14a_reg5");
		
		$code = CodeGenerator();

		while(mysqli_num_rows($conn->query("SELECT * FROM codes WHERE code='$code'")) == 1){
			
			$code = CodeGenerator();
			
		}
		
		return $code;
		
	}  

?>