using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P224FirstApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(b => b.Price).IsRequired(true);
            builder.Property(b => b.DiscountPrice).IsRequired(true);
            builder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(b => b.UpdatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(b => b.DeletedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));

            builder.HasOne(b => b.Category).WithMany(b => b.Products).HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
