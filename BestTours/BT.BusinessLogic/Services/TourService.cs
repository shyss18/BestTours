using System.Collections.Generic;
using BT.BusinessLogic.Interface;
using BT.DataAccess.Dependency;
using BT.DataAccess.Interfaces;
using BT.DataAccess.Repositories;
using BT.Dom.Entities;
using Ninject;

namespace BT.BusinessLogic.Services
{
    public class TourService: ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService()
        {
            IKernel kernel = new StandardKernel(new TourDependency());
            _tourRepository = kernel.Get<TourRepository>();
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
