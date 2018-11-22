using System;
using System.Collections.Generic;
using BT.Dom.Entities;

namespace BT.BusinessLogic.Interface
{
    public interface ITourService : IDisposable
    {
        void CreateTour(Tour tour);
        void DeleteTour(int? id);
        void EditTour(Tour tour);
        Tour GetById(int? id);
        IEnumerable<Tour> FindBy(Func<Tour, bool> predicate);
        IEnumerable<Tour> GetAll();
        bool BuyTour(Tour tour, string userId);
    }
}
