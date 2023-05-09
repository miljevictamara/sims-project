﻿using InitialProject.WPF.Views.Guest2Window;
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
using InitialProject.Domain.Models;
using System.ComponentModel;
using InitialProject.WPF.Views;
using InitialProject.WPF.ViewModels.Guest2ViewModels;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for Guest2MainWindow.xaml
    /// </summary>
    public partial class Guest2MainWindow : Window
    {
        public Guest2MainWindowViewModel _ViewModel { get; set; }    

        public Guest2MainWindow()
        {
            InitializeComponent();
            this._ViewModel = new Guest2MainWindowViewModel(this.frame.NavigationService);
            this.DataContext = this._ViewModel;


        }

    }
}
