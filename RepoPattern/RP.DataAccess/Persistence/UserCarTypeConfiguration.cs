using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RP.DataAccess.Model;

namespace RP.DataAccess.Persistence
{
    class UserCarTypeConfiguration : IEntityTypeConfiguration<UserCar>
    {
        public void Configure(EntityTypeBuilder<UserCar> builder)
        {
            builder.HasKey(x => new { x.UserId, x.CarId });
            builder.Property(x => x.UserId).HasColumnName("userid");
            builder.Property(x => x.CarId).HasColumnName("carid");

            builder.HasOne(us => us.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(us => us.UserId);

            builder.HasOne(us => us.Car)
                .WithMany(c => c.Users)
                .HasForeignKey(us => us.CarId);
        }
    }
}
