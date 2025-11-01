using ErrorOr;
using MediatR;
using Shared.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Application.Posts.Queries.ListPost
{
    public record ListPostQuery():IRequest<ErrorOr<List<PostModel>>>;
}
