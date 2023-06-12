namespace IBlogs.Repository
{
    public interface ICreatorsRepository
    {
        Task<List<string>> UserTopics(Guid userId);
    }
}
