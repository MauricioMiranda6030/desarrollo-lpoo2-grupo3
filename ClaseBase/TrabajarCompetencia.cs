using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class TrabajarCompetencia
    {
        /**
         * Agrega una competencia
         * */
        public static void addCompetence(Competencia competence)
        {
            string query= @"INSERT INTO Competencia(nombre, descripcion, fecha_inicio, fecha_fin, estado, organizador, sponsor, ubicacion, id_categoria, id_disciplina) VALUES(@nom, @desc, @fechaini, @fechafin, @estad, @organ, @spons, @ubi, @cat, @dis)";
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString);
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@nom", competence.Name);
            cmd.Parameters.AddWithValue("@desc", competence.Description);
            cmd.Parameters.AddWithValue("@fechaini", competence.InitialDate);
            cmd.Parameters.AddWithValue("@fechafin", competence.FinalDate);
            cmd.Parameters.AddWithValue("@estad", competence.State);
            cmd.Parameters.AddWithValue("@organ", competence.Organizer);
            cmd.Parameters.AddWithValue("@spons", competence.Sponsors);
            cmd.Parameters.AddWithValue("@ubi", competence.Location);
            cmd.Parameters.AddWithValue("@cat", competence.CategoryId);
            cmd.Parameters.AddWithValue("@dis", competence.DiciplineId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /**
         * Lista las competencias
         * */
        public static DataTable listCompetence()
        {
            string consulta = @"SELECT nombre AS 'Nombre', descripcion AS 'Descripcion', fecha_inicio AS 'Fecha Inicio', fecha_fin AS 'Fecha Fin',
            estado AS 'Estado', organizador AS 'Organizador', sponsor AS 'Sponsor', ubicacion AS 'Ubicacion' FROM Competencia";
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString);
            SqlCommand cmd = new SqlCommand(consulta, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
