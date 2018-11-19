using System.Collections.Generic;
using BT.BusinessLogic.Interface;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity;

namespace BT.BusinessLogic.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _database;

        public TourService(IUnitOfWork database)
        {
            _database = database;
        }

        public void CreateTour(Tour tour)
        {
            _database.TourRepository.CreateTour(tour);
        }

        public void DeleteTour(int? id)
        {
            _database.TourRepository.DeleteTour(id);
        }

        public void EditTour(Tour tour)
        {
            _database.TourRepository.EditTour(tour);
        }

        public Tour GetById(int? id)
        {
            return _database.TourRepository.GetById(id);
        }

        public IEnumerable<Tour> GetAll()
        {
            return _database.TourRepository.GetAll();
        }

        public bool BuyTour(Tour tour, string nickName)
        {
            var user = _database.UserManager.FindByNameAsync(nickName).Result;

            if (user.Amount >= tour.Price)
            {
                user.Amount = user.Amount - tour.Price;
                _database.UserManager.Update(user);
                _database.SaveAsync();
                
                user.Tours.Add(tour);
                _database.UserManager.Update(user);
                _database.SaveAsync();

                tour.Users.Add(user);
                _database.TourRepository.EditTour(tour);
                _database.SaveAsync();

                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
