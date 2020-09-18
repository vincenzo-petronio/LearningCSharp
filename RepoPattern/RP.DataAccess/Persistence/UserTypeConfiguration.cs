using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RP.DataAccess.Model;

namespace RP.DataAccess.Persistence
{
    class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();

            // One-To-Many
            //builder.HasMany(x => x.Cars)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.Id);
        }
    }
}
