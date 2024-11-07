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
    }
}
