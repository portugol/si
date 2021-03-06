using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;


public partial class Teste : System.Web.UI.Page
{
    public string data;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string novadatafim()
    {
        string strConn_Access = ConfigurationManager.ConnectionStrings["ConnectionString_Listar"].ConnectionString;

        MySqlConnection MyConn = new MySqlConnection(strConn_Access);


        string sqlString = "Select Data_Fim from tipo_teste  WHERE Id = @Data;";

        MySqlCommand Cmd = new MySqlCommand(sqlString, MyConn);

        Int32 numero = (Convert.ToInt32(lbl_idDescricao.Text));

        Cmd.Parameters.AddWithValue("@Data", numero);

        try
        {
            MyConn.Open();


            data = (Cmd.ExecuteScalar().ToString());

        }
        catch (Exception ex)
        {

        }
        finally
        {
            MyConn.Close();
        }
        return data.Substring(0, 10);  //tira os caracteres a mais 00:00:00    
    }

    private string novadata()
    {

        string strConn_Access = ConfigurationManager.ConnectionStrings["ConnectionString_Listar"].ConnectionString;

        MySqlConnection MyConn = new MySqlConnection(strConn_Access);


        string sqlString = "Select Data_Inicio from tipo_teste  WHERE Id = @Data;";

        //datafim

        MySqlCommand Cmd = new MySqlCommand(sqlString, MyConn);

        Int32 numero = (Convert.ToInt32(lbl_idDescricao.Text));

        Cmd.Parameters.AddWithValue("@Data", numero);

        try
        {
            MyConn.Open();

            data = (Cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {

        }
        finally
        {
            MyConn.Close();
        }
        return data.Substring(0, 10);  //tira os caracteres a mais 00:00:00
    }

    protected void bt_GeraTeste_Click(object sender, EventArgs e)
    {
        for (int j=0; j < Convert.ToInt32(txt_Numtestes.Text); j++)
        {

            string strConn_Access = ConfigurationManager.ConnectionStrings["ConnectionString_Listar"].ConnectionString;

            MySqlConnection MyConn = new MySqlConnection(strConn_Access);

            MySqlCommand Cmd = new MySqlCommand(strConn_Access, MyConn);

            MySqlCommand sqlCommand = new MySqlCommand("SELECT perguntas.Pergunta FROM perguntas, enunciados WHERE perguntas.Dificuldade = enunciados.Dificuldade AND perguntas.CapituloId = enunciados.Capitulo order by Rand()  LIMIT " + Convert.ToInt32(txt_nperg.Text) + "", MyConn);


            string html = Server.MapPath(Request.ApplicationPath) + "\\Teste.HTML";
            System.IO.StreamWriter file = new System.IO.StreamWriter(html);
            string pdf = Server.MapPath(Request.ApplicationPath) + "\\Teste"+ j +".Pdf";

            try
            {
                MyConn.Open();

                MySqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        file.WriteLine(reader[i] + "\n");
                    }
                }

                file.Close();

                DuoDimension.HtmlToPdf conv = new DuoDimension.HtmlToPdf();
                conv.OpenHTML(html);
                conv.SavePDF(pdf);


            }
            catch (Exception ex)
            {

            }

            finally { MyConn.Close(); }
        }
    }

    protected void Drop_Descricao_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_idDescricao.Text = Drop_Descricao.SelectedItem.Value;
        Int32 idtipo = Int32.Parse(lbl_idDescricao.Text);

        lbl_DataInicio.Text = novadata();

        lbl_DataFim.Text = novadatafim();

        string strConn_Access = ConfigurationManager.ConnectionStrings["ConnectionString_Listar"].ConnectionString;

        MySqlConnection MyConn = new MySqlConnection(strConn_Access);


        string sqlString = "SELECT * FROM enunciados WHERE Id_Tipoteste = " + lbl_idDescricao.Text;

        SqlDataSource_Enunciado.SelectCommand = sqlString;

        MySqlCommand Cmd = new MySqlCommand(sqlString, MyConn);

        Grdv_Enunciado.Visible = true;

        try
        {
            MyConn.Open();

            Cmd.ExecuteNonQuery();

            MyConn.Close();

            Grdv_Enunciado.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Drop_Capitulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_cap.Text = Drop_Capitulo.SelectedItem.Value;
    }

    protected void Drop_Dificuldade_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_dif.Text = Drop_Dificuldade.SelectedItem.Value;
    }

    protected void bt_Adicionar_Click(object sender, EventArgs e)
    {

        string strConn_Access = ConfigurationManager.ConnectionStrings["ConnectionString_Listar"].ConnectionString;

        MySqlConnection MyConn = new MySqlConnection(strConn_Access);

        string sqlString = "INSERT INTO enunciados " +
                "(Capitulo, Dificuldade, Num_Perguntas, Id_Tipoteste) " +
                "VALUES (@Capitulo, @Dificuldade, @Num_Perguntas, @Id_Tipoteste);";


        MySqlCommand Cmd = new MySqlCommand(sqlString, MyConn);

        Cmd.Parameters.AddWithValue("@Capitulo", lbl_cap.Text);
        Cmd.Parameters.AddWithValue("@Dificuldade", lbl_dif.Text);
        Cmd.Parameters.AddWithValue("@Num_Perguntas", txt_nperg.Text);
        Cmd.Parameters.AddWithValue("@Id_Tipoteste", lbl_idDescricao.Text);


        try
        {
            MyConn.Open();

            Cmd.ExecuteNonQuery();

            MyConn.Close();

            lbl_erro.Text = "Dados introduzidos com sucesso!";
            lbl_erro.Visible = true;

        }
        catch (Exception ex)
        {
            lbl_erro.Text = "Houve um erro na introdução dos dados";
            lbl_erro.Visible = true;
        }


        string sqlString2 = "SELECT * FROM enunciados WHERE Id_Tipoteste = " + lbl_idDescricao.Text;

        SqlDataSource_Enunciado.SelectCommand = sqlString2;

        Cmd = new MySqlCommand(sqlString2, MyConn);

        Grdv_Enunciado.Visible = true;

        try
        {
            MyConn.Open();

            Cmd.ExecuteNonQuery();

            MyConn.Close();

            Grdv_Enunciado.DataBind();
        }
        catch (Exception ex)
        {

        }

        Drop_Capitulo.SelectedValue = "0";
        Drop_Dificuldade.SelectedValue = "0";
        txt_nperg.Text = " ";
    }

}