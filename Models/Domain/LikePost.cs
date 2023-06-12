namespace IBlogs.Models.Domain
{
    public class LikePost
    {
        public Guid Id { get; set; }
        public Guid UserWhoLiked { get; set; }
        public Guid LikedPost { get; set; }
        public Guid OwnerOfPost { get; set; }
    }
}
