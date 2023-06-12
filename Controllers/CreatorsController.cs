using IBlogs.Data;
using IBlogs.Models.ViewModels;
using IBlogs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IBlogs.Controllers
{
    public class CreatorsController : Controller
    {
        private readonly IBlogDbContext blogDbContext;
        private readonly ICreatorsRepository creatorsRepository;

        public CreatorsController(IBlogDbContext blogDbContext, ICreatorsRepository creatorsRepository)
        {
            this.blogDbContext = blogDbContext;
            this.creatorsRepository = creatorsRepository;
        }
        public async Task<IActionResult> List()
        {
            var creators = blogDbContext.Profiles.ToList();
            List<ProfileRequest> listViewModel = new List<ProfileRequest>();

            foreach (var profile in creators)
            {
                var model = new ProfileRequest
                {
                    ProfileId = profile.ProfileId,
                    ProfileImage = profile.ProfileImage,
                    Name = profile.Name,
                    LastName = profile.LastName,
                    Email = profile.Email,
                    Gender = profile.Gender,
                    MyTopics = await creatorsRepository.UserTopics(profile.ProfileId)
                };
                listViewModel.Add(model);
            }

            return View(listViewModel);

            
        }
       
    }
}
