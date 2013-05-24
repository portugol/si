using PortugolWebsite.Code.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace PortugolWebsite.Code.CustomMembership
{
    /// <summary>
    /// Classe para que os controlos asp login funcionem com MySQL e com a base de dados do Portugol
    /// </summary>
    public class CustomMembershipProvider : MembershipProvider
    {
        private string sProviderName;
        private string sAppName;

        private bool bEnablePasswordRetrieval;
        private bool bEnablePasswordReset;
        private bool bRequiresQuestionAndAnswer;
        private bool bRequiresUniqueEMail;
        private int ipasswordAttemptWindow;
        private int iMinRequiredNonAlphanumericCharacters;
        private int iminRequiredPasswordLength;
        private int imaxInvalidPasswordAttempts;
        private string sPasswordStrengthRegularExpression;
        private MembershipPasswordFormat mPasswordFormat;
        private MachineKeyValidation machinekeyValidation;
        private byte[] _DecryptionKey;
        private byte[] _ValidationKey;

        #region atributos

        public override string ApplicationName
        {
            get
            {

                return this.sAppName;
            }
            set
            {
                sAppName = value;
            }
        }

        public override string Name
        {
            get
            {
                return this.sProviderName;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return this.bEnablePasswordReset;
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return this.bEnablePasswordRetrieval;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return this.mPasswordFormat;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return this.bRequiresQuestionAndAnswer;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return this.ipasswordAttemptWindow;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return this.bRequiresUniqueEMail;
            }
        }

        #endregion

        #region overwrite

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            // Get the machineKey section.
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            MachineKeySection key = (MachineKeySection)conf.GetSection("system.web/machineKey");
            this.machinekeyValidation = key.Validation;
            System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

            //Atribuir os valores dos atributos definidos no web.config a variáveis locais
            this.sProviderName = name;
            this.sAppName = config["applicationName"];
            this.bEnablePasswordRetrieval = config["enablePasswordRetrieval"].ToLower() == "true" ? true : false;
            this.bEnablePasswordReset = config["enablePasswordReset"].ToLower() == "true" ? true : false;
            this.bRequiresQuestionAndAnswer = config["requiresQuestionAndAnswer"].ToLower() == "true" ? true : false;
            this._DecryptionKey = ue.GetBytes(key.DecryptionKey);
            this._ValidationKey = ue.GetBytes(key.ValidationKey);
            this.bRequiresUniqueEMail = config["requiresUniqueEmail"].ToLower() == "true" ? true : false; ;
            this.ipasswordAttemptWindow = int.Parse(config["passwordAttemptWindow"]);
            this.iMinRequiredNonAlphanumericCharacters = int.Parse(config["minRequiredNonalphanumericCharacters"]);
            this.iminRequiredPasswordLength = int.Parse(config["minRequiredPasswordLength"]);
            this.imaxInvalidPasswordAttempts = int.Parse(config["maxInvalidPasswordAttempts"]);
            this.sPasswordStrengthRegularExpression = config["passwordStrengthRegularExpression"];

            switch (config["passwordFormat"])
            {
                case "Hashed":
                    this.mPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    this.mPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    this.mPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }


            base.Initialize(name, config);
        }

        public override bool ValidateUser(string strUsername, string strPassword)
        {
            string userPassword;

            try
            {
                DataTable userDataTable = UserDataAccess.GetUserByUsername(strUsername);
                if (userDataTable.Rows.Count > 0)
                {
                    //Devolver a password (que está encriptada) da base de dados
                    userPassword = Convert.ToString(userDataTable.Rows[0]["Passwrd"]);

                    //Verificar se o utilizador está activo
                    if (isUserActive(strUsername))
                        switch (mPasswordFormat)
                        {
                            case MembershipPasswordFormat.Hashed:
                                //Comparar a password passada por parametro com a password na base de dados
                                if (userPassword == ConvertPasswordForStorage(strPassword))
                                    return true;
                                break;
                            case MembershipPasswordFormat.Encrypted:
                                throw new NotImplementedException();
                            case MembershipPasswordFormat.Clear:
                                if (userPassword == strPassword)
                                    return true;
                                break;
                            default:
                                throw new ProviderException("Password format not supported.");
                        }
                }

            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }

            return false;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            
            throw new NotImplementedException("este Método nao está a ser usado");

        }

        public override string GetPassword(string username, string strAnswer)
        {
            if (this.bEnablePasswordRetrieval)
                return ResetPassword(username, strAnswer);

            //Não se pode atribuir nova password caso essa opção esteja inactiva nas configurações
            throw new NotSupportedException("Current configuration settings do not allow password retrieval");

        }

        public override string GetUserNameByEmail(string strEmail)
        {
            //Verificar se as configurações permitem que o email seja único

            throw new NotImplementedException();
             //   DataTable allUsers = UserDataAccess.GetUserByEmail();
                
             //   return Convert.ToString( allUsers.Rows[0]["Username"]);
            
        }

        public override string ResetPassword(string username, string strAnswer)
        {//Define uma nova password gerada automaticamente.

            string AutoGeneratedPassword = null;

            try
            {
                //Verificar configurações
                if (!EnablePasswordReset)
                    //Não se pode atribuir nova password caso essa opção esteja inactiva nas configurações
                    throw new NotSupportedException("Current configuration settings do not allow resetting passwords");

                //Verificar se o utilizador existe e está activo
                if (!isUserActive(username))
                    throw new ApplicationException(string.Format("User {0} does not exist or is inactive", username));

                //Gerar nova password de 8 caracteres
                AutoGeneratedPassword = System.Web.Security.Membership.GeneratePassword(8, 1);
                AutoGeneratedPassword = Regex.Replace(AutoGeneratedPassword, @"[^a-zA-Z0-9]", m => "A");
                AutoGeneratedPassword += "#_1";

                //Encryptar(SHA1) a password gerada automaticamente 
                string storagePassword = this.ConvertPasswordForStorage(AutoGeneratedPassword);

                //Actualizar a password do utilizador na Base de Dados
                UserDataAccess.ModifyUserPassword(storagePassword, username);

                return AutoGeneratedPassword;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error resetting password", ex);
            }
        }

        public override bool ChangePassword(string username, string strOldPwd, string strNewPwd)
        {
            //Verificar configurações
            if (!this.bEnablePasswordReset)
                //Não se pode atribuir nova password caso essa opção esteja inactiva nas configurações
                throw new NotSupportedException("Current configuration settings do not allow resetting passwords");

            //Verificar se a password antiga e nova são iguais
            if (strOldPwd == strNewPwd)
                return false;

            //Verificar se o utilizador e password são parâmetros válidos
            if (!this.ValidateUser(username, strOldPwd))
                return false;

            //Verificar os requisitos mínimos de atribuição de passwords
            if (!isValidPassword(strNewPwd))
                return false;

            try
            {
                //Encryptar(SHA1) a password gerada automaticamente 
                string storagePassword = this.ConvertPasswordForStorage(strNewPwd);

                //Actualizar a password do utilizador na Base de Dados
                if (UserDataAccess.ModifyUserPassword(username, storagePassword) <= 0)
                    return false;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error changing password", ex);
            }

            return true;
        }

        public override int GetNumberOfUsersOnline()
        {

            throw new Exception("The method or operation is not implemented.");
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string strPassword, string strNewPwdQuestion, string strNewPwdAnswer)
        {
            throw new Exception("The method or operation is not implemented.");

        }

        public override MembershipUser GetUser(string username, bool boolUserIsOnline)
        {

            try
            {
                //Aceder à base de dados e devolver a informação do utilizador
                DataTable userDataTable = UserDataAccess.GetUserByUsername(username);

                //Verificar se houve valores devolvidos da BD, ou seja, verificar se o utilizador existe
                if (userDataTable.Rows.Count == 1)
                {
                    string name = Convert.ToString(userDataTable.Rows[0]["Nome"]);
                    string morada = Convert.ToString(userDataTable.Rows[0]["Morada"]);
                    string contacto = Convert.ToString(userDataTable.Rows[0]["Contacto"]);
                    bool isActive = Convert.ToBoolean(userDataTable.Rows[0]["isActive"]);
                    DateTime CreationDate = Convert.ToDateTime(userDataTable.Rows[0]["Created"]);
                    string PreferedLanguage = Convert.ToString(userDataTable.Rows[0]["PreferedLanguage"]);
                    DateTime? Updated;

                    if (userDataTable.Rows[0]["Updated"] == DBNull.Value)
                        Updated = null;
                    else
                        Updated = Convert.ToDateTime(userDataTable.Rows[0]["Updated"]);

                    //Declarar novo objecto MembershipUser
                    CustomMembershipUser user = new CustomMembershipUser(username, name, morada, contacto, isActive, PreferedLanguage);

                    return user;
                }

                return null;
            }
            catch (DataException ex)
            {
                throw new DataException(ex.ToString());
            }
        }

        public override bool DeleteUser(string username, bool boolDeleteAllRelatedData)
        {
            throw new NotImplementedException();

            //if (boolDeleteAllRelatedData)
            //    throw new NotImplementedException("not implemented yet");

            //try
            //{
            //    if (!boolDeleteAllRelatedData)
            //    {
            //        if (UserDataAccess.DeleteUser(username) > 0)
            //            return true;
            //        else
            //            return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}

            //return false;
        }

        public override MembershipUserCollection FindUsersByEmail(string strEmailToMatch, int iPageIndex, int iPageSize, out int iTotalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUserCollection FindUsersByName(string strUsernameToMatch, int iPageIndex, int iPageSize, out int iTotalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUserCollection GetAllUsers(int iPageIndex, int iPageSize, out int iTotalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool UnlockUser(string strUserName)
        {
            int affectedRows = UserDataAccess.SetUserToActive(strUserName);
            if (affectedRows > 1)
                return true;

            return false;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return this.sPasswordStrengthRegularExpression;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return this.iMinRequiredNonAlphanumericCharacters;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return this.iminRequiredPasswordLength;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return this.imaxInvalidPasswordAttempts;
            }
        }
        #endregion

        public CustomMembershipUser CreateUser(string Nome, string Morada, string Contacto, string Email, int? Lingua, string EmailMoodle, int TipoUtilizador, string Username, string Password, out MembershipCreateStatus status)
        {
            //Declarar variável indicadora/descritiva de possiveis erros 
            string outErrorMessage = string.Empty;

            CustomMembershipUser newUser = new CustomMembershipUser();

            //Aceder à base de dados e devolver a informação do utilizador
            DataTable userDataTable = UserDataAccess.GetUserByUsername(Username);

            //Verificar se já existe um utilizador com o mesmo username
            //Verificar se houve valores devolvidos da BD, ou seja, verificar se o utilizador existe
            if (userDataTable.Rows.Count > 0)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            //Validar requisitos mínimos para a password
            //Declarar evento de validação
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(Username, Password, true);
            //Chamar o evento da classe-pai Membership
            base.OnValidatingPassword(args);

            //Verificar se a password é válida
            // Validate the password
            if (!isValidPassword(Password))
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }


            //Converter Password
            string convertedPassword = ConvertPasswordForStorage(Password);
            //Esta password pode ser encrypted, clear ou hashed

            try
            {
                //Executar o comando e devolver o número de registos afectados
                int affectedRows = UserDataAccess.InsertUser(Nome, Morada, Contacto, Email, Lingua, EmailMoodle, TipoUtilizador, Username,convertedPassword);

                //Devolver erro caso não se consiga inserir registo
                if (affectedRows <= 0)
                {
                    status = MembershipCreateStatus.ProviderError;
                    return null;
                }

                
                //Alterar o estado do processo
                status = MembershipCreateStatus.Success;
                //Devolver o novo utilizador
                return newUser;
               

             
            }

            catch (Exception)
            {
                //Alterar o estado do processo
                status = MembershipCreateStatus.ProviderError;
                return null;
            }

        }


        private bool isValidPassword(string password)
        {

            System.Text.RegularExpressions.Regex HelpExpression;
            // Validar o comprimento da password
            if (password.Length < this.iminRequiredPasswordLength)
                return false;
            // Validar o número de caracteres não-alfanuméricos
            HelpExpression = new Regex(@"\W");
            if (HelpExpression.Matches(password).Count < this.iMinRequiredNonAlphanumericCharacters)
                return false;
            // Validate regular expression
            if (this.sPasswordStrengthRegularExpression != null)
            {
                HelpExpression = new Regex(this.sPasswordStrengthRegularExpression);
                if (HelpExpression.Matches(password).Count > 0)
                    return false;
            }

            return true;
        }

        private bool isUserActive(string username)
        {
            try
            {
                return UserDataAccess.isUserActive(username);
            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }
        }

        private string ConvertPasswordForStorage(string Password)
        {
            string hashedPassword = Password;

            switch (this.mPasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    hashedPassword = Password;
                    break;

                case MembershipPasswordFormat.Hashed:
                    hashedPassword = HashString(Password);
                    break;

                case MembershipPasswordFormat.Encrypted:
                    hashedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(Password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return hashedPassword;
        }

        private string HashString(string inputString)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(this.machinekeyValidation.ToString());
            if (algorithm == null)
            {
                throw new ArgumentException("Unrecognized hash name", "hashName");
            }

            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            return Convert.ToBase64String(hash);
        }
    }
}