using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserController:Controller
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
