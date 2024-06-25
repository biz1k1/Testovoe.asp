using Domain.Entity;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Model;
using Web.ViewModel;

namespace Web.Controllers
{
    public class DishController:Controller
    {
        private readonly DataContext _dataContext;
        public DishController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost] 
        public async Task<IActionResult> Create(DishEntity dishEntity)
        {
            var dishes = await _dataContext.Dishes.FirstOrDefaultAsync(x => x.Name == dishEntity.Name);
            if (dishes != null)
            {
                TempData["ErrorMessage"] = "Это блюдо уже кто-то когда-то ел";
                return PartialView("/Views/Home/DishDialog.cshtml");
            }

            await _dataContext.AddAsync(dishEntity);
            await _dataContext.SaveChangesAsync();
            return LocalRedirect("~/Home/Index");
        }
    }
}
