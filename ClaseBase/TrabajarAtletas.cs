using System;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class TrabajarAtletas
    {
        static readonly string s_connectionString = ClaseBase.Properties.Settings.Default.comdepConnectionString;

        public static Atleta GetAtletaById(int id)
        {
            Atleta atleta = null;
            string consulta = @"SELECT dni AS 'DNI', apellido AS 'Apellido', nombre AS 'Nombre', 
                        nacionalidad AS 'Nacionalidad', entrenador AS 'Entrenador', 
                        genero AS 'Genero', altura AS 'Altura', peso AS 'Peso', 
                        fecha_nacimiento AS 'FechaNacimiento', direccion AS 'Direccion', 
                        correo AS 'Email' 
                        FROM Atleta WHERE id = @id";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cnn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            atleta = new Atleta
                            {
                                DNI = reader["DNI"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Nacionalidad = reader["Nacionalidad"].ToString(),
                                Entrenador = reader["Entrenador"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                Altura = Convert.ToDouble(reader["Altura"]),
                                Peso = Convert.ToDouble(reader["Peso"]),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                Direccion = reader["Direccion"].ToString(),
                                Email = reader["Email"].ToString(),
                                Id = id
                            };
                        }
                    }

                }
            }

            return atleta;
        }

    }
}
