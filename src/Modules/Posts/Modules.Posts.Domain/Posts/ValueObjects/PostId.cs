using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Domain.Posts.ValueObjects
{
    public class PostId : EntityId<Guid>
    {
        private PostId(Guid id) : base(id)
        {

        }

        public static PostId Create(Guid value)
        {
            return new PostId(value);

        }
        public static PostId CreateUnique()
        {
            return new PostId(Guid.NewGuid());
        }

        private PostId()
        {

        }
    }
}
