﻿using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccommodationRepository
    {
        private const string FilePath = "../../../Resources/Data/accommodations.csv";

        
        private static AccommodationRepository instance = null;


        private readonly Serializer<Accommodation> _serializer;

        private List<Accommodation> _accommodations;

        private AccommodationRepository()
        {
            _serializer = new Serializer<Accommodation>();
            _accommodations = _serializer.FromCSV(FilePath);
        }
        public static AccommodationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AccommodationRepository();
            }
            return instance;
        }
        public void BindAccomodationLocation()
        {
            foreach (Accommodation accommodation in _accommodations)
            {
                int locationId = accommodation.Location.Id;
                Location location = LocationRepository.GetInstance().Get(locationId);
                if (location != null)
                {
                    accommodation.Location = location;
                }
                else
                {
                    Console.WriteLine("Error in accommodationLocation binding");
                }
            }
        }
        public List<Accommodation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public Accommodation Get(int id)
        {
            return _accommodations.Find(a => a.Id == id);
        }
        public Accommodation Save(Accommodation accommodation)
        {
            accommodation.Id = NextId();
            _accommodations = _serializer.FromCSV(FilePath);
            _accommodations.Add(accommodation);
            _serializer.ToCSV(FilePath, _accommodations);
            return accommodation;
        }
        public int NextId()
        {
            _accommodations = _serializer.FromCSV(FilePath);
            if (_accommodations.Count < 1)
            {
                return 1;
            }
            return _accommodations.Max(a => a.Id) + 1;
        }
        public void Delete(Accommodation accommodation)
        {
            _accommodations = _serializer.FromCSV(FilePath);
            Accommodation founded = _accommodations.Find(a => a.Id == accommodation.Id);
            _accommodations.Remove(founded);
            _serializer.ToCSV(FilePath, _accommodations);
        }

        public Accommodation Update(Accommodation accommodation)
        {
            _accommodations = _serializer.FromCSV(FilePath);
            Accommodation current = _accommodations.Find(a => a.Id == accommodation.Id);
            int index = _accommodations.IndexOf(current);
            _accommodations.Remove(current);
            _accommodations.Insert(index, accommodation);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _accommodations);
            return accommodation;
        }

        public List<Accommodation> GetByOwner(int ownerId)    
        {
            _accommodations = _serializer.FromCSV(FilePath);
            return _accommodations.FindAll(i => i.Owner.Id == ownerId);
        }
    }
}
