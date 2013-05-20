using PortugolWebsite.Code.DAL;
using System;
using System.Data;

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

        public static DataView GetTopicThreads(int? topic_Id = null, string order = "Asc")
        {

            try
            {
                //Aceder à base de dados para retornar os registos dos utilizadores consoante os filtros aplicados
                DataTable dataTable = ForumDataAccess.GetTopicThreads(topic_Id, order);

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

        public static bool InsertThread(int topic_Id, string subject, string post, int utilizador_id)
        {

            try
            {
                int affectedRows = ForumDataAccess.InsertThread(topic_Id, subject, post, utilizador_id);
                if (affectedRows > 0)
                    return true;
                else
                    return false;

            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados

                //Devolver objecto nulo
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados
              
                //Devolver objecto nulo
                return false;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação

                //Devolver objecto nulo
                return false;
            }
        }

        public static bool UpdateThread(int thread_Id, string subject, string post)
        {

            try
            {
                int affectedRows = ForumDataAccess.UpdateThread(thread_Id, subject, post);
                if (affectedRows > 0)
                    return true;
                else
                    return false;

            }
            catch (DataException)
            {//Apanhar excepção de ACESSO à base de dados

                //Devolver objecto nulo
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {//Apanhar excepção de erro no SERVIDOR da base de dados

                //Devolver objecto nulo
                return false;
            }
            catch (Exception)
            {//Apanhar excepção da própria applicação

                //Devolver objecto nulo
                return false;
            }
        }

    }
}