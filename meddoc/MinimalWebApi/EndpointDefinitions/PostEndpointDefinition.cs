using ApplicationCore.Posts.Commands;
using ApplicationCore.Posts.Queries;
using Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalWebApi.Abstractions;
using MinimalWebApi.Filters;

namespace MinimalWebApi.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var postItem = app.MapGroup("/api/posts");

            // End points with method injection and metadata
            postItem.MapGet("/{id}", GetPostById()).WithName("GetPostById");
            postItem.MapPost("/", CreatePost()).AddEndpointFilter<PostValidationFilter>();
            postItem.MapGet("/", GetAllPosts());
            postItem.MapPut("/{id}", UpdatePost()).AddEndpointFilter<PostValidationFilter>(); ;
            postItem.MapDelete("/{id}", DeletePost());
        }

        private static Func<IMediator, Guid, Task<IResult>> DeletePost()
        {
            return async (IMediator mediator, Guid id) =>
            {
                var deletePost = new DeletePost { PostId = id };
                var deletedPost = await mediator.Send(deletePost);
                return TypedResults.NoContent();
            };
        }

        private static Func<IMediator, Post, Guid, Task<IResult>> UpdatePost()
        {
            return async (IMediator mediator, [FromBody] Post post, Guid id) =>
            {
                var updatePost = new UpdatePost { PostId = id, PostContent = post.TextContent };
                var updatedPost = await mediator.Send(updatePost);
                return TypedResults.Ok(updatedPost);
            };
        }

        private static Func<IMediator, Task<IResult>> GetAllPosts()
        {
            return async (IMediator mediator) =>
            {
                var getAllPost = new GetAllPosts();
                var posts = await mediator.Send(getAllPost);
                return TypedResults.Ok(posts);
            };
        }

        private static Func<IMediator, Post, Task<IResult>> CreatePost()
        {
            return async (IMediator mediator, [FromBody] Post post) =>
            {
                var createPost = new CreatePost { TextContent = post.TextContent };
                var createdPost = await mediator.Send(createPost);
                return Results.CreatedAtRoute("GetPostById", new { createdPost.PostId }, createdPost);
            };
        }

        private static Func<IMediator, Guid, Task<IResult>> GetPostById()
        {
            return async (IMediator mediator, Guid postId) =>
            { 
                var getPost = new GetPostById(postId);
                var post = await mediator.Send(getPost);
                return TypedResults.Ok(post);
            };
        }
    }
}
