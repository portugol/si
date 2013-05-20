﻿using PortugolWebsite.Code.DAL.Queries;
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

        #endregion
    }
}