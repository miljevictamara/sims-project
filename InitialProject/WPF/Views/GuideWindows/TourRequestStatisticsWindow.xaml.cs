﻿using InitialProject.WPF.ViewModels.GuideViewModels;
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
    /// Interaction logic for TourRequestStatisticsWindow.xaml
    /// </summary>
    public partial class TourRequestStatisticsWindow : Page
    {
        public TourRequestStatisticsWindow(NavigationService navigationService)
        {
            InitializeComponent();
            TourRequestStatisticsViewModel TourRequestStatisticsViewModel = new TourRequestStatisticsViewModel(navigationService);
            this.DataContext = TourRequestStatisticsViewModel;

        }

       
    }
}