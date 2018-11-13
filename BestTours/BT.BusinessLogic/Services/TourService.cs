using System.Collections.Generic;
using BT.BusinessLogic.Interface;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;

namespace BT.BusinessLogic.Services
{
    public class TourService: ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public void CreateTour(Tour tour)
        {
            _tourRepository.CreateTour(tour);
        }

        public void DeleteTour(int? id)
        {
            _tourRepository.DeleteTour(id);
        }

        public void EditTour(Tour tour)
        {
            _tourRepository.EditTour(tour);
        }

        public Tour GetById(int? id)
        {
            return _tourRepository.GetById(id);
        }

        public IEnumerable<Tour> GetAll()
        {
            return _tourRepository.GetAll();
        }
    }
}
