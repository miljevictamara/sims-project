﻿using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class ReservationRescheduleRequestService
    {
        private ReservationRescheduleRequestRepository _reservationRescheduleRequestRepository;

        public ReservationRescheduleRequestService()
        {
            _reservationRescheduleRequestRepository = ReservationRescheduleRequestRepository.GetInstance();
        }

        public List<ReservationRescheduleRequest> GetAll()
        {
            return _reservationRescheduleRequestRepository.GetAll();
        }

        public ReservationRescheduleRequest Get(int id)
        {
            return _reservationRescheduleRequestRepository.Get(id);
        }

        public ReservationRescheduleRequest Save(ReservationRescheduleRequest reservationRescheduleRequest)
        {

            return _reservationRescheduleRequestRepository.Save(reservationRescheduleRequest);
        }

        public void Delete(ReservationRescheduleRequest reservationRescheduleRequest)
        {

            _reservationRescheduleRequestRepository.Delete(reservationRescheduleRequest);

        }

        public ReservationRescheduleRequest Update(ReservationRescheduleRequest reservationRescheduleRequest)
        {
            return _reservationRescheduleRequestRepository.Update(reservationRescheduleRequest);
        }

        public int NextId()
        {
            return _reservationRescheduleRequestRepository.NextId();
        }

        private bool IsRequestOnStandby(ReservationRescheduleRequest reservationRescheduleRequest)
        {
            return reservationRescheduleRequest.Status == Enumerations.RequestStatusType.Standby;
        }

        public List<ReservationRescheduleRequest> GetAllRequestsForHandling()
        {
            List<ReservationRescheduleRequest> reservationRescheduleRequests= new List<ReservationRescheduleRequest>();
            foreach (ReservationRescheduleRequest reservationRescheduleRequest in _reservationRescheduleRequestRepository.GetAll())
            {
                if (IsRequestOnStandby(reservationRescheduleRequest) && SignInForm.LoggedUser.Id == reservationRescheduleRequest.Reservation.Accommodation.Owner.Id)
                {
                    reservationRescheduleRequests.Add(reservationRescheduleRequest);
                }
            }

            return reservationRescheduleRequests;
        }
    }
}
