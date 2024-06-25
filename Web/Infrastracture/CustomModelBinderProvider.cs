using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Web.Model;

namespace Web.Infrastracture
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder binder = new CustomModelBinder(new SimpleTypeModelBinder(typeof(UserDishModel),loggerFactory));

            return context.Metadata.ModelType == typeof(UserDishModel) ? binder : null;
        }
    }
}
