using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DishEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserEntity> Users { get; set; } = [];
    }
}
