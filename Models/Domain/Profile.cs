using Microsoft.AspNetCore.Identity;

namespace IBlogs.Models.Domain
{
    public class Profile : IdentityUser
    {
        public Guid ProfileId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public string? ProfileImage { get; set; }

        public string? About { get; set; }

        public ICollection<Posts> Post { get; set; }
        public ICollection<LikePost> Likes { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
