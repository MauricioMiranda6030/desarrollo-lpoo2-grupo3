﻿using System;
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
using ClaseBase;
using System.Data;
using System.Data.SqlClient;

namespace Vistas.View
{
    /// <summary>
    /// Interaction logic for CompetenceView.xaml
    /// </summary>
    public partial class CompetenceView : UserControl
    {
        public CompetenceView()
        {
            InitializeComponent();
        }

        private void CompetenceView_Loaded(object sender, RoutedEventArgs e)
        {
            loadListDisciplines();
            loadListCategories();
            loadCompetence();
        }

        /**
         * Carga la lista de disciplina
         * */
        private void loadListDisciplines()
        {
            DataTable disciplinasTable = TrabajarDisciplina.getAllDisciplines();
            txtDisciplina.ItemsSource = disciplinasTable.DefaultView;
        }

        private void loadCompetence()
        {
            DataTable competences = TrabajarCompetencia.listCompetence();
            dataGridCompetencia.ItemsSource = competences.DefaultView;
        }

        /**
         * Carga la lista de categoria
         * */
        private void loadListCategories()
        {
            DataTable categoryTable = TrabajarCategoria.getAllCategory();
            txtCategoria.ItemsSource = categoryTable.DefaultView;
        }

        private Competencia saveCompetence()
        {
            Competencia oCompetence = new Competencia();
            oCompetence.Name = txtNombre.Text;
            oCompetence.Description = txtDescripcion.Text;
            oCompetence.InitialDate = txtFechaIni.SelectedDate.Value;
            oCompetence.FinalDate = txtFechaFin.SelectedDate.Value;
            oCompetence.State = txtEstado.Text;
            oCompetence.Organizer = txtOrganizador.Text;
            oCompetence.Sponsors = txtSponsors.Text;
            oCompetence.Location = txtUbicacion.Text;
            oCompetence.CategoryId = (int)txtCategoria.SelectedValue;
            oCompetence.DiciplineId = (int)txtDisciplina.SelectedValue;
            return oCompetence;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TrabajarCompetencia.addCompetence(saveCompetence());
            loadCompetence();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

    }
}