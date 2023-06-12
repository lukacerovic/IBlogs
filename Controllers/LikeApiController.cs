using IBlogs.Data;
using IBlogs.Models.Domain;
using IBlogs.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBlogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeApiController : ControllerBase
    {
        private readonly IBlogDbContext blogDbContext;

        public LikeApiController(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        [HttpPost]
        [Route("Like")]
        public async Task<IActionResult> LikePost([FromBody] LikeRequest likeRequest)
        {
            var model = new LikePost
            {
                UserWhoLiked = likeRequest.UserWhoLiked,
                LikedPost = likeRequest.LikedPost,
                OwnerOfPost = likeRequest.OwnerOfPost
            };
            blogDbContext.LikePosts.Add(model);
            blogDbContext.SaveChanges();

            return Ok();
        }
       
    }
}
