using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P224FirstApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(b => b.UpdatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(b => b.DeletedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}
