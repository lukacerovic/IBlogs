namespace IBlogs.Models.ViewModels
{
    public class ListRequest
    {
        public Guid ProfileId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string? ProfileImage { get; set; }

    }
}
