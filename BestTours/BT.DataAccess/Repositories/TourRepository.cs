using System;
using System.Collections.Generic;
using System.Linq;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;
using System.Data.Entity;
using BT.DataAccess.Context;

namespace BT.DataAccess.Repositories
{
    public class TourRepository : ITourRepository
    {
        private ApplicationContext _dataBase;

        public TourRepository(ApplicationContext dataBase)
        {
            _dataBase = dataBase;
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
            var tour = _dataBase.Tours.Include(t => t.Hotel).FirstOrDefault(t => t.Id == id);

            return tour;
        }

        public IEnumerable<Tour> FindBy(Func<Tour, bool> predicate)
        {
            var tour = _dataBase.Tours.Where(predicate).Select(m => m);

            return tour;
        }

        public IEnumerable<Tour> GetAll()
        {
            return _dataBase.Tours.Include(t => t.Hotel);
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
