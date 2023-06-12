using IBlogs.Data;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Repository
{
    public class LikesRepository : ILikesRepository
    {
        private readonly IBlogDbContext blogDbContext;

        public LikesRepository(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<int> GetStatusLike(Guid logedInUser, Guid postId)
        {
            var checkLike = await blogDbContext.LikePosts.FirstOrDefaultAsync(x => x.UserWhoLiked == logedInUser && x.LikedPost == postId);
            if (checkLike != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> GetTotalLikes(Guid postId)
        {
            return await blogDbContext.LikePosts.
                CountAsync(x => x.LikedPost == postId);

        }
    }
}
