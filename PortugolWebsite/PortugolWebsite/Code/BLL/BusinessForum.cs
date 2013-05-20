using PortugolWebsite.Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortugolWebsite.Code.BLL
{
    public static class BusinessForum
    {
        public static DataView GetTopics(int? Id = null, string Title = "")
        {

            try
            {
                //Aceder à base de dados para retornar os registos dos utilizadores consoante os filtros aplicados
                DataTable dataTable = ForumDataAccess.GetTopics(Id, Title);

                //Verifica se existem registos
                if (dataTable.Rows.Count > 0)
                {//registos encontrados

                    return new DataView(dataTable);

                }
                else
                {
                    //Sair do método
                    return null;
                }
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