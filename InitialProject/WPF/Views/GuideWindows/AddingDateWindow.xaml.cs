﻿using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.ViewModels.GuideViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for AddingDateWindow.xaml
    /// </summary>
    public partial class AddingDateWindow : Page
    {
        public NavigationService navigationService;
        public AddingDateWindow(TourRequest tourRequest)
        {
            InitializeComponent();
            AddingDateViewModel addingDateViewModel = new AddingDateViewModel(navigationService, tourRequest);
            this.DataContext = addingDateViewModel;


        }

        private void datePickerForEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datePickerForStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
