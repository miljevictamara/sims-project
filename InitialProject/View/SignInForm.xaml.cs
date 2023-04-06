﻿using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.View;
using InitialProject.View.OwnerView;
using InitialProject.View.OwnerWindows;
using InitialProject.View.Guest2Window;
using InitialProject.View.GuideWindows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using InitialProject.Enumerations;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        public AccommodationReservationController _accommodationReservationController;

        private static User loggedUser;

        public static User LoggedUser
        {
            get => loggedUser;

        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = UserRepository.GetInstance();

            _accommodationReservationController = new AccommodationReservationController();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByUsername(Username);


            if (user != null)
            {
                if (user.Password == txtPassword.Password)
                {
                    loggedUser = user;
                    if (user.Type == UserType.Owner)
                    {
                        int NumberOfGuestsWithoutReview = _accommodationReservationController.FindNumberOfGuestsWithoutReview();
                        OwnerMainWindow OwnerMainWindow = new OwnerMainWindow();
                        OwnerMainWindow.Show();
                        if (NumberOfGuestsWithoutReview > 0)
                        {
                            GuestsWithoutReviewNotificationWindow Notification = new GuestsWithoutReviewNotificationWindow();
                            Notification.Show();
                            Close();
                        }
                        Close();

                    }
                    else if (user.Type == UserType.Guide)
                    {
                        GuideMainWindow guideMainWindow = new GuideMainWindow();
                        guideMainWindow.Show();

                    }
                    else if (user.Type == UserType.Guest1)
                    {
                        AccommodationsOverview accommodationsOverview = new AccommodationsOverview(user);
                        accommodationsOverview.Show();
                    }
                    else if (user.Type == UserType.Guest2)
                    {

                        ToursOverviewWindow toursOverview = new ToursOverviewWindow();
                        toursOverview.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
        }
    }
}
