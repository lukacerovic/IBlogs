using IBlogs.Models.Domain;

namespace IBlogs.Repository
{
    public interface ICommentsRepository
    {
        Task<List<string>> GetComments(Guid postId);
    }
}
