using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PortugolWebsite.Code.DAL.Queries
{
    public static class RoleQueries
    {
        /// <summary>
        /// SQL query to select roles
        /// </summary>
        /// <param name="Id">The role unique Identifier</param>
        /// <param name="Tipo">The role's name</param>
        /// <returns>SQL query string</returns>
        public static string SelectRoles(int? Id = null, string Tipo = "")
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT Id, Tipo ");
            strQuery.Append(" FROM tipo_user ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (Id != null)
                strQuery.Append(" and Id = " + Convert.ToString(Id));
            if (!string.IsNullOrEmpty(Tipo))
                strQuery.Append(" and Tipo = '" + Tipo + "'");

            return strQuery.ToString();

        }

        /// <summary>
        /// SQL query to insert a role
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <param name="roleDescription">Role's description</param>
        /// <returns>SQL query string</returns>
        public static string InsertRole(string tipo)
        {


            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" insert into tipo_user (Tipo) ");
            strQuery.Append(" values('" + tipo + "'");

            return strQuery.ToString();
        }

        /// <summary>
        /// SQL query to modify a role
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <param name="roleDescription">Role's description</param>
        /// <returns>SQL query string</returns>
        public static string UpdateRole(int Id, string Tipo)
        {
            throw new NotImplementedException();

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" Update tipo_user ");
            strQuery.Append(" set Tipo = '" + Tipo + "', ");
            strQuery.Append(" Where Id = '" + Id + "'");

            return strQuery.ToString();
        }

        /// <summary>
        /// SQL query to efectivly delete a role
        /// </summary>
        /// <param name="rolename">Role's name</param>
        /// <returns>SQL query string</returns>
        public static string DeleteRole(int id)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" delete from tipo_user ");
            strQuery.Append(" Where id = " + id.ToString() + "");

            return strQuery.ToString();
        }
    }
}