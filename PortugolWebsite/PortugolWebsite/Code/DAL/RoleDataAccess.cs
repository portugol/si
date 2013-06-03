
using PortugolWebsite.Code.DAL.Queries;
using System.Data;

namespace PortugolWebsite.Code.DAL
{
    public static class RoleDataAccess
    {
        #region DataBase information retrieval

        /// <summary>
        /// Consulta a base de dados e retorna os roles
        /// </summary>
        /// <returns>DataTable de Roles: Role_Id, RoleName, RoleDescription, Created, Updated</returns>
        public static DataTable GetRoles(int? role_Id = null, string roleName = "")
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.SelectRoles(role_Id, roleName);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);

        }


        /// <summary>
        /// Consulta a base de dados e retorna o role
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>DataTable de Roles: Role_Id, RoleName, RoleDescription, Created, Updated</returns>
        public static DataTable GetRoleByName(string roleName)
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.SelectRoles(null, roleName);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }

        /// <summary>
        /// Consulta a base de dados e retorna o role
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>DataTable de Roles: Role_Id, RoleName, RoleDescription, Created, Updated</returns>
        public static DataTable GetRoleById(int roleId)
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.SelectRoles(roleId);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }


        /// <summary>
        /// Consulta a base de dados e retorna os roles do user
        /// </summary>
        /// <returns>DataTable de Roles: Role_Id, RoleName, RoleDescription, Created, Updated</returns>
        public static DataTable GetUsersByRole(string roleName)
        {
            //Obter o comando SQL
            string sqlQuery = UserQueries.SelectUserRole();
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);
        }
        #endregion

        #region DataBase Update records

        public static int UpdateRole(int id, string roleName)
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.UpdateRole(id, roleName);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }

        #endregion

        #region DataBase Insert new records

        public static int InsertRole(string roleName)
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.InsertRole(roleName);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }
        #endregion

        #region DataBase Delete records

        public static int DeleteRole(int id)
        {
            //Obter o comando SQL
            string sqlQuery = RoleQueries.DeleteRole(id);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }

        #endregion
    }
}