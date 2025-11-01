using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Comments.Models
{
    public record CommentModel
    (
         Guid Id,
         Guid PostId,
         string Conent
    );
}
