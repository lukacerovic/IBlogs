namespace IBlogs.Models.ViewModels
{
    public class LikeRequest
    {
        public Guid Id { get; set; }
        public Guid UserWhoLiked { get; set; }
        public Guid LikedPost { get; set; }
        public Guid OwnerOfPost { get; set; }
    }
}
