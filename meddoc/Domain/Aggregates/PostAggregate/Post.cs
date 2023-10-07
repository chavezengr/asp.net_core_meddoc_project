using Domain.Aggregates.UserProfileAggregate;

namespace Domain.Aggregates.PostAggregate
{
    public class Post
    {
        private Post() { }   
        
        private readonly List<PostComment> _comments = new();
        private readonly List<PostInteraction> _interactions = new();

        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string? TextContent { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        public UserProfile UserProfile { get; private set; }
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }

        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            var objectToValidate = new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };

            return objectToValidate;
        }

        public void UpdatePostText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
            {
               
            }
            TextContent = newText;
            DateUpdated = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void RemoveComment(PostComment toRemove)
        {
            _comments.Remove(toRemove);
        }

        public void UpdatePostComment(Guid postCommentId, string updatedComment)
        {
            var comment = _comments.FirstOrDefault(c => c.CommentId == postCommentId);
        }

        public void AddInteraction(PostInteraction newInteraction)
        {
            _interactions.Add(newInteraction);
        }

        public void RemoveInteraction(PostInteraction toRemove)
        {
            _interactions.Remove(toRemove);
        }
    }
}
