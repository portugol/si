using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PortugolWebsite.Code.DAL.Queries
{
    public static class ForumQueries
    {
        public static string SelectTopic(int? id = null, string title = "")
        {
            
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT Id, Left(Title, 100) As Title, Description, ");
            strQuery.Append(" (SELECT COUNT(*) FROM forumThreads WHERE RelTopId = forumTopics.Id ) as ThreadCount, ");
            strQuery.Append(" (SELECT LastUpdate FROM forumThreads WHERE RelTopId =forumTopics.Id order by LastUpdate desc limit 1) as LastPost ");

            strQuery.Append("  FROM forumTopics ");
            
            strQuery.Append(" WHERE 1 = 1 ");

            if (id != null)
                strQuery.Append(" and Id = " + Convert.ToString(id));
            if (!string.IsNullOrEmpty(title))
                strQuery.Append(" and Title Like '%" + title + "%' ");

            strQuery.Append(" ORDER BY Id DESC ");

            return strQuery.ToString();
        }
    }
}