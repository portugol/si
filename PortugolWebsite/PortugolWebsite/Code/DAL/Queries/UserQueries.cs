using System;
using System.Text;

namespace PortugolWebsite.Code.DAL.Queries
{
    public static class UserQueries
    {
        
        /// <summary>
        /// SQL query to select users
        /// </summary>
        /// <param name="User_Id">user unique identifier</param>
        /// <param name="Username">the user's name</param>
        /// <param name="isActive">Indicates to query active, or inactive users</param>
        /// <returns>SQL Query string</returns>
        internal static string SelectUsers(int? user_Id = null, string username = "", string nome = "", bool? isActive = null)
        {

            StringBuilder strQuery = new StringBuilder();


            strQuery.Append(" SELECT Id, Nome, Morada, Contacto, Email, Lingua,");
            strQuery.Append(" EmailMoodle, TipoUtilizador, Username, Passwrd, isActive ");
            strQuery.Append(" FROM utilizadores ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (user_Id != null)
                strQuery.Append(" and Id = " + Convert.ToString(user_Id));
            if (!string.IsNullOrEmpty(username))
                strQuery.Append(" and Username = '" + username + "'");
            if (isActive != null)
                if (isActive.GetValueOrDefault())
                    strQuery.Append(" and isActive =  1");
                else
                    strQuery.Append(" and isActive =  0");


            return strQuery.ToString();
        }

        /// <summary>
        /// SQL query to insert a user
        /// </summary>
        /// <param name="Nome">User name</param>
        /// <param name="Morada">User Address</param>
        /// <param name="Contacto">User contact</param>
        /// <param name="Email">User website registration email address</param>
        /// <param name="Lingua">User prefered language</param>
        /// <param name="EmailMoodle">Users moodle email address</param>
        /// <param name="TipoUtilizador">User type(role)</param>
        /// <param name="Username">Username</param>
        /// <param name="Password">Users encrypted password</param>
        /// <returns></returns>
        internal static string InsertUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username, string Password)
        {
            StringBuilder strQuery = new StringBuilder();


            strQuery.Append(" Insert into utilizadores ( Nome, Morada, Contacto, Email, Lingua,");
            strQuery.Append(" EmailMoodle, TipoUtilizador, Username, Passwrd, isActive )");
            strQuery.Append(" Values ('" + Nome + "', '" + Morada + "', '" + Contacto + "', '" + Email + "', " + Lingua + ", '" + EmailMoodle + "', " + TipoUtilizador + ", '" + Username + "', '" + Password + "', 1");
            
            return strQuery.ToString();
        }

        /// <summary>
        /// SQL query to change a user's password
        /// </summary>
        /// <param name="username">The user's name</param>
        /// <param name="newPassword">user's new password</param>
        /// <returns>SQL query string</returns>
        internal static string ModifyUserPassword(string username, string newPassword)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" Update utilizadores ");
            strQuery.Append(" set Passwrd = '" + newPassword + "'");
            strQuery.Append(" Where Username = '" + username + "'");

            return strQuery.ToString();

        }

        /// <summary>
        /// SQL query to activate a user
        /// </summary>
        /// <param name="username">The user's name</param>
        /// <returns>SQL Query string</returns>
        internal static string SetUserToActive(string username)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" Update utilizadores ");
            strQuery.Append(" set isActive = 1");
            strQuery.Append(" Where Username = '" + username + "'");

            return strQuery.ToString();

        }

        /// <summary>
        /// SQL query to Inactivate a user
        /// </summary>
        /// <param name="username">The user's name</param>
        /// <returns>SQL Query string</returns>
        internal static string SetUserToInactive(string username)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" Update utilizadores ");
            strQuery.Append(" set isActive = 0");
            strQuery.Append(" Where Username = '" + username + "'");

            return strQuery.ToString();

        }


        internal static string UpdateUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username)
        {
            StringBuilder strQuery = new StringBuilder();


            strQuery.Append(" Update utilizadores ");
            strQuery.Append(" set Nome = '" + Nome +"', ");
            strQuery.Append(" set Morada = '" + Morada +"', ");
            strQuery.Append(" set Contacto = '" + Contacto +"', ");
            strQuery.Append(" set Email = '" + Email +"', ");
            strQuery.Append(" set Lingua = '" + Lingua +"', ");
            strQuery.Append(" set EmailMoodle = '" + EmailMoodle +"', ");
            strQuery.Append(" set TipoUtilizador = " + TipoUtilizador +", ");
            strQuery.Append(" Where Username = '" + Username + "'");

            return strQuery.ToString();

        }



        internal static string SelectUserRole(int? user_Id = null, string username = "")
        {
            StringBuilder strQuery = new StringBuilder();


            strQuery.Append(" SELECT utilizadores.Id, Nome, Morada, Contacto, Email, Lingua,");
            strQuery.Append(" EmailMoodle, TipoUtilizador, Username, Password, isActive, tipo_user.id, Tipo ");
            strQuery.Append(" FROM utilizadores inner join tipo_user on utilizadores.TipoUtilizador = tipo_user.Id ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (user_Id != null)
                strQuery.Append(" and utilizadores.Id = " + Convert.ToString(user_Id));
            if (!string.IsNullOrEmpty(username))
                strQuery.Append(" and Username = '" + username + "'");

            return strQuery.ToString();


        }

    }
}