using Shared.User.Contracts;

namespace RedditClone.API.Services
{
    public class UserService : IUserService
    {
        public Task<Guid?> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
