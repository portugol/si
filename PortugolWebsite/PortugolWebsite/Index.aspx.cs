﻿using PortugolWebsite.Code.Shared;
using System;

namespace PortugolWebsite
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Alterar o label título "lblMainTitle" da Masterpage
            Master.mainTitle = Resources.InfoMessages.titleIde;
        }

       

       
    }
}