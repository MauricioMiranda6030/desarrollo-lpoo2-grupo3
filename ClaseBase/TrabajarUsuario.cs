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


        public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();
            Rol oRol_Admin = new Rol(1, "admin");
            Rol oRol_Op = new Rol(1, "operador");
            listaUsuario.Add(new Usuario("rocio", "Rocio Guerrero", oRol_Admin));
            listaUsuario.Add(new Usuario("nico", "Nicolás Velazco", oRol_Op));
            return listaUsuario;
        }

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
                    // Crear instancia de Usuario y asignar propiedades
                    Usuario oUsuario = new Usuario();
                    oUsuario.Id = Convert.ToInt32(row["id"]);
                    oUsuario.Nickname = row["nickname"].ToString();
                    oUsuario.NombreCompleto = row["apellidos_nombres"].ToString();
                    oUsuario.Password = row["password"].ToString();

                    // Obtener el RolCodigo y asignar el Rol correspondiente
                    int rolCodigo = Convert.ToInt32(row["rol_codigo"]);
                    //Rol oRol;

                    // Asignar el rol correspondiente
                    /*switch (rolCodigo)
                    {
                        case 1:
                            oRol = new Rol(1, "admin");
                            break;
                        case 2:
                            oRol = new Rol(2, "operador");
                            break;
                        case 3:
                            oRol = new Rol(3, "auditor");
                            break;
                        default:
                            oRol = new Rol(0, "desconocido"); // Rol por defecto en caso de que no coincida con ninguno
                            break;
                    }

                    oUsuario.Rol = oRol;*/
                    oUsuario.Rol = Util.getRol(rolCodigo);

                    // Agregar el usuario a la colección
                    usuarios.Add(oUsuario);
                }
            }

            return usuarios;
        }

        // Método para obtener un usuario por ID
        public static Usuario GetUsuarioById(int id)
        {
            Usuario usuario = null;
            string consulta = @"SELECT id, nickname, password, apellidos_nombres, rol_codigo
                            FROM Usuario WHERE id = @id";

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
                            usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nickname = reader["nickname"].ToString(),
                                Password = reader["password"].ToString(),
                                NombreCompleto = reader["apellidos_nombres"].ToString(),
                                // Puedes convertir RolCodigo a un objeto Rol si es necesario
                            };
                        }
                    }
                }
            }

            return usuario;
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
            string consulta = @"SELECT Id, nickname, apellidos_nombres, rol_codigo 
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

        // Método para actualizar un usuario existente
        public static void updateUsuario(Usuario usuario)
        {
            string query = @"UPDATE Usuario 
                         SET nickname = @Nickname, 
                             password = @Password, 
                             apellidos_nombres = @NombreCompleto, 
                             rol_codigo = @RolCodigo 
                         WHERE Id = @Id";

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Nickname", usuario.Nickname);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@RolCodigo", usuario.Rol);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);

                cnn.Open();
                cmd.ExecuteNonQuery();
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


        public static DataTable GetRoles()
        {
            string query = "SELECT codigo, descripcion FROM Rol";
            DataTable rolesTable = new DataTable();

            using (SqlConnection cnn = new SqlConnection(s_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(rolesTable); // Llenar el DataTable con los resultados de la consulta
            }

            return rolesTable; // Devolver el DataTable con los roles
        }

        public static Rol getRolById(int id)
        {
            Rol rol = null;
            string consulta = @"SELECT id, nickname, password, apellidos_nombres, rol_codigo 
                            FROM Usuario WHERE Id = @id";

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
                            rol = new Rol
                            {
                                Codigo = Convert.ToInt32(reader["codigo"]),
                                Descripcion = reader["descripcion"].ToString(),

                            };
                        }
                    }
                }

                return rol;
            }



            /*public ObservableCollection<Usuario> obtenerUsuarios()
            {
                SqlConnection cnn = new SqlConnection("Data Source=.'\'SQLEXPRESS;AttachDbFilename=E:'\'dev'\'lpoo2'\'LPOOIIGrupo03'\'comdep.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                ObservableCollection<Usuario> usuario = new ObservableCollection<Usuario>();
                foreach (DataRow row in dt.Rows)
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Id = Convert.ToInt32(row["Id"].ToString());
                    oUsuario.Nickname = row["Apellido"].ToString();
                    oUsuario.NombreCompleto = row["NombreCompleto"].ToString();
                    oUsuario.Password = row["Password"].ToString();
                    //oUsuario.rol = (int)row["RolCodigo"];

                    usuario.Add(oUsuario);
                }
                return usuario;
            }*/
        }


    }
}