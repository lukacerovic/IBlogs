namespace IBlogs.Models.Domain
{
    public class Posts
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid PostId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Topics { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public DateTime PostedDate { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
