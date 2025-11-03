using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User.Models
{
    public record TokenResultModel
    (

        string AccessToken,
        string RefreshToken
     );
}
