//Logins do Facebook, Google, Twitter, etc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;

namespace AllLogins
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            // See http://go.microsoft.com/fwlink/?LinkId=252803 for details on setting up this ASP.NET
            // application to support logging in via external services.

            //OpenAuth.AuthenticationClients.AddTwitter(
            //    consumerKey: "your Twitter consumer key",
            //    consumerSecret: "your Twitter consumer secret");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "your Microsoft account client id",
            //    clientSecret: "your Microsoft account client secret");

            //Login Authentication with Facebook
            OpenAuth.AuthenticationClients.AddFacebook(
                appId: "162387903926058",
                appSecret: "4ad8ced0a54ef99b37dd7174fc22fd68");            

            //Login Authentication with Google
            OpenAuth.AuthenticationClients.AddGoogle();
        }
    }
}