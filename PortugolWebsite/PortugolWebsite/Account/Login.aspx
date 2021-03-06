﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PortugolWebSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PortugolWebsite.Account.Login" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentHead" runat="server">
    <meta charset="utf-8" />
    <title>Entrar</title>
    <script async="" src="http://connect.facebook.net/en_US/all.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Lobster" media="screen" rel="stylesheet" type="text/css" />
    <link href="css/login.css" media="screen" rel="stylesheet" type="text/css" />
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '162387903926058', // App ID
                channelUrl: 'http://localhost/', // Channel File
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });
            FB.ui({
                method: 'feed'
            });
        };
        // Load the SDK's source Asynchronously
        (function (d, debug) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all" + (debug ? "/debug" : "") + ".js";
            ref.parentNode.insertBefore(js, ref);
        }(document, /*debug*/ false));
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <br />
        <br />
            <h2 class="sign-in-to">&nbsp; <asp:Literal ID="Literal11" Text="Entrar" runat="server"></asp:Literal></h2>
        
        <div class="cf module" id="user-session-form">
            <div class="cell social-signin">

                <h4><asp:Literal ID="Literal10" Text="Entrar no Portugol com..." runat="server"></asp:Literal></h4>
                <a href="#" class="bttn social-signup facebook sign-up"><span class="icon-social-facebook"></span><asp:Literal ID="Literal9" Text="Sign in with Facebook" runat="server"></asp:Literal></a>
                <a href="#" class="bttn social-signup google sign-up"><span class="icon-social-google"></span><asp:Literal ID="Literal8" Text="Sign in with Google" runat="server"></asp:Literal></a>
                <a href="#" class="bttn social-signup twitter sign-up"><span class="icon-social-twitter"></span><asp:Literal ID="Literal7" Text="Sign in with Twitter" runat="server"></asp:Literal></a>
            </div>
            <div class="cell neutral email-signin">
                <h4><asp:Literal ID="Literal5" Text="Preencha os campos em baixo..." runat="server"></asp:Literal></h4>
                <span class="or module"><asp:Literal ID="Literal6" Text="OU" runat="server"></asp:Literal></span>
                <asp:Login ID="LoginControl" onloggedin="setUserInfo" FailureText='<%$ Resources:ErrorMessages, loginFailureText %>'  runat="server">
                    <LayoutTemplate>
                        <div style="margin: 0; padding: 0; display: inline">
                    
                            <asp:Literal ID="user" Text="(*) Username:" runat="server"></asp:Literal>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <br />
                            <asp:Literal ID="pass" Text="(*) Password:" runat="server"></asp:Literal>
                            <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                            <br /><asp:Label ID="FailureText" ForeColor="Red" runat="server"></asp:Label>
                            <div class="remember-me">
                                <label for="user_remember_me"><asp:CheckBox ID="RememberMe" runat="server" />                                
                                    <asp:Literal ID="online" Text="Mantenha-me sempre ligado!" runat="server"></asp:Literal>
                                </label>                            
                            </div>
                            <asp:Button ID="Login" CommandName="Login" runat="server" Text="Login" />  
                            
                                <hr />
                                
                            <a href="RecoverPassword.aspx" class="secondary"><asp:Literal ID="recoverypass" Text="Esqueceu sua senha?" runat="server"></asp:Literal></a></>                    
                            <br />
                           <a href="Register.aspx" class="secondary"><asp:Literal ID="Literal1" Text="Registar-me!" runat="server"></asp:Literal></a></label>                  
                        </div>
                     </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
        </div>

        <div id="fb-root"></div>
        <script>
            // Facebook
            var FB_APP_ID = '162387903926058';
            window.fbAsyncInit = function () {
                var FB = (window.FB || undefined);
                if (FB) {
                    FB.init({
                        appId: FB_APP_ID
                    , channelUrl: window.root_url + '/channel.html'
                    , status: true
                    , cookie: true
                    , xfbml: true
                    });
                }
            };

            (function (d) {
                var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                if (d.getElementById(id)) { return; }
                js = d.createElement('script'); js.id = id; js.async = true;
                js.src = "../../connect.facebook.net/en_US/all.js";
                ref.parentNode.insertBefore(js, ref);
            }(document));
        </script>
</asp:Content>
