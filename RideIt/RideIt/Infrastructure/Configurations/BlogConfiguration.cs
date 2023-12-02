using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideIt.Features.Blogs;
using RideIt.Features.Users;

namespace RideIt.Infrastructure.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");

        builder.HasOne(u => u.Author)
            .WithMany();
    }
}