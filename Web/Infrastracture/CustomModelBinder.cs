using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Model;

namespace Web.Infrastracture
{
    public class CustomModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public CustomModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var userNameValue = bindingContext.ValueProvider.GetValue("UserName");
            var userEmailValue = bindingContext.ValueProvider.GetValue("UserEmail");
            var dishNameValue = bindingContext.ValueProvider.GetValue("DishName");

            if(userEmailValue==ValueProviderResult.None || userEmailValue==ValueProviderResult.None || dishNameValue == ValueProviderResult.None)
            {
                return fallbackBinder.BindModelAsync(bindingContext);
            }

            string? userName = userEmailValue.FirstValue;
            string? userEmail = userEmailValue.FirstValue;
            string? dishName = dishNameValue.FirstValue;


            var result = new UserDishModel()
            {
                Name = userName,
                Email = userEmail,
                Dish = dishName,
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            
            return Task.CompletedTask;
        }
        
    }
}
