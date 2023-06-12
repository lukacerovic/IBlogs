using IBlogs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Controllers
{
    public class ImageController : Controller
    {
        private readonly IBlogDbContext blogDbContext;

        public ImageController(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        [HttpGet("{id}/image")]
        public IActionResult GetImage(Guid id)
        {

            var userProfile = blogDbContext.BlogPosts.FirstOrDefault(x => x.PostId == id);
            if (userProfile == null || userProfile.Image == null)
            {
                return NotFound();
            }
            var imageData = Convert.FromBase64String(userProfile.Image);
            return File(imageData, "image/jpeg");

        }
    }
}
