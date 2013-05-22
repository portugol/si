using System;
using System.Text;
using System.Web.UI;

namespace PortugolWebsite
{
    public partial class PortugolWebSite : System.Web.UI.MasterPage
    {
        public string mainTitle 
        {
            get { return lblMainTitle.Text; }
            set { lblMainTitle.Text = value;}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterShowHideScript();
        }

         // FUNÇÃO QUE ESCONDE E MOSTRA A BARRA LATERAL
        private void RegisterShowHideScript()
        {

            StringBuilder scriptText = new StringBuilder();
                
            scriptText.Append(" \r\n");
            scriptText.Append("function show_hide() {\r\n");
            scriptText.Append(" var change = document.getElementById('" + hiddenShow_hide.ClientID + "');\r\n");
            scriptText.Append(" if (change.value == 1) {\r\n");
            scriptText.Append("     document.getElementById('content').style.left = '0px';\r\n");
            scriptText.Append("     document.getElementById('btnHide').title = 'Abrir Menu'; //Mudar o tooltip do butão\r\n");
            scriptText.Append("     change.value = 0;\r\n");
            scriptText.Append(" }\r\n");
            scriptText.Append(" else {\r\n");
            scriptText.Append("     document.getElementById('content').style.left = '240px';\r\n");
            scriptText.Append("     document.getElementById('btnHide').title = 'Fechar Menu'; //Mudar o tooltip do butão\r\n"); //TODO: Ir buscar esta mensagem 'Fechar Menu' aos resources
            scriptText.Append("     change.value = 1;\r\n");
            scriptText.Append(" }\r\n");
            scriptText.Append("}\r\n");


            if (!Page.ClientScript.IsStartupScriptRegistered("ShowHideScript"))
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowHideScript", scriptText.ToString(), true);
        }
    }
}