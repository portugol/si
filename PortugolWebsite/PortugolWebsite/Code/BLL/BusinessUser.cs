using PortugolWebsite.Code.CustomMembership;
using PortugolWebsite.Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PortugolWebsite.Code.BLL
{
    public static class BusinessUser
    {
        /// <summary>
        /// Gets the users recordset
        /// </summary>
        /// <param name="user_Id">user unique identifier</param>
        /// <param name="username">the user's name</param>
        /// <param name="firstName">User first Name</param>
        /// <param name="lastName">User Surame</param>
        /// <param name="email">user's email address</param>
        /// <param name="isActive">user's lock status</param>
        /// <returns>ADO.NET DataView</returns>
        public static DataView GetUser(int? user_Id = null, string username = "", string nome = "", bool? isActive = null)
        {
          

            try
            {
                //Aceder à base de dados para retornar os registos dos utilizadores consoante os filtros aplicados
                DataTable dataTable = UserDataAccess.GetUsers(user_Id, username, nome, isActive);

                //Verifica se existem registos
                if (dataTable.Rows.Count > 0)
                {//registos encontrados

                    //Remover a coluna da Password
                    dataTable.Columns.Remove("Password");
                    //      NOTA: Não se quer o servidor responda mostrando a password do utilizador.

                    return new DataView(dataTable);

                }
                else
                {
                    //Sair do método
                    return null;
                }
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
                
                //Devolver objecto nulo
                return null;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                
                //Devolver objecto nulo
                return null;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação
              
                //Devolver objecto nulo
                return null;
            }
        }


        /// <summary>
        /// Insert a user record into the data base
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="password">the user's password</param>
        /// <param name="firstname">User first Name</param>
        /// <param name="lastname">User surname</param>
        /// <param name="email">User e-mail address</param>
        /// <param name="preferedlanguage">user's favorite language</param>
        /// <param name="outRecordID">User's unique identifier</param>
        /// <returns>true if record is successfuly inserted, false otherwise</returns>
        public static bool InsertUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username, string Password)
        {
            try
            {

                int affectedRows = UserDataAccess.InsertUser(Nome, Morada, Contacto, Email, Lingua, EmailMoodle, TipoUtilizador, Username, Password);
                if (affectedRows > 0)
                    return true;
                else
                    return false;
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
               
                //Devolver erro
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                
                //Devolver erro
                return false;
            }
            catch (Exception)
            {
                //Apanhar excepção da própria applicação
                
                //Devolver erro
                return false;
            }
        }

        /// <summary>
        /// Updates a user record from the data base
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="firstName">User first Name</param>
        /// <param name="lastName">User surname</param>
        /// <param name="email">user e-mail address</param>
        /// <param name="preferedLanguage">user's favorite language</param>
        /// <param name="isActive">1 to set it active(unlock), 0 to set it inactive (lock)</param>
        /// <returns>true if record is successfuly updated, false otherwise</returns>
        public static bool UpdateUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username)
        {

            //Declarar a variável que irá conter o número de registos afectados
            int affectedRows = -1;
            try
            {
                affectedRows = UserDataAccess.UpdateUser(Nome, Morada, Contacto, Email, Lingua, EmailMoodle, TipoUtilizador, Username);
                if (affectedRows == 1)
                    return true;
                else
                    return false;

            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
               
                //Devolver erro
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
               
                //Devolver erro
                return false;
            }
            catch (Exception)
            {
                //Apanhar excepção da própria applicação
                
                //Devolver erro
                return false;
            }
        }

        /// <summary>
        /// Replaces a user's password for a new one
        /// </summary>
        /// <param name="User_Id">user unique identifier</param>
        /// <param name="oldPassword">user old password</param>
        /// <param name="newPassword">user new password</param>
        /// <returns>true if password is successfuly changed, false otherwise</returns>
        public static bool ChangePassword(int User_Id, string oldPassword, string newPassword)
        {

            try
            {
                //Aceder à base de dados para retornar os registos consoante os filtros aplicados
                DataTable userDataTable = UserDataAccess.GetUsers(User_Id);

                string username = Convert.ToString(userDataTable.Rows[0]["Username"]);

                return Membership.Provider.ChangePassword(username, oldPassword, newPassword);
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
               
                //Devolver erro
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                
                //Devolver erro
                return false;
            }
            catch (Exception)
            {
                //Apanhar excepção da própria applicação
               
                //Devolver erro
                return false;
            }
        }

        /// <summary>
        /// Set a user to an active state
        /// </summary>
        /// <param name="User_Id">user unique identifier</param>
        /// <returns>True if user is activated, false otherwise</returns>
        public static bool UnlockUser(int User_Id)
        {
            
            try
            {
                //Aceder à base de dados para retornar os registos consoante os filtros aplicados
                DataTable userDataTable = UserDataAccess.GetUsers(User_Id);

                string username = Convert.ToString(userDataTable.Rows[0]["Username"]);

                int affectedRows = UserDataAccess.SetUserToActive(username);
                if (affectedRows == 1)
                    return true;

                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                
                //Devolver erro
                return false;
            }
            catch (Exception)
            {
                //Apanhar excepção da própria applicação
                
                //Devolver erro
                return false;
            }
        }

        /// <summary>
        /// Set a user to an inactive state
        /// </summary>
        /// <param name="User_Id">user unique identifier</param>
        /// <returns>True if user is deactivated, false otherwise</returns>
        public static bool LockUser(int User_Id)
        {
            
            try
            {
                //Aceder à base de dados para retornar os registos consoante os filtros aplicados
                DataTable userDataTable = UserDataAccess.GetUsers(User_Id);

                string username = Convert.ToString(userDataTable.Rows[0]["Username"]);

                int affectedRows = UserDataAccess.SetUserToInactive(username);
                if (affectedRows == 1)
                    return true;

                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
               
                //Devolver erro
                return false;
            }
            catch (Exception)
            {
                //Apanhar excepção da própria applicação
                
                //Devolver erro
                return false;
            }
        }


    }
}