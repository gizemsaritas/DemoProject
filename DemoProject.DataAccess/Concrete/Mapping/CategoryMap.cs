using DemoProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoProject.DataAccess.Concrete.Mapping
{
    public class CategoryMap: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), nameof(Category));
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100);

            builder.HasMany(I => I.SubCategories).WithOne(I => I.ParentCategory).HasForeignKey(I => I.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
            ;

            builder.HasMany(I => I.Products).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);

        }
    }
}
