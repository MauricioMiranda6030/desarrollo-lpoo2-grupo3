using System;
using System.Linq;
using System.Text;
using System.Data;
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

        public static void addAtleta(Atleta atleta)
        {
            // Crear conexión
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString);

            // Crear consulta SQL para insertar datos
            string query = "INSERT INTO Atleta (dni, apellido, nombre, nacionalidad, entrenador, genero, altura, peso, fecha_nacimiento, direccion, correo) " +
                           "VALUES (@DNI, @Apellido, @Nombre, @Nacionalidad, @Entrenador, @Genero, @Altura, @Peso, @FechaNacimiento, @Direccion, @Correo)";

            // Crear el comando SQL con la consulta
            SqlCommand cmd = new SqlCommand(query, cnn);

            // Agregar parámetros con los valores del objeto Atleta
            cmd.Parameters.AddWithValue("@DNI", atleta.DNI);
            cmd.Parameters.AddWithValue("@Apellido", atleta.Apellido);
            cmd.Parameters.AddWithValue("@Nombre", atleta.Nombre);
            cmd.Parameters.AddWithValue("@Nacionalidad", atleta.Nacionalidad);
            cmd.Parameters.AddWithValue("@Entrenador", atleta.Entrenador);
            cmd.Parameters.AddWithValue("@Genero", atleta.Genero);
            cmd.Parameters.AddWithValue("@Altura", atleta.Altura);
            cmd.Parameters.AddWithValue("@Peso", atleta.Peso);
            cmd.Parameters.AddWithValue("@FechaNacimiento", atleta.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion", atleta.Direccion);
            cmd.Parameters.AddWithValue("@Correo", atleta.Email);

            // Abrir conexión, ejecutar comando y cerrar conexión
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable listAtletas()
        {
            // Consulta SQL para obtener los datos de la tabla Atleta
            string consulta = @"SELECT Id AS ID, dni AS 'DNI', apellido AS 'Apellido', nombre AS 'Nombre', nacionalidad AS 'Nacionalidad', 
                        entrenador AS 'Entrenador', genero AS 'Genero', altura AS 'Altura', peso AS 'Peso', 
                        fecha_nacimiento AS 'Fecha de Nacimiento', direccion AS 'Dirección', correo AS 'Correo'
                        FROM Atleta";

            // Crear la conexión SQL
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString);

            // Crear el comando SQL con la consulta
            SqlCommand cmd = new SqlCommand(consulta, cnn);

            // Adaptador para llenar el DataTable con los resultados
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // DataTable para almacenar los datos obtenidos
            DataTable dt = new DataTable();

            // Llenar el DataTable con los datos de la consulta
            da.Fill(dt);

            // Retornar el DataTable con los datos
            return dt;
        }



    }
}
