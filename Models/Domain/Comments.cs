namespace IBlogs.Models.Domain
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserProfileName { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
