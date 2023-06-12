namespace IBlogs.Repository
{
    public interface ILikesRepository
    {
        Task<int> GetTotalLikes(Guid postId);
        Task<int> GetStatusLike(Guid logedInUser, Guid postId);
    }
}
