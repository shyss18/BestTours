using System;
using System.Collections.Generic;
using BT.Dom.Entities;

namespace BT.DataAccess.Interfaces
{
    public interface ITourRepository: IDisposable
    {
        void CreateTour(Tour tour);
        void EditTour(Tour tour);
        void DeleteTour(int? id);
        Tour GetById(int? id);
        IEnumerable<Tour> FindBy(Func<Tour, bool> predicate);
        IEnumerable<Tour> GetAll();
    }
}
