using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Posts.Application.Common.Contracts;
using Shared.Posts.Models;


namespace Modules.Posts.Application.Posts.Queries.ListPost
{
    public class ListPostQueryHandler : IRequestHandler<ListPostQuery, ErrorOr<List<PostModel>>>
    {
        private readonly IPostsDbContext _context;
        private readonly IMapper _mapper;
        public ListPostQueryHandler(IPostsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
                    
            
        }
        public async Task<ErrorOr<List<PostModel>>> Handle(ListPostQuery request, CancellationToken cancellationToken)
        {

            return _mapper.Map<List<PostModel>>(await _context.Posts.AsNoTracking().ToListAsync(cancellationToken));
        }
    }
}
