﻿using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject.Service.Services
{
    public class AccommodationRenovationService
    {
        private IAccommodationRenovationRepository _accommodationRenovationRepository;
        private AccommodationReservationService _accommodationReservationService;
        public AccommodationRenovationService()
        {
            _accommodationRenovationRepository = Injector.Injector.CreateInstance<IAccommodationRenovationRepository>();
            _accommodationReservationService = new AccommodationReservationService();

        }

        public List<AccommodationRenovation> GetAll()
        {
            return _accommodationRenovationRepository.GetAll();
        }

        public AccommodationRenovation Get(int id)
        {
            return _accommodationRenovationRepository.Get(id);
        }

        public AccommodationRenovation Save(AccommodationRenovation accommodationRenovation)
        {

            return _accommodationRenovationRepository.Save(accommodationRenovation);
        }

        public void Delete(AccommodationRenovation accommodationRenovation)
        {

            _accommodationRenovationRepository.Delete(accommodationRenovation);

        }

        public AccommodationRenovation Update(AccommodationRenovation accommodationRenovation)
        {
            return _accommodationRenovationRepository.Update(accommodationRenovation);
        }

        public List<AccommodationRenovation> GetByAccommodationId(int id)
        {
            return _accommodationRenovationRepository.GetByAccommodationId(id);
        }

        public List<AvailableTermsDto> FindAllAvailableTerms(Accommodation accommodation, DateTime Start, DateTime End, int Duration)
        {
            List<AccommodationReservation> reservations = _accommodationReservationService.GetByAccommodationId(accommodation.Id);
            List<AvailableTermsDto> availableTerms = GetAvailableTerms(Start, End, Duration, reservations);

            return availableTerms;
        }

        private bool IsTermAvailableForRenovation(DateTime startDate, DateTime endDate, int duration, AccommodationReservation reservation)
        {
            while (startDate.AddDays(duration) <= endDate)
            {
                bool isAvailable = true;
     
                if (startDate.AddDays(duration) > reservation.Start && startDate < reservation.End)
                {
                    isAvailable = false;
                }
                
                if (isAvailable)
                {
                    return true;
                }

                startDate = startDate.AddDays(1);
            }

            return false;
        }

        private List<AvailableTermsDto> GetAvailableTerms(DateTime Start, DateTime End, int duration, List<AccommodationReservation> reservations)
        {
            List<AvailableTermsDto> availableTerms = new List<AvailableTermsDto>();

            foreach (AccommodationReservation reservation in reservations)
            {
                while (Start.AddDays(duration) <= End)
                {
                    if (IsTermAvailableForRenovation(Start, End, duration, reservation))
                    {
                        AvailableTermsDto availableTerm = new AvailableTermsDto(Start, Start.AddDays(duration));
                        availableTerms.Add(availableTerm);
                    }

                    Start = Start.AddDays(1);
                }
            }

            return availableTerms;
        }

        public List<AccommodationRenovation> GetAllValidRenovations(Accommodation accommodation)
        {
            List<AccommodationRenovation> renovations = GetByAccommodationId(accommodation.Id);
            foreach(AccommodationRenovation renovation in renovations)
            {
                if(renovation.IsCancelled == true)
                {
                    renovations.Remove(renovation);
                }
            }
            return renovations;
        }


    }
}
