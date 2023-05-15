﻿using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class ScheduleAccommodationRenovationViewModel: ViewModelBase, IClose
    {
        public Action Close { get; set; }

        public AccommodationRenovationController _accommodationRenovationController;

        public ObservableCollection<AvailableTermsDto> AvailableTerms { get; set; }

        #region NotifyProperties
        private DateTime _selectedStartDate;
        public DateTime SelectedStartDate
        {
            get => _selectedStartDate;
            set
            {
                if (value != _selectedStartDate)
                {
                    _selectedStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _selectedEndDate;
        public DateTime SelectedEndDate
        {
            get => _selectedEndDate;
            set
            {
                if (value != _selectedEndDate)
                {
                    _selectedEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public RelayCommand SearchCommand { get; set; }

        public RelayCommand ScheduleRenovationCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public Accommodation SelectedAccommodation { get; set; }

        public AvailableTermsDto SelectedTerm { get; set; }

        public ScheduleAccommodationRenovationViewModel(Accommodation accommodation)
        {
            SearchCommand = new RelayCommand(Execute_SearchCommand, Can_SearchCommand);
            ScheduleRenovationCommand = new RelayCommand(Execute_ScheduleRenovationCommand, CanExecute_ScheduleRenovationCommand);
            CancelCommand = new RelayCommand(Execute_CancelCommand);

            _accommodationRenovationController = new AccommodationRenovationController();

            AvailableTerms = new ObservableCollection<AvailableTermsDto>();

            SelectedAccommodation = accommodation;


        }

        public void Execute_CancelCommand(object param)
        {
            Close();
        }

        private void Refresh(List<AvailableTermsDto> availableTerms)
        {
            AvailableTerms.Clear();
            foreach (AvailableTermsDto availableTerm in availableTerms)
            {
                AvailableTerms.Add(availableTerm);
            }
        }

        public bool Can_SearchCommand(object param)
        {
            return true;
        }

        public void Execute_SearchCommand(object param)
        {
            List<AvailableTermsDto> availableTerms = _accommodationRenovationController.FindAllAvailableTerms(SelectedAccommodation ,SelectedStartDate, SelectedEndDate, Duration);
            Refresh(availableTerms);
        }

        public bool CanExecute_ScheduleRenovationCommand(object param)
        {
            return true;
        }
        public void Execute_ScheduleRenovationCommand(object param) 
        {
            AccommodationRenovationDescriptionWindow descriptionWindow = new AccommodationRenovationDescriptionWindow(SelectedAccommodation, SelectedTerm);
            descriptionWindow.Show();
            Close();
        }
    }
}
