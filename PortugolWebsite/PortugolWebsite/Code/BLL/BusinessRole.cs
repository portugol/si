using PortugolWebsite.Code.DAL;
using System;
using System.Data;

namespace PortugolWebsite.Code.BLL
{
    public static class BusinessRole
    {
        /// <summary>
        /// Gets the roles (Tipo Utilizadores) recordset
        /// </summary>
        /// <param name="role_Id">Role unique identifier</param>
        /// <param name="roleName">Role name</param>
        /// <returns>ADO.NET DataView</returns>
        public static DataView GetRoles(int? role_Id = null, string roleName = "")
        {
           
            DataView rolesDataView = new DataView();
            try
            {
                rolesDataView.Table = RoleDataAccess.GetRoles(role_Id, roleName);
                return rolesDataView;
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
    }
}