namespace IBlogs.Models.ViewModels
{
    public class CommentsRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
      
    }
}
