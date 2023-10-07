using Domain.Aggregates.PostAggregate.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        private PostComment() { }

        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        // Factory method
        public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
        {
            var objectToValidate = new PostComment
            {
                PostId = postId,
                Text = text,
                UserProfileId = userProfileId,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            return objectToValidate;
        }

        // Public methods
        public void UpdateCommentText(string newText)
        {
            Text = newText;
            DateUpdated = DateTime.UtcNow;
        }
    }
}
