﻿using System;
using System.Text;

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

        public static string SelectTopicThreads(int? topic_Id = null, string order = "Desc")
        {
            
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT Title, Description, forumThreads.Id, RelTopId, Subject, Post, Date, RelBcId, LastUpdate, forumThreads.UtilizadoresId, Username ");
            strQuery.Append(" FROM forumThreads inner join utilizadores on forumThreads.UtilizadoresId=utilizadores.Id ");
            strQuery.Append("   inner join forumTopics on  forumThreads.RelTopId = forumTopics.Id");

            strQuery.Append(" WHERE 1 = 1 ");

            if (topic_Id != null)
                strQuery.Append(" and forumTopics.Id = " + Convert.ToString(topic_Id));


            strQuery.Append(" ORDER BY LastUpdate " + order);

            return strQuery.ToString();
        }

        public static string InsertTopic(string title, string description, int utilizador_id)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" INSERT INTO forumTopics (Title, Description, UtilizadoresId)");
            strQuery.Append(" VALUES('" + title + "', '" + description + "', " + utilizador_id.ToString() + " ) ");

            return strQuery.ToString();
        }

        public static string InsertThread(int topic_Id, string subject, string post, int utilizador_id)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" INSERT INTO forumThreads (RelTopId, Subject, Post, Date, LastUpdate, UtilizadoresId)");
            strQuery.Append(" VALUES(" + topic_Id.ToString() + ", '" + subject + "', '" + post + "', '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', " + utilizador_id .ToString() + " ) ");

            return strQuery.ToString();
        }

        public static string UpdateThread(int thread_id, string subject, string post) 
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" UPDATE forumThreads SET ");
            strQuery.Append(" Subject = ''" + subject + "', ");
            strQuery.Append(" Post = '" + post + "', " );
            strQuery.Append(" LastUpdate = '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
            strQuery.Append(" WHERE Id = " + thread_id.ToString());
            

            return strQuery.ToString();

        
        }

        



    }
}