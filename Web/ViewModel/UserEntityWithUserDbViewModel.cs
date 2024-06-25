using Domain.Entity;
using Web.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.ViewModel
{
    public class UserEntityWithUserDbViewModel
    {
        public string UserName { get; set; }
        public string DishName { get; set; }
        public DateTime? EatTime { get; set; }
        public int NumberofDishEatenPerDay { get; set; }
        public List<EatModel> Lenta { get; set; } = [];
    }
}
