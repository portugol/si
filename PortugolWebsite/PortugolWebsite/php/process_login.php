<html>
<head><title>Portugol</title>
</head>
<meta property="fb:app_id" content="212500508799908">
<script async="" src="http://connect.facebook.net/en_US/all.js"></script>
<script type="text/javascript" src="sha512.js"></script>
<script type="text/javascript" src="forms.js"></script>
<link href="css/bootstrap-401cbb0c7673d09a5919d5288002542c.css" media="screen" rel="stylesheet" type="text/css">
<link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css">
<link href="css/application-ltr-a256b57024170c98ba019bc1c06cf31f.css" media="screen" rel="stylesheet" type="text/css">
<link href="css/application-ltr3-81daf122e1788730417e886545a44f59.css" media="screen" rel="stylesheet" type="text/css">
<body>
<?php
include 'db_connect.php';
include 'functions.php';
sec_session_start(); // Our custom secure way of starting a php session. 
 
if(isset($_POST['email'], $_POST['p'])) { 
   $email = $_POST['email'];
   $password = $_POST['p']; // The hashed password.
   if(login($email, $password, $mysqli) == true) {
      // Login success	  
      echo '<h4>Bem Vindo ao Portugol!</h4>';
   } else {
      // Login failed
      header('Location: ./login.php?error=1');
   }
} else { 
   // The correct POST variables were not sent to this page.
   echo 'Invalid Request';
}


?>
<div> <h3>Video Aulas</h3></div>
<a href="login.php"><input type="button" value="Logout" /></a> 
</body>
<html>