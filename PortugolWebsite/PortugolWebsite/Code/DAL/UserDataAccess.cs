
using PortugolWebsite.Code.DAL.Queries;
using System;
using System.Data;

namespace PortugolWebsite.Code.DAL
{
    public static class UserDataAccess
    {
        #region DataBase information retrieval


        /// <summary>
        /// Consulta a base de dados e retorna os users consoante os filtros aplicados
        /// </summary>
        /// <returns> ADO.NET DataTable </returns>
        public static DataTable GetUsers(int? user_Id = null, string username = "", string nome = "", bool? isActive = null)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SelectUsers(user_Id, username, nome, isActive);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }

        /// <summary>
        /// Consulta a base de dados e retorna o user
        /// </summary>
        /// <param name="username">username do utilizador</param>
        /// <returns> ADO.NET DataTable </returns>
        public static DataTable GetUserByUsername(string username)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SelectUsers(null, username);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }

        /// <summary>
        /// Consulta a base de dados e retorna os users activos
        /// </summary>
        /// <returns>DataTable de Users: User_Id, Username, Password, FirstName, LastName, Email, PreferedLanguage, Created, Updated</returns>
        public static DataTable GetActiveUsers()
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SelectUsers(null, null, null, true);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }

        /// <summary>
        /// Consulta a base de dados e verifica se o utilizador está activo
        /// </summary>
        /// <param name="username">username do utilizador</param>
        /// <returns>Verdaderio se activo, falso se outro caso</returns>
        public static bool isUserActive(string username)
        {
            //Devolver o estado do utilizador
            return Convert.ToBoolean(GetUserByUsername(username).Rows[0]["isActive"]);
        }

        /// <summary>
        /// Consulta a base de dados e devolve o tipo de utilizador
        /// </summary>
        /// <returns>DataTable de User_Roles</returns>
        public static DataTable GetUserRole(int? user_Id = null, string username = "")
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SelectUserRole(user_Id, username);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }


        /// <summary>
        /// Consulta a base de dados e retorna os roles do user
        /// </summary>
        /// <returns>DataTable de Roles: Role_Id, RoleName, RoleDescription, Created, Updated</returns>
        public static DataTable GetUsersByRole(string roleName)
        {
            throw new NotImplementedException();
            //Obter o comando SQL
            //string sqlQuery = "";
            //Devolver o resultado da query num objecto DataTable
            //return DataAccessLayer.GetDataTable(sqlQuery);
        }
        #endregion

        #region DataBase Update records

        public static int ModifyUserPassword(string username, string newPassword)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.ModifyUserPassword(username, newPassword);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);

        }

        public static int SetUserToActive(string username)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SetUserToActive(username);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);

        }

        public static int SetUserToInactive(string username)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SetUserToInactive(username);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);

        }

        public static int UpdateUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.UpdateUser(Nome, Morada, Contacto, Email, Lingua, EmailMoodle, TipoUtilizador,  Username);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);

        }

        #endregion

        #region DataBase Insert new records

        public static int InsertUser(string Nome, string Morada, string Contacto, string Email, int Lingua, string EmailMoodle, int TipoUtilizador, string Username, string Password)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.InsertUser(Nome, Morada, Contacto, Email, Lingua, EmailMoodle, TipoUtilizador, Username, Password);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }

        

       

        #endregion

        #region DataBase Delete records

        
      

        #endregion
    }
}