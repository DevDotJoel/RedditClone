using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Posts.Domain.Posts;
using Modules.Posts.Domain.Posts.ValueObjects;

namespace Modules.Posts.Infrastructure.Persistence.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(v => v.Value, src => PostId.Create(src)).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Content)
                .HasMaxLength(40000);
        }
    }
}
