using System;
using System.Text;

namespace PortugolWebsite.Code.DAL.Queries
{
    public static class IdiomaQueries
    {
        /// <summary>
        /// SQL query to select Languages
        /// </summary>
        /// <param name="Id">Language unique identifier</param>
        /// <param name="Lingua">Language name</param>
        /// <returns>SQL query string</returns>
        public static string SelectIdioma(int? Id = null, string Lingua = "")
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT IdLingua, Lingua ");
            strQuery.Append(" FROM lingua ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (Id != null)
                strQuery.Append(" and IdLingua = " + Convert.ToString(Id));
            if (!string.IsNullOrEmpty(Lingua))
                strQuery.Append(" and Lingua = '" + Lingua + "'");

            return strQuery.ToString();

        }
    }
}