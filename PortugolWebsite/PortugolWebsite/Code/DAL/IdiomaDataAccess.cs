using PortugolWebsite.Code.DAL.Queries;
using System.Data;

namespace PortugolWebsite.Code.DAL
{
    public static class IdiomaDataAccess
    {
        /// <summary>
        /// Consulta a base de dados e devolve os idiomas
        /// </summary>
        /// <param name="id">Identificador único do idioma</param>
        /// <param name="name">Nome do idioma</param>
        /// <returns>ADO.NET DataTable</returns>
        public static DataTable GetIdioma(int? id = null, string name = "")
        {
            //Obter o comando SQL
            string sqlQuery = IdiomaQueries.SelectIdioma(id, name);
            //Devolver o resultado da query num objecto DataTable
            return DataAccessLayer.GetDataTable(sqlQuery);

        }
    }
}