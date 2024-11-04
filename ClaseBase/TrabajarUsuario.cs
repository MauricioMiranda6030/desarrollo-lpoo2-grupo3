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
