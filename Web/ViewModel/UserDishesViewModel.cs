using Domain.Entity;
using Web.Model;

namespace Web.ViewModel
{
    public class UserDishesViewModel
    {
        public List<UserEntity> User { get; set; }
        public List<DishEntity> Dish { get; set; }
        public UserDishModel UserDishModel { get; set; }
        public DishModel DishModel { get; set; }
    }
}
