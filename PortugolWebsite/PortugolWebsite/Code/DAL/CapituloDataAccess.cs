using PortugolWebsite.Code.DAL.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortugolWebsite.Code.DAL
{
    public static class CapituloDataAccess
    {
        public static DataTable GetCapitulo(int? Id = null, string Nome = "")
        {
            //Obter o comando SQL
            string sqlQuery = CapituloQueries.SelectCapitulo(Id, Nome);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);

        }
    }
}