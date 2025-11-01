using ErrorOr;
using MediatR;
using Shared.Posts.Models;


namespace Modules.Posts.Application.Posts.Commands.Create
{
    public record CreatePostCommand
    (
        string Title,
        string Content
    ) : IRequest<ErrorOr<PostModel>>;
}
