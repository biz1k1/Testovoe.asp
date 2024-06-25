using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class EatEntity
    {
        public Guid Id { get; set; }
        public DishEntity Dish { get; set; }

        public Guid DishId { get; set; }
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public DateTime EatTime { get; set; }
    }
}
