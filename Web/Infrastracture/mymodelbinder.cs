//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

//namespace Web.Infrastracture
//{
//    public class mymodelbinder : SimpleTypeModelBinder
//    {
//        public mymodelbinder(Type type, ILoggerFactory loggerFactory) : base(type, loggerFactory)
//        {
//        }

//        public override object BindModel(ControllerContext controllerContext, BindingContext bindingContext)
//        {
//            var allowedProperties = new string[] { "Property1", "Property2" }; // Определите разрешенные свойства

//            var modelData = controllerContext.HttpContext.Request.Form; // Извлеките данные модели

//            var model = new MyModel(); // Создайте экземпляр модели

//            Заполните модель только разрешенными свойствами
//            foreach (var property in allowedProperties)
//            {
//                if (modelData.ContainsKey(property))
//                {
//                    model.GetType().GetProperty(property).SetValue(model, modelData[property]);
//                }
//            }

//            return model;
//        }
//    }
//}
