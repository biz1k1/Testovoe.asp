using Domain.Entity;

namespace Web.ViewModel
{
    public class UserDishesModel
    {
        public List<UserEntity> User { get; set; }
        public List<DishEntity> Dish { get; set; }
        public DishEntity DishEntity { get; set; } = new DishEntity();
        public UserEntity userEntity { get; set; } = new UserEntity();
    }
}
