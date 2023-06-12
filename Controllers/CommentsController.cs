using IBlogs.Data;
using IBlogs.Models.Domain;
using IBlogs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IBlogs.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IBlogDbContext blogDbContext;

        public CommentsController(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CommentsRequest comments)
        {
            var findUserName = blogDbContext.Profiles.FirstOrDefault(x => x.ProfileId == comments.UserId);
            var model = new Comments
            {
                Description = comments.Content,
                PostId = comments.PostId,
                UserId= comments.UserId,
                UserProfileName = findUserName.Name,
                DateOfComment = DateTime.Now
            };
            blogDbContext.CommentPost.Add(model);
            blogDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
