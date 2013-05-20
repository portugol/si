using PortugolWebsite.Code.DAL.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortugolWebsite.Code.DAL
{
    public static class ForumDataAccess
    {
        #region DataBase information retrieval

        /// <summary>
        /// Consulta a base de dados e devolve os tópicos do Forum
        /// </summary>
        /// <param name="id">Identificador único do tópico</param>
        /// <param name="title">Titulo do tópico</param>
        /// <returns>ADO.NET DataTable</returns>
        public static DataTable GetTopics(int? id = null, string title = "")
        {
            //Obter o comando SQL
            string sqlQuery = ForumQueries.SelectTopic(id, title);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);

        }

        /// <summary>
        /// Consulta a base de dados e devolve as threads dos tópicos do Forum
        /// </summary>
        /// <param name="topic_Id">Identificador único do tópico</param>
        /// <returns>ADO.NET DataTable</returns>
        public static DataTable GetTopicThreads(int? topic_Id = null, string order = "Asc")
        {
            //Obter o comando SQL
            string sqlQuery = ForumQueries.SelectTopicThreads(topic_Id, order);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);

        }

        public static int InsertThread(int topic_Id, string subject, string post, int utilizador_id)
        {
            //Obter o comando SQL
            string sqlQuery = ForumQueries.InsertThread(topic_Id, subject, post, utilizador_id);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }

        public static int UpdateThread(int thread_id, string subject, string post)
        {
            //Obter o comando SQL
            string sqlQuery = ForumQueries.UpdateThread(thread_id, subject, post);
            //Executar o comando e devolver o número de registos afectados pela operação
            return DataAccessLayer.ExecuteNonQuery(sqlQuery);
        }

        #endregion
    }
}