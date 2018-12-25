using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BT.DataAccess.Context;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;

namespace BT.DataAccess.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private ApplicationContext _db;

        public HotelRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void CreateHotel(Hotel model)
        {
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void UpdateHotel(Hotel model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Hotel GetById(int? id)
        {
            var hotel = _db.Hotels.FirstOrDefault(h => h.Id == id);

            return hotel;
        }

        public void DeleteHotel(int? id)
        {
            var hotel = GetById(id);

            _db.Entry(hotel).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public IEnumerable<Hotel> FindBy(Func<Hotel, bool> predicate)
        {
            var hotel = _db.Hotels.Where(predicate);

            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _db.Hotels.ToList();
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
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
    }
}
