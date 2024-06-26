using Application.Common.Interfaces;
using Azure.Core;
using Domain.Entity;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Infrastracture;
using Web.Model;
using Web.Services;
using Web.ViewModel;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IServiceHandler _serviceHandler;
        public UserController(DataContext dataContext, IServiceHandler serviceHandler)
        {
            _dataContext = dataContext;
            _serviceHandler = serviceHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDishModel userDishModel)
        {

            var user = _dataContext.Users.FirstOrDefault(x => x.Name == userDishModel.Name);

            //создается пользователей, если его существует
            if (user == null || user.Email == null || user.Email != userDishModel.Email)
            {

                TempData["ErrorMessage"] = "Пользователя с таким именем или почтой не существует";
                return LocalRedirect("/Home/Index");
            }

            var dish = _dataContext.Dishes.FirstOrDefault(x => x.Name == userDishModel.Dish);

            if (dish == null)
            {
                TempData["ErrorMessage"] = "Блюда не существует или оно закончилось";
                return LocalRedirect("/Home/Index");
            }

            var EatEntity = new EatEntity()
            {
                DishId = dish.Id,
                UserId = user.Id,
                EatTime = DateTime.Now
            };
            _dataContext.Eats.Add(EatEntity);
            await _dataContext.SaveChangesAsync();


            return RedirectToAction("GetUserDishForPage2", "User", EatEntity);
        }
        //Скорее всего пользователей, который нажал на кнопку "что я ем" будет находится в списке 10 записей в бд
        // но на всякий случай сделал запрос в бд на него отдельно
        public async Task<IActionResult> GetUserDishForPage2( EatEntity eatEntity)
        {
            var user = await _dataContext.Users.Include(x => x.Dish).FirstOrDefaultAsync(x => x.Id == eatEntity.UserId);

            var dish = user.Dish.FirstOrDefault(x => x.Id == eatEntity.DishId);


            var viewModel = new UserEntityWithUserDbViewModel()
            {
                UserName = user.Name,
                DishName = dish.Name,
                EatTime = eatEntity.EatTime,

                NumberofDishEatenPerDay = await _serviceHandler.GetNumberOfDishes(dish.Id),
            };

            return RedirectToAction("Page2", "Home", viewModel);
        }

        public async Task<IActionResult> CreateUser(UserDishModel userDishModel)
        {
            if (userDishModel == null)
            {
                TempData["ErrorMessage"] = "Поле имя или почта пустое ";
                return LocalRedirect("/Home/Index");
            }
            var newUser = new UserEntity()
            {
                Name = userDishModel.Name,
                Email = userDishModel.Email,
            };

            await _dataContext.Users.AddAsync(newUser);


            return RedirectToAction("Post", "User", userDishModel);
        }
    }
}
