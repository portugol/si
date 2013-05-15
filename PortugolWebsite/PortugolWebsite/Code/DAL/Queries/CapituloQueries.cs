using System;
using System.Text;

namespace PortugolWebsite.Code.DAL.Queries
{
    public static class CapituloQueries
    {
        public static string SelectCapitulo(int? Id = null, string Nome = "")
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT Id, Nome, Descricao ");
            strQuery.Append(" FROM capitulo ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (Id != null)
                strQuery.Append(" and Id = " + Convert.ToString(Id));
            if (!string.IsNullOrEmpty(Nome))
                strQuery.Append(" and Nome = '" + Nome + "'");

            return strQuery.ToString();

        }

        public static string SelectPerguntas(int? Id = null, string Pergunta = "")
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" SELECT Id, Pergunta, Dificuldade ");
            strQuery.Append(" FROM perguntas ");
            strQuery.Append(" WHERE 1 = 1 ");

            if (Id != null)
                strQuery.Append(" and Id = " + Convert.ToString(Id));
            if (!string.IsNullOrEmpty(Pergunta))
                strQuery.Append(" and Pergunta = '" + Pergunta + "'");

            return strQuery.ToString();

        }
    }
}