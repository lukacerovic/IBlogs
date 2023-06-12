using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IBlogs.Models.ViewModels
{
    public class PostDetailsViewModel
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
        public int CheckLikeStatus { get; set; } 
        public int TotalLikes { get; set; }
        public List<string> AllComments { get; set; }
    }
}
