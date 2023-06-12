using IBlogs.Data;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Repository
{
    public class CreatorsRepository : ICreatorsRepository
    {
        private readonly IBlogDbContext blogDbContext;

        public CreatorsRepository(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<List<string>> UserTopics(Guid userId)
        {
            var topicsList = await blogDbContext.BlogPosts.Where(t => t.CreatorId == userId).Select(t => t.Topics).ToListAsync();
            return topicsList;
        }
    }
}
