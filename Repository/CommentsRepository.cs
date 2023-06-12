using IBlogs.Data;
using IBlogs.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IBlogDbContext blogDbContext;

        public CommentsRepository(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<List<string>> GetComments(Guid postId)
        {
            return await blogDbContext.CommentPost.Where(c => c.PostId == postId).Select(c => c.Description).ToListAsync();

        }
    }
}
