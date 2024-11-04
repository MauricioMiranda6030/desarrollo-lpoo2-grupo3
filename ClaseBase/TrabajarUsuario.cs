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
                //oUsuario.RolCodigo = (int)row["RolCodigo"];

                usuario.Add(oUsuario);
            }
            return usuario;
        }
    }
}
