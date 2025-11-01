using Microsoft.EntityFrameworkCore;
using Modules.Posts.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Application.Common.Contracts
{
    public interface IPostsDbContext
    {
        DbSet<Post> Posts { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
