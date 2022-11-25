using DemoProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoProject.DataAccess.Concrete.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(nameof(AppUser), "Account");

            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.UserName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100);
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);
        }
    }
}
