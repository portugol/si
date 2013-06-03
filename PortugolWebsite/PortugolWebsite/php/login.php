<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Login Portugol</title>
    <meta property="fb:app_id" content="212500508799908">
    <script async="" src="http://connect.facebook.net/en_US/all.js"></script>
	<script type="text/javascript" src="sha512.js"></script>
	<script type="text/javascript" src="forms.js"></script>
    <link href="css/bootstrap-401cbb0c7673d09a5919d5288002542c.css" media="screen" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css">
    <link href="css/application-ltr-a256b57024170c98ba019bc1c06cf31f.css" media="screen" rel="stylesheet" type="text/css">
    <link href="css/application-ltr3-81daf122e1788730417e886545a44f59.css" media="screen" rel="stylesheet" type="text/css">
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '162387903926058', // App ID
                channelUrl: 'https://agile-woodland-8639.herokuapp.com/', // Channel File
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });
            FB.ui({
                method: 'feed'
            });
        };
        // Load the SDK's source Asynchronously
        /*
		(function (d, debug) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all" + (debug ? "/debug" : "") + ".js";
            ref.parentNode.insertBefore(js, ref);
        }(document, /*debug*/ false));	*/	
	
		(function(d, s, id) {
			var js, fjs = d.getElementsByTagName(s)[0];
			if (d.getElementById(id)) return;
			js = d.createElement(s); js.id = id;
			js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=APP_ID";
			fjs.parentNode.insertBefore(js, fjs);
		}(document, 'script', 'facebook-jssdk'));
    </script>
</head>
<body>
    <div class="container">
        <h1 class="sign-in-to">Login</h1>
        <div class="cf module" id="user-session-form">            
            <div class="cell social-signin">
                <h4>Entrar no Portugol com...</h4>
                <a href="http://apps.facebook.com/aplicacaotestedemo" class="bttn social-signup facebook sign-up"><span class="icon-social-facebook"></span>Sign in with Facebook</a>
                <a href="#" class="bttn social-signup google sign-up"><span class="icon-social-google"></span>Sign in with Google</a>
                <a href="#" class="bttn social-signup twitter sign-up"><span class="icon-social-twitter"></span>Sign in with Twitter</a>
            </div>
            <div class="cell neutral email-signin">
                <h4>Preencha os campos em baixo...</h4>
                <span class="or module">V</span>
                <form action="process_login.php" method="post" name="login_form">
                    <div style="margin: 0; padding: 0; display: inline">                        
                    <form action="process_login.php" method="post" name="login_form">
					(*) Email: <input type="text" name="email" /><br />
					(*) Password: <input type="password" name="password" id="password"/><br />
					<input type="button" value="Login" onclick="formhash(this.form, this.form.password);" />
					<div style=color:red>
						<?php
							if(isset($_GET['error'])) { 
							echo 'Email ou Password incorrectos! <br />Preencha os campos assinalados (*)';}
						?>
					</div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
