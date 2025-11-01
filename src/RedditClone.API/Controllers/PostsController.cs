

using Contracts.Requests.Posts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Posts.Application.Posts.Commands.Create;
using Modules.Posts.Application.Posts.Queries.ListPost;

namespace RedditClone.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public PostsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost( CreatePostRequest createPostRequest)
        {
            var command = _mapper.Map<CreatePostCommand>(createPostRequest);
            var result = await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpGet]
        public async Task<IActionResult> ListPosts()
        {
            var query = new ListPostQuery();
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}
