using DemoProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoProject.DataAccess.Concrete.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), nameof(Product));
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Price).IsRequired();
            builder.Property(I => I.ImageUrl).HasMaxLength(300);
            builder.Property(I => I.Description).HasColumnType("ntext");
        }
    }
}
