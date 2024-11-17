﻿using GestorArchivos.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorArchivos.Views
{
    /// <summary>
    /// Lógica de interacción para CrearView.xaml
    /// </summary>
    public partial class CrearView : Window
    {
        public string ruta;
        public CrearView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<CrearViewModel>();
        }
    }
}
