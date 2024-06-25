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
            //var query = await _dataContext.Eats
            //    .AsNoTracking()
            //    .Select(x => new UserEntityWithUserDbViewModel
            //    {
            //        EatTime=x.EatTime,
            //        UserName=x.User.Name,
            //        DishName=x.Dish.Name,  
            //    }).ToListAsync();

            var eatList = await _dataContext.Eats.Take(10).ToListAsync();
            return _numberOfDishesService.GetNumber(eatList,DishId);
        }
    }
}
