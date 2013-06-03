using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace PortugolWebsite.Code.Shared
{
    /// <summary>
    /// Funções públicas e estáticas que sejam uteis e transversais a toda a aplicação
    /// </summary>
    public static class SharedFunctions
    {
        /// <summary>
        /// Obter o controlo que causou o postback.
        /// Esta função é útil para efeitos de Debugging
        /// </summary>
        /// <param name="page">Página onde se quer encontrar o controlo que causou o postback</param>
        /// <returns>Controlo que causou o postback</returns>
        public static Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        /// <summary>
        /// Método para validar se um email é válido
        /// </summary>
        /// <param name="p_email">email a validar</param>
        /// <returns>true se email é válido, false caso contrário</returns>
        public static bool isEmailValid(string p_email)
        {
            string email = p_email;
            bool emailValid = false;

            if (email != null || email != string.Empty)
            {
                string strEmailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(strEmailRegex);

                if (!re.IsMatch(email))
                    emailValid = false;
                else
                    emailValid = true;
            }

            return emailValid;
        }

        
        /// <summary>
        /// Método para compor o corpo de uma mensagem de Email
        /// </summary>
        /// <param name="p_name">Nome do utilizador para o qual se vai enviar um mail</param>
        /// <param name="p_email">Email do utilizador para o qual se vai enviar um mail</param>
        /// <param name="p_message">Mensagem a enviar</param>
        /// <returns>Corpo de uma mensagem de Email</returns>
        public static string ComposeEmailBody(string p_name, string p_email, string p_message)
        {
            StringBuilder emailBody = new StringBuilder();

            emailBody.Append("Nome: " + p_name);
            emailBody.AppendLine();
            emailBody.Append("Endereço de e-mail: " + p_email);
            emailBody.AppendLine();
            emailBody.AppendLine();
            emailBody.Append("Mensagem: ");
            emailBody.AppendLine();
            emailBody.Append(p_message);

            return emailBody.ToString();
        }

        /// <summary>
        /// Método para enviar uma mensagem de email
        /// </summary>
        /// <param name="p_name">Nome do remetente</param>
        /// <param name="p_email">Email do destinatário</param>
        /// <param name="p_subject">Assunto do email</param>
        /// <param name="p_message">mensagem a enviar</param>
        /// <returns>true se enviado com sucesso, false caso contrário</returns>
        public static bool SendEmail(string originName, string originEmail, string destinationName, string destinationEmail, string p_subject, string p_message)
        {
            try
            {
                //Declarar objecto para envio de emails
                SmtpClient objSendMail;
                
                //Endereço de email e nome do servidor
                MailAddress origin = new MailAddress(originEmail, originName);

                //Endereço de email
                MailAddress destination = new MailAddress(destinationEmail, destinationName);

               

                //Mensagem de email
                MailMessage objEmailMessage = new MailMessage(origin, destination);

                //Subject
                objEmailMessage.Subject = p_subject;

                //Body
                objEmailMessage.Body = p_message.ToString();

                //Inicializar objecto para envio de emails
                objSendMail = new SmtpClient();

                //Send
                objSendMail.Send(objEmailMessage);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}