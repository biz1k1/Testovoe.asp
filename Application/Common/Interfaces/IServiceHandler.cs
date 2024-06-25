using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Model;

namespace Application.Common.Interfaces
{
    public interface  IServiceHandler
    {
        public Task<int> GetNumberOfDishes(Guid DishId);
    }
}
