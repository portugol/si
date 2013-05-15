using PortugolWebsite.Code.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PortugolWebsite.Code.CustomMembership
{
    public class CustomMembershipRole : RoleProvider
    {


        public CustomMembershipRole()
        {

        }

        #region Attributes
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        #endregion

        #region override

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (String.IsNullOrEmpty(name))
                name = "CustomRolesProvider";

            if (config == null)
                throw new ArgumentNullException("Parâmetro config não pode ser nulo");




            base.Initialize(name, config);
        }

        public override string[] GetAllRoles()
        {
            ArrayList rolesList = new ArrayList();

            try
            {
                DataTable roleDataTable = RoleDataAccess.GetRoles();

                foreach (DataRow row in roleDataTable.Rows)
                {
                    rolesList.Add(Convert.ToString(row["RoleName"]));
                }
            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }

            if (rolesList.Count == 0)
                return null;

            return (string[])rolesList.ToArray(typeof(string));
        }

        public override string[] GetRolesForUser(string username)
        {
            ArrayList rolesList = new ArrayList();

            try
            {
                DataTable roleDataTable = RoleDataAccess.GetRoles();

                foreach (DataRow row in roleDataTable.Rows)
                {
                    rolesList.Add(Convert.ToString(row["RoleName"]));
                }
            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }

            return (string[])rolesList.ToArray(typeof(string));

        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();

            //ArrayList usersList = new ArrayList();

            //try
            //{

            //    if (usernameToMatch == string.Empty || usernameToMatch == null)
            //    {
            //        DataTable roleDataTable = UserDataAccess.GetUserRoles();

            //        //Encontrar todos os users associados ao role passado por parâmetro
            //        foreach (DataRow userRoleRow in roleDataTable.Rows)
            //            usersList.Add(Convert.ToString(userRoleRow["Username"]));
            //    }
            //    else
            //    {
            //        DataTable roleDataTable = UserDataAccess.FindUserInRole(roleName, usernameToMatch);

            //        //Encontrar o user associado ao role passado por parâmetro
            //        foreach (DataRow userRoleRow in roleDataTable.Rows)
            //            usersList.Add(Convert.ToString(userRoleRow["Username"]));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}

            //if (usersList.Count == 0)
            //    return null;

            //return (string[])usersList.ToArray(typeof(string));
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();

            //if (usernames.Length <= 0 || roleNames.Length <= 0)
            //    throw new ApplicationException("No users or no roles to add");

            //try
            //{
            //    UserDataAccess.InsertUsersRoles(usernames, roleNames);

            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}
        }

        public override void CreateRole(string roleName)
        {
            try
            {
                RoleDataAccess.InsertRole(roleName);

            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }
        }

        public override bool DeleteRole(string id, bool throwOnPopulatedRole)
        {
            try
            {
                RoleDataAccess.DeleteRole(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                if (throwOnPopulatedRole)
                    throw new DataException(ex.ToString());

                return false;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();

            //ArrayList usersList = new ArrayList();

            //try
            //{
            //    DataTable roleDataTable = UserDataAccess.FindUserInRole(roleName, null);
            //    //Encontrar todos os users associados ao role passado por parâmetro
            //    foreach (DataRow userRoleRow in roleDataTable.Rows)
            //        usersList.Add(Convert.ToString(userRoleRow["Username"]));
            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}

            //if (usersList.Count == 0)
            //    return null;

            //return (string[])usersList.ToArray(typeof(string));
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();

            //if (username == "" || username == null)
            //    return false;
            //if (roleName == "" || roleName == null)
            //    return false;

            //try
            //{
            //    DataTable roleDataTable = UserDataAccess.FindUserInRole(roleName, username);

            //    if (roleDataTable.Rows.Count > 0)
            //        return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}

            //return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();

            //if (usernames.Length <= 0 || roleNames.Length <= 0)
            //    throw new ApplicationException("No users or no roles to remove");

            //try
            //{
            //    UserDataAccess.DeleteUsersRoles(usernames, roleNames);

            //}
            //catch (Exception ex)
            //{
            //    throw new DataException(ex.ToString());
            //}
        }

        public override bool RoleExists(string roleName)
        {
            if (roleName == "" || roleName == null)
                return false;

            try
            {
                int roleCount = RoleDataAccess.GetRoleByName(roleName).Rows.Count;
                if (roleCount > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.ToString());
            }

            return false;
        }

        #endregion;

        public DataTable GetRoleById(int role_id, out string ErrorDescription)
        {
            ErrorDescription = String.Empty;
            try
            {
                return RoleDataAccess.GetRoleById(role_id);
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.dbaError;
                //Devolver objecto nulo
                return null;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.sqlError;
                //Devolver objecto nulo
                return null;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.appError;
                //Devolver objecto nulo
                return null;
            }
        }

        public int CreateRole(string roleName, out string ErrorDescription)
        {
            ErrorDescription = String.Empty;

            try
            {
                return RoleDataAccess.InsertRole(roleName);

            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.dbaError;
                //Devolver objecto nulo
                return -1;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.sqlError;
                //Devolver objecto nulo
                return -1;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.appError;
                //Devolver objecto nulo
                return -1;
            }
        }

        public DataView GetRoles(out string ErrorDescription)
        {
            ErrorDescription = String.Empty;
            DataView rolesDataView = new DataView();
            try
            {
                rolesDataView.Table = RoleDataAccess.GetRoles();
                return rolesDataView;
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.dbaError;
                //Devolver objecto nulo
                return null;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.sqlError;
                //Devolver objecto nulo
                return null;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.appError;
                //Devolver objecto nulo
                return null;
            }
        }

        public DataTable GetAllUsersRoles(out string ErrorDescription)
        {
            ErrorDescription = String.Empty;

            try
            {
                return UserDataAccess.GetUserRole();
            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.dbaError;
                //Devolver objecto nulo
                return null;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.sqlError;
                //Devolver objecto nulo
                return null;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação
                //Definir a mensagem de erro a partir do GlobalResources
                ErrorDescription = Resources.ErrorMessages.appError;
                //Devolver objecto nulo
                return null;
            }
        }

        public int AddUserToRole(int user_id, int role_id, out string ErrorDescription)
        {
            throw new NotImplementedException();

            //ErrorDescription = String.Empty;

            //try
            //{
            //    return UserDataAccess.InsertUserRole(user_id, role_id);
            //}
            //catch (DataException)
            //{//Apanhar excepção de ACESSO à base de dados
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.dbaError;
            //    //Devolver objecto nulo
            //    return -1;
            //}
            //catch (System.Data.SqlClient.SqlException)
            //{//Apanhar excepção de erro no SERVIDOR da base de dados
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.sqlError;
            //    //Devolver objecto nulo
            //    return -1;
            //}
            //catch (Exception)
            //{//Apanhar excepção da própria applicação
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.appError;
            //    //Devolver objecto nulo
            //    return -1;
            //}

        }

        public int DeleteUsersFromRoles(string[] usernames, string[] rolesname, out string ErrorDescription)
        {
            throw new NotImplementedException();

            //ErrorDescription = String.Empty;

            //try
            //{
            //    return UserDataAccess.DeleteUsersRoles(usernames, rolesname);
            //}
            //catch (DataException)
            //{//Apanhar excepção de ACESSO à base de dados
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.dbaError;
            //    //Devolver objecto nulo
            //    return -1;
            //}
            //catch (System.Data.SqlClient.SqlException)
            //{//Apanhar excepção de erro no SERVIDOR da base de dados
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.sqlError;
            //    //Devolver objecto nulo
            //    return -1;
            //}
            //catch (Exception)
            //{//Apanhar excepção da própria applicação
            //    //Definir a mensagem de erro a partir do GlobalResources
            //    ErrorDescription = Resources.ErrorMessages.appError;
            //    //Devolver objecto nulo
            //    return -1;
            //}
        }
    }
}