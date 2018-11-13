using System.Collections.Generic;
using BT.Dom.Entities;

namespace BT.DataAccess.Interfaces
{
    public interface ITourRepository
    {
        void CreateTour(Tour tour);
        void EditTour(Tour tour);
        void DeleteTour(int? id);
        Tour GetById(int? id);
        IEnumerable<Tour> GetAll();
    }
}
