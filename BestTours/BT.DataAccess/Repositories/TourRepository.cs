using System;
using System.Collections.Generic;
using System.Linq;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;
using System.Data.Entity;
using BT.DataAccess.Context;

namespace BT.DataAccess.Repositories
{
    public class TourRepository : ITourRepository, IDisposable
    {
        private TourContext _dataBase;

        public TourRepository()
        {
            _dataBase = new TourContext("IdentityDb");
        }

        public void CreateTour(Tour tour)
        {
            _dataBase.Tours.Add(tour);
            _dataBase.SaveChanges();
        }

        public void EditTour(Tour tour)
        {
            _dataBase.Entry(tour).State = EntityState.Modified;
            _dataBase.SaveChanges();
        }

        public void DeleteTour(int? id)
        {
            var tour = GetById(id);

            _dataBase.Tours.Remove(tour);
            _dataBase.SaveChanges();
        }

        public Tour GetById(int? id)
        {
            var tour = _dataBase.Tours.Where(m => m.Id == id).Select(m => m).FirstOrDefault();

            return tour;
        }

        public IEnumerable<Tour> GetAll()
        {
            return _dataBase.Tours.ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataBase != null)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
                }
            }
        }
    }
}
