﻿using InitialProject.View.OwnerView;
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

namespace InitialProject.View.OwnerWindows
{
    /// <summary>
    /// Interaction logic for OwnerMainWindow.xaml
    /// </summary>
    public partial class OwnerMainWindow : Window
    {
        public OwnerMainWindow()
        {
            InitializeComponent();
            
        }

        private void MyAppartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationOverviewWindow AccommodationOverview = new AccommodationOverviewWindow();
            AccommodationOverview.Show();
        }



        private void GuestReviewsButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}