using ApplicationCore.Abstractions;
using Domain.Aggregates.PostAggregate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PostRepository(DataContext context) : IPostRepository
    {
        private readonly DataContext _context = context;

        public async Task<Post> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task DeletePost(Guid postId)
        {
            var post = await GetPostById(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            } else { return; }
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);

            return post ?? throw new NotImplementedException();
        }

        public async Task<Post> UpdatePost(string updatedContent, Guid postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            if(post != null)
            {
                //post.LastModified = DateTime.Now;
                //post.Content = updatedContent;
                await _context.SaveChangesAsync();
            }
            return post ?? throw new NotImplementedException();
        }
    }
}
