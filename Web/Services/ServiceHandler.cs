using Application.Common.Interfaces;
using Domain.Entity;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Web.Model;
using Web.ViewModel;

namespace Web.Services
{
    public class ServiceHandler:IServiceHandler
    {
        private readonly INumberOfDishes _numberOfDishesService;
        private readonly DataContext _dataContext;
        public ServiceHandler(INumberOfDishes numberOfDishesService, DataContext dataContext)
        {
            _numberOfDishesService = numberOfDishesService;
            _dataContext = dataContext;
        }
        public async Task<int> GetNumberOfDishes(Guid DishId)
        {

            var eatList = await _dataContext.Eats.ToListAsync();
            return _numberOfDishesService.GetNumber(eatList,DishId);
        }
    }
}
