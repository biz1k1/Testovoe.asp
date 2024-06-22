using Domain.Entity;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext data)
        {
            _logger = logger;
            _dataContext = data;
        }

        public IActionResult Index()
        {
            var viewModel = new UserDishesModel()
            {
                User = _dataContext.Users.ToList(),
                Dish = _dataContext.Dishes.ToList(),
            };
            return View(viewModel);
        }
        public IActionResult Dialog()
        {
            var dishModel = new DishEntity();
            return View("dialog",dishModel);
        }

    }
}
