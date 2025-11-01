using ErrorOr;
using MapsterMapper;
using MediatR;
using Modules.Posts.Application.Common.Contracts;
using Modules.Posts.Domain.Posts;
using Shared.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Application.Posts.Commands.Create
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<PostModel>>
    {
        private readonly IPostsDbContext _context;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IPostsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<ErrorOr<PostModel>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = Post.Create(request.Title, request.Content);
            await _context.Posts.AddAsync(post,cancellationToken);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostModel>(post);
        }
    }
}
