using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ClaseBase
{
    public class TrabajarUsuario
    {
        static readonly string s_connectionString = ClaseBase.Properties.Settings.Default.comdepConnectionString;

        /*public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();
            Rol oRol_Admin = new Rol(1, "admin");
            Rol oRol_Op = new Rol(1, "operador");
            listaUsuario.Add(new Usuario("rocio", "Rocio Guerrero", oRol_Admin));
            listaUsuario.Add(new Usuario("nico", "Nicolás Velazco", oRol_Op));
            return listaUsuario;
        }*/

        public ObservableCollection<Usuario> obtenerUsuarios()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            // Usar la cadena de conexión desde el archivo de configuración
            using (SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Id = Convert.ToInt32(row["id"]);
                    oUsuario.Nickname = row["nickname"].ToString();
                    oUsuario.NombreCompleto = row["apellidos_nombres"].ToString();
                    oUsuario.Password = row["password"].ToString();
                    int rolCodigo = Convert.ToInt32(row["rol_codigo"]);
                    oUsuario.Rol = Util.getRol(rolCodigo);
                    usuarios.Add(oUsuario);
                }
            }

            return usuarios;
        }

        public ObservableCollection<Usuario> getUserOrder()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            // Usar la cadena de conexión desde el archivo de configuración
            using (SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.comdepConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario ORDER BY nickname ASC", cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Id = Convert.ToInt32(row["id"]);
                    oUsuario.Nickname = row["nickname"].ToString();
                    oUsuario.NombreCompleto = row["apellidos_nombres"].ToString();
                    oUsuario.Password = row["password"].ToString();
                    int rolCodigo = Convert.ToInt32(row["rol_codigo"]);
                    oUsuario.Rol = Util.getRol(rolCodigo);
                    usuarios.Add(oUsuario);
                }
            }
            return usuarios;
        }

        // Método para agregar un nuevo usuario
        public static void addUsuario(Usuario usuario)
        {
            string query = @"INSERT INTO Usuario (nickname, password, apellidos_nombres, rol_codigo) 
                         VALUES (@Nickname, @Password, @NombreCompleto, @RolCodigo)";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Nickname", usuario.Nickname);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@RolCodigo", usuario.Rol.Codigo);
                // Asegúrate de tener la propiedad `Codigo` en `Rol`

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para listar todos los usuarios en un DataTable
        public static DataTable listUsuarios()
        {
            string consulta = @"SELECT Id, nickname, password, apellidos_nombres, rol_codigo 
                            FROM Usuario";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(consulta, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método para eliminar un usuario por ID
        public static void deleteUsuario(int id)
        {
            string query = @"DELETE FROM Usuario WHERE id = @Id";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para actualizar un usuario existente
        public static void updateUsuario(Usuario usuario)
        {
            string query = @"UPDATE Usuario 
                         SET nickname = @Nickname, 
                             password = @Password, 
                             apellidos_nombres = @NombreCompleto, 
                             rol_codigo = @RolCodigo 
                         WHERE id = @Id";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Nickname", usuario.Nickname);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@RolCodigo", usuario.Rol.Codigo);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
