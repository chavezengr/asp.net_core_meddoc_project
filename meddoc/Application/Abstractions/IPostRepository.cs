using Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts();
        Task<Post> GetPostById(Guid postId);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(string updatedContent, Guid postId);
        Task DeletePost(Guid postId);
    }
}
