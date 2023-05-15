﻿using InitialProject.Domain.Models;
using InitialProject.WPF.ViewModels;
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

namespace InitialProject.WPF.Views.OwnerWindows
{
    /// <summary>
    /// Interaction logic for AccommodationRenovationsOverviewWindow.xaml
    /// </summary>
    public partial class AccommodationRenovationsOverviewWindow : Window
    {
        public AccommodationRenovationsOverviewWindow(Accommodation accommodation)
        {
            InitializeComponent();
            this.DataContext = new ViewModels.OwnerViewModels.AccommodationRenovationOverviewViewModel(accommodation);

            if (DataContext is IClose vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
