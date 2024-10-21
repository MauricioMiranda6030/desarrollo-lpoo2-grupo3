using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class TrabajarDisciplina
    {
        /**
         * Lista todas las disciplinas
         * */
        public static DataTable getAllDisciplines()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT id AS ID, nombre AS Nombre, descripcion AS Descripcion FROM Disciplina";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
