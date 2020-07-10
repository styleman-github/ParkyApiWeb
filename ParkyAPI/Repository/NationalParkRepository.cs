﻿using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalPark.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalPark.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _db.NationalPark.FirstOrDefault(n => n.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalPark.OrderBy(n => n.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalPark.Any(n => n.Name.ToLower() == name.ToLower());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            bool value = _db.NationalPark.Any(n => n.Id == id);
            return value;
        }

        public bool Save()
        {
#pragma warning disable S1125 // Boolean literals should not be redundant
            return _db.SaveChanges() >= 0 ? true : false;
#pragma warning restore S1125 // Boolean literals should not be redundant
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalPark.Update(nationalPark);
            return Save();
        }
    }
}
