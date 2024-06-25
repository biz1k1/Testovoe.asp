using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); 
        }
    }
    public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
    {
        public void Configure(EntityTypeBuilder<DishEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasMany(x => x.User)
                .WithMany(x => x.Dish)
                .UsingEntity<EatEntity>(
                x => x.HasOne(x => x.User).WithMany(x => x.Eat),
                x => x.HasOne(x => x.Dish).WithMany(x => x.Eat));



        }
        public class EatConfiguration : IEntityTypeConfiguration<EatEntity>
        {
            public void Configure(EntityTypeBuilder<EatEntity> builder)
            {
                builder.HasKey(x => x.Id);
                
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
            }
        }

    }
}
