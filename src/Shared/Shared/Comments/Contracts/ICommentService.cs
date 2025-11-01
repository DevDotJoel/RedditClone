using Shared.Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Comments.Contracts
{
    public interface ICommentService
    {
        Task<CommentModel> GetCommentsByPostId(Guid postId);
    }
}
