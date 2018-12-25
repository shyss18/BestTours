using System;
using System.Collections.Generic;
using BT.Dom.Entities;

namespace BT.DataAccess.Interfaces
{
    public interface IHotelRepository : IDisposable
    {
        void CreateHotel(Hotel model);
        void UpdateHotel(Hotel model);
        Hotel GetById(int? id);
        void DeleteHotel(int? id);
        IEnumerable<Hotel> FindBy(Func<Hotel, bool> predicate);
        IEnumerable<Hotel> GetAll();
    }
}
