using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using ClaseBase;
using System.Collections.ObjectModel;

namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for OrdenatedList.xaml
    /// </summary>
    public partial class OrdenatedList : UserControl
    {

        int idModificar = 0;

        public OrdenatedList()
        {
            InitializeComponent();
            DataContext = this; // Establecemos el DataContext para las vinculaciones
          
            loadUsers(); // Cargar usuarios
           
        }

        public void loadUsers()
        {
            DataTable users = ClaseBase.TrabajarUsuario.listUsuarios();
            dataGridUsuarios.ItemsSource = users.DefaultView;
            
        }

       


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = cargarUsuario(usuario);

            if (ValidarUsuario(usuario)) //TODO
            {
                WindowUtil.customMessage("Por favor, completa todos los campos obligatorios correctamente.");
                return;
            }
            if (WindowUtil.messageYesNo("¿Seguro que quieres guardar al Atleta?"))
            {
                ClaseBase.TrabajarUsuario.addUsuario(usuario);
                loadUsers();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (idModificar == 0)
            {
                WindowUtil.customMessage("Por favor, Selecciona un usuario a eliminar");
                return;
            }
            if (WindowUtil.messageYesNo("¿Seguro que quieres ELIMINAR al usuario?"))
            {
                ClaseBase.TrabajarUsuario.deleteUsuario(idModificar);
                loadUsers();
                idModificar = 0;
                cleanup();
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidarUsuario(Usuario usuario)
        {
            if (txtNickname.Text == null)
                return true;
            if (txtNombreCompleto.Text == null)
                return true;
            if (txtRol.SelectedValue.ToString() == null)
                return true;
            if (txtPassword.Text == null)
                return true;
            return false;
           
        }

        private Usuario cargarUsuario(Usuario usuario)
        {
            usuario.Nickname = txtNickname.Text;
            usuario.NombreCompleto = txtNombreCompleto.Text;
            usuario.Password = txtPassword.Text;
            usuario.Rol = new Rol();
            usuario.Rol.Codigo = int.Parse(txtRol.SelectedValue.ToString());
            return usuario;
        }

        public bool isNumber(String number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void dataGridUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUsuarios.SelectedItem != null)
            {
                // Obtener la fila seleccionada como un DataRowView
                DataRowView rowView = (DataRowView)dataGridUsuarios.SelectedItem;

                // Asignar los valores de la fila seleccionada a los controles
                idModificar = int.Parse(rowView["Id"].ToString());
                txtNickname.Text = rowView["nickname"].ToString();
                txtPassword.Text = rowView["apellidos_nombres"].ToString();  // Supongo que apellidos_nombres es lo que quieres mostrar en el campo Password
                txtNombreCompleto.Text = rowView["apellidos_nombres"].ToString(); // Puede que quieras cambiar esta asignación
                txtRol.SelectedValue = rowView["rol_codigo"].ToString();
            }
        }

        public void cleanup()
        {
            txtNickname.Text = null;
            txtNombreCompleto.Text = null;
            txtPassword.Text = null;
            txtRol.SelectedValue = null;
          
        }

    }
}
