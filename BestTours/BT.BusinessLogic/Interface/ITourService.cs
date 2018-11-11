using System.Collections.Generic;
using BT.Dom.Entities;

namespace BT.BusinessLogic.Interface
{
    public interface ITourService
    {
        void CreateTour(Tour tour);
        void DeleteTour(int? id);
        void EditTour(Tour tour);
        Tour GetById(int? id);
        IEnumerable<Tour> GetAll();
    }
}
