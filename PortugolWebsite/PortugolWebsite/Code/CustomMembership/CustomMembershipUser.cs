using PortugolWebsite.Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PortugolWebsite.Code.CustomMembership
{
    public class CustomMembershipUser : MembershipUser
    {
        private string p_username;
        private string p_nome;
        private string p_morada;
        private string p_contacto;
        private bool p_isactive;
        private string p_preferedLanguage;

        //Construtor por defeito
        public CustomMembershipUser()
        {
            this.p_username = null;
            this.p_nome = null;
            this.p_morada = null;
            this.p_contacto = null;
            this.p_isactive = false;
            this.p_preferedLanguage = "none";
        }

        //Construtor por parâmetros  - Utilizado em caso de novo registo
        public CustomMembershipUser(string username, string nome, string morada, string contacto, bool isActive, string PreferedLanguage)
        {

            this.p_username = username;
            this.p_nome = nome;
            this.p_morada = morada;
            this.p_contacto = contacto;
            this.p_isactive = isActive;
            this.p_preferedLanguage = PreferedLanguage;
        }

       

        #region atributos
        public string Username
        {
            get { return p_username; }
            set { p_username = value; }
        }


        public string Nome
        {
            get { return p_nome; }
            set { p_nome = value; }
        }

        public string Morada
        {
            get { return p_morada; }
            set { p_morada = value; }
        }

        public string Contacto
        {
            get { return p_contacto; }
            set { p_contacto = value; }
        }

        public bool isActive
        {
            get { return p_isactive; }
            set { p_isactive = value; }
        }

        public string PreferedLanguage
        {
            get { return p_preferedLanguage; }
            set { p_preferedLanguage = value; }
        }		
        #endregion

        #region Métodos


        public override bool ChangePassword(string oldPassword, string newPassword)
        {
            return Membership.Provider.ChangePassword(this.UserName, oldPassword, newPassword);
        }

        public override string ResetPassword()
        {
            return Membership.Provider.ResetPassword(this.UserName, null);
        }

        public override string GetPassword()
        {
            return Membership.Provider.GetPassword(this.UserName, null);
        }

        public override string GetPassword(string passwordAnswer)
        {
            return base.GetPassword(passwordAnswer);
        }

        public override bool IsLockedOut
        {
            get
            {
                return base.IsLockedOut;
            }
        }

        public override string ResetPassword(string passwordAnswer)
        {
            return base.ResetPassword(passwordAnswer);
        }

        public override string UserName
        {
            get
            {
                return this.p_username;
            }
        }

        

        #endregion


    }
}