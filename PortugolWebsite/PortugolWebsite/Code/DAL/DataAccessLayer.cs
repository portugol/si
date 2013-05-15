using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace PortugolWebsite.Code.DAL
{
    /// <summary>
    /// Data Access Layer class.
    /// Database handler class.
    /// </summary>
    public static class DataAccessLayer
    {
        private static readonly Database db = DatabaseFactory.CreateDatabase("Webconnection");

        private static DbTransaction trans;

        /// <summary>
        /// Execute a stored procedure in database
        /// </summary>
        /// <param name="procedureName">Procedure's name</param>
        /// <param name="sqlParameters">Procedure's parameters list</param>
        /// <returns>Number of affected rows</returns>
        public static int CallStoredProcedure(string procedureName, DbParameter[] sqlParameters)
        {

            DbCommand dbCommand = db.GetStoredProcCommand(procedureName);

            dbCommand.Parameters.AddRange(sqlParameters);

            return db.ExecuteNonQuery(dbCommand); //returns the numbers of rows affected by the the CallStoredProcedure procedure

        }

        /// <summary>
        /// Gets a query results into an ADO.NET data set
        /// </summary>
        /// <param name="sqlQuery">sql query command</param>
        /// <returns>ADO.NET Data Set</returns>
        public static DataSet GetDataSet(string sqlQuery)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            return db.ExecuteDataSet(dbCommand); //returns the results to a newly created DataSet.
        }

        /// <summary>
        /// Gets a query result into an ADO.NET data table
        /// </summary>
        /// <param name="sqlQuery">sql query command</param>
        /// <returns>ADO.NET Data Table</returns>
        public static DataTable GetDataTable(string sqlQuery)
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            ds = db.ExecuteDataSet(dbCommand);

            return ds.Tables[0]; //returns the results to a newly created DataTable.
        }

        /// <summary>
        /// Gets a query single value
        /// </summary>
        /// <param name="sqlQuery">sql query command</param>
        /// <returns>Single  value object</returns>
        public static object GetScalar(string sqlQuery)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            return db.ExecuteScalar(dbCommand); //returns the first row's first column's value
        }

        /// <summary>
        /// Executes a non query SQL command.
        /// </summary>
        /// <param name="sqlNonQuery">sql query command</param>
        /// <returns>Number of affected rows</returns>
        public static int ExecuteNonQuery(string sqlNonQuery)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlNonQuery);

            return db.ExecuteNonQuery(dbCommand); //returns the numbers of rows affected
        }

        /// <summary>
        /// Starts a database transaction. 
        /// </summary>
        public static void TransactionStart()
        {
            DbConnection conn = db.CreateConnection();
            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// Stops a database transaction
        /// </summary>
        /// <param name="commit">True to commit changes, false to rollback changes</param>
        public static void TransactionStop(bool commit)
        {
            if (commit)
                trans.Commit();
            else
                trans.Rollback();

            trans.Connection.Close();
        }

        /// <summary>
        /// Executes a non query command associated with a transaction
        /// </summary>
        /// <param name="sqlNonQuery">SQl non query command</param>
        /// <returns>Number of affected rows</returns>
        public static int TransactionExecuteNonQuery(string sqlNonQuery)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlNonQuery);

            return db.ExecuteNonQuery(dbCommand, trans); //returns the numbers of rows affected

        }

        /// <summary>
        /// Gets a query result, associated with a transaction, into an ADO.NET data table
        /// </summary>
        /// <param name="sqlQuery">sql query command</param>
        /// <returns>ADO.NET Data Table</returns>
        public static DataTable TransactionGetDataTable(string sqlQuery)
        {
            DataSet ds = new DataSet();
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            ds = db.ExecuteDataSet(dbCommand, trans);

            return ds.Tables[0]; //returns the results to a newly created DataTable.

        }

        /// <summary>
        /// Gets a query single value associated with a transaction
        /// </summary>
        /// <param name="sqlQuery">sql query command</param>
        /// <returns>Single  value object</returns>
        public static object TransactionGetScalar(string sqlQuery)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);
            return db.ExecuteScalar(dbCommand, trans); //returns the first row's first column's value
        }
    }
}