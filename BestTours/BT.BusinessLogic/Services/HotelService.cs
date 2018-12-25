using System;
using System.Collections.Generic;
using BT.BusinessLogic.Interface;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;

namespace BT.BusinessLogic.Services
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _database;

        public HotelService(IUnitOfWork database)
        {
            _database = database;
        }

        public void CreateHotel(Hotel model)
        {
            _database.HotelRepository.CreateHotel(model);
        }

        public void UpdateHotel(Hotel model)
        {
            _database.HotelRepository.UpdateHotel(model);
        }

        public Hotel GetById(int? id)
        {
            var hotel = _database.HotelRepository.GetById(id);

            return hotel;
        }

        public void DeleteHotel(int? id)
        {
            _database.HotelRepository.DeleteHotel(id);
        }

        public IEnumerable<Hotel> FindBy(Func<Hotel, bool> predicate)
        {
            var hotel = _database.HotelRepository.FindBy(predicate);

            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _database.HotelRepository.GetAll();
        }

        public void Dispose()
        {
            _database.Dispose(); ;
        }
    }
}
