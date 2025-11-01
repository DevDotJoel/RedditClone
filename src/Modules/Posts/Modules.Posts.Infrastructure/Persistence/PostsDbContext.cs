using Microsoft.EntityFrameworkCore;
using Modules.Posts.Application.Common.Contracts;
using Modules.Posts.Domain.Posts;


namespace Modules.Posts.Infrastructure.Persistence
{
    public class PostsDbContext : DbContext, IPostsDbContext
    {
        public DbSet<Post> Posts => Set<Post>();

        public PostsDbContext(DbContextOptions<PostsDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostsDbContext).Assembly);
        }
    }
}
