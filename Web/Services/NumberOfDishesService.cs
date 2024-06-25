using Domain.Entity;
using Application.Common.Interfaces;

namespace Web.Services
{
    public class NumberOfDishesService:INumberOfDishes
    {
        public int GetNumber(List<EatEntity> eatList,Guid DishId)
        {
            int NumberofDishEatenPerDay = 0;
            foreach (var item in eatList)
            {
                if (item.DishId == DishId)
                {
                    NumberofDishEatenPerDay += 1;
                }
            }
            return NumberofDishEatenPerDay;
        }
    }
}
