using Domain.Entity;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Web.Model;
using Web.Services;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        

        public HomeController( DataContext data)
        {
            _dataContext = data;
        }

        public async Task<IActionResult> Index()
        {
            //var user = new UserEntity()
            //{
            //    Name = "Nikita",
            //    Email = "Nikita",

            //};
            //_dataContext.Add(user);
            //_dataContext.SaveChanges();

            var viewModel = new UserDishesViewModel()
            {
                User = await _dataContext.Users.ToListAsync(),
                Dish = await _dataContext.Dishes.ToListAsync(),
            };

            var lenta = _dataContext.Eats
             .Select(x => new EatModel
             {
                 EatTime = x.EatTime,
                 UserName = x.User.Name,
                 DishName = x.Dish.Name,
                 UserEmail = x.User.Email,
             })
             .TakeLast(10)
             .OrderByDescending(x => x.EatTime);


            viewModel.UserDishModel = new Model.UserDishModel();
            return View(viewModel);
        }
        // написал запрос для ленты здесь. Изначально запрос был в UserController,
        // но почему то значение в viewModel.Lenta не передавалось, было пустое значение
        public async Task<IActionResult> Page2(UserEntityWithUserDbViewModel viewModel)
        {
            var lenta = await _dataContext.Eats
              .Select(x => new EatModel
              {
                  EatTime = x.EatTime,
                  UserName = x.User.Name,
                  DishName = x.Dish.Name,
                  UserEmail = x.User.Email,
              })
              .OrderByDescending(x=>x.EatTime)
              .Take(15)
              .ToListAsync();

            viewModel.Lenta = lenta;
            return View(viewModel);
        }



        public PartialViewResult LoadPartialView()
        {
            var model = new UserDishModel
            {
            };

            return PartialView("Register", model);
        }
    }


}
