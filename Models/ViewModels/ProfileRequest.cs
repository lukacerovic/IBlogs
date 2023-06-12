namespace IBlogs.Models.ViewModels
{
    public class ProfileRequest
    {
        public Guid ProfileId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public string? ProfileImage { get; set; }
        public List<string>? MyTopics { get; set; }

        public string? About { get; set; }
    }
}
