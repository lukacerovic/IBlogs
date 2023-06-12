using IBlogs.Data;
using IBlogs.Models;
using IBlogs.Models.Domain;
using IBlogs.Models.ViewModels;
using IBlogs.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace IBlogs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogDbContext blogDbContext;
        private readonly ILikesRepository likesRepository;
        private readonly ICommentsRepository commentsRepositor;
        private readonly SignInManager<Profile> signInManager;
        private readonly UserManager<Profile> userManager;

        public HomeController(ILogger<HomeController> logger, IBlogDbContext blogDbContext,
                              ILikesRepository likesRepository,
                              ICommentsRepository commentsRepositor,
                              SignInManager<Profile> signInManager,
                              UserManager<Profile> userManager)
        {
            _logger = logger;
            this.blogDbContext = blogDbContext;
            this.likesRepository = likesRepository;
            this.commentsRepositor = commentsRepositor;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var listPosts = blogDbContext.BlogPosts.ToList();
            List<PostDetailsViewModel> listViewModel = new List<PostDetailsViewModel>();

            if (signInManager.IsSignedIn(User))
            {
                var loggedInUser = signInManager.UserManager.GetUserAsync(User).Result.ProfileId;

                foreach (var post in listPosts)
                {
                    //var comments = await commentsRepositor.GetComments(post.PostId);
                    

                    var postViewModel = new PostDetailsViewModel
                    {
                        Title = post.Title,
                        Header = post.Header,
                        CreatorId = post.CreatorId,
                        About = post.About,
                        Image = post.Image,
                        PostId = post.PostId,
                        PostedDate = post.PostedDate,
                        Name = post.Name,
                        Topics = post.Topics,
                        TotalLikes = await likesRepository.GetTotalLikes(post.PostId),
                        CheckLikeStatus = await likesRepository.GetStatusLike(loggedInUser, post.PostId),
                        AllComments = await commentsRepositor.GetComments(post.PostId)
                };

                    listViewModel.Add(postViewModel);
                }

                return View(listViewModel);
            }
            else
            {

                foreach (var post in listPosts)
                {
                    var postViewModel = new PostDetailsViewModel
                    {
                        Title = post.Title,
                        Header = post.Header,
                        CreatorId = post.CreatorId,
                        About = post.About,
                        Image = post.Image,
                        PostId = post.PostId,
                        PostedDate = post.PostedDate,
                        Name = post.Name,
                        Topics = post.Topics,
                        TotalLikes = await likesRepository.GetTotalLikes(post.PostId),
                        CheckLikeStatus = 0
                    };
                    listViewModel.Add(postViewModel);
                }

                return View(listViewModel);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}