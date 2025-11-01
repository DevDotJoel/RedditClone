using Mapster;
using Modules.Posts.Domain.Posts;
using Shared.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Application.Common.Mapping
{
    public class PostMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Post, PostModel>().
             Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
