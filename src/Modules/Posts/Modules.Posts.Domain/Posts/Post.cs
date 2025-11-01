using Common;
using ErrorOr;
using Modules.Posts.Domain.Posts.ValueObjects;


namespace Modules.Posts.Domain.Posts
{
    public class Post : Entity<PostId>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        private Post(string title, string content, PostId? postId = null) : base(postId ?? PostId.CreateUnique())
        {
            Title = title;
            Content = content;
            
        }
        public static Post Create(string title,string content, PostId? postId=null)
        {
            return new Post(title,content, postId);
            
        }
        private Post()
        {
            
        }

        public ErrorOr<Success> SetTitle(string title)
        {
            Title= title;
            return Result.Success;
        }
        public ErrorOr<Success> SetContent(string content)
        {
            Content = content;
            return Result.Success;
        }
    }
}
