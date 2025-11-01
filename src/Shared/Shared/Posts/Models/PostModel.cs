using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Posts.Models
{
    public record PostModel
    (
        Guid Id,
        string Title,
        string Content        
    );
}
