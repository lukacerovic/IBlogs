using IBlogs.Data;
using IBlogs.Models.Domain;
using IBlogs.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IBlogs.Controllers
{
    public class PostsController : Controller
    {
        private readonly IBlogDbContext blogDbContext;
        private readonly SignInManager<Profile> signInManager;

        public PostsController(IBlogDbContext blogDbContext, SignInManager<Profile> signInManager)
        {
            this.blogDbContext = blogDbContext;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult NewBlog (Guid id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBlog(Guid id, CreateBlog createBlog, IFormFile file, string[] topic)
        {
                createBlog.Topics = string.Join(",", topic);

                using var ms = new MemoryStream();
                file.CopyToAsync(ms).GetAwaiter().GetResult();
                var imageData = ms.ToArray();
                var base64String = Convert.ToBase64String(imageData);


            var newBlog = new Posts
            {
                PostId = Guid.NewGuid(),
                Name = signInManager.UserManager.GetUserAsync(User).Result.Name,
                CreatorId = id,
                Header = createBlog.Header,
                Title = createBlog.Title,
                Topics = createBlog.Topics,
                About = createBlog.About,
                Image = base64String,
                PostedDate = DateTime.Now
            };
            blogDbContext.BlogPosts.Add(newBlog);
            blogDbContext.SaveChanges();

            return RedirectToAction("Index", "Home"); 
        }

        
    }
}
