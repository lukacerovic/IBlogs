using IBlogs.Data;
using IBlogs.Models.Domain;
using IBlogs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBlogs.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IBlogDbContext blogDbContext;

        public ProfileController(IBlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public IActionResult MyProfile(Guid id)
        {
            var categoryFromDb = blogDbContext.Profiles.FirstOrDefault(x => x.ProfileId == id);
            if (categoryFromDb != null)
            {
                var profileRequest = new ProfileRequest
                {
                    ProfileId = categoryFromDb.ProfileId,
                    Name = categoryFromDb.Name,
                    LastName = categoryFromDb.LastName,
                    ProfileImage = categoryFromDb.ProfileImage,
                    About = categoryFromDb.About,
                    Gender = categoryFromDb.Gender
                };
                return View(profileRequest);
            }
            return View();
        }
        public IActionResult List()
        {
            var users = blogDbContext.Profiles.ToList();

            return View(users);
        }

        public IActionResult Edit(Guid id)
        {
            var user = blogDbContext.Profiles.FirstOrDefault(x => x.ProfileId == id);
            if (user != null)
            {
                var edit = new EditRequest
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    About = user.About,
                    Gender = user.Gender
                };
                return View(edit);
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, EditRequest editRequest)
        {

            if (editRequest.Name == editRequest.LastName)
            {
                ModelState.AddModelError("name", "The Name and Last Name cannot be same");
            }

            if (editRequest.Password != editRequest.ConfirmPassword)
            {
                ModelState.AddModelError("", "Password and Confirmed password are not the same");
                return View();
            }


            if (ModelState.IsValid)
            {
                var editSend = new EditRequest
                {
                    ProfileId = id,
                    Name = editRequest.Name,
                    LastName = editRequest.LastName,
                    Email = editRequest.Email,
                    Password = editRequest.Password,
                    ConfirmPassword = editRequest.ConfirmPassword,
                    About = editRequest.About,
                    Gender = editRequest.Gender
                };
                var user = blogDbContext.Profiles.FirstOrDefault(x => x.ProfileId == id);
                
                user.Name = editSend.Name;
                user.LastName = editSend.LastName;
                user.Email = editSend.Email;
                user.Password = editSend.Password;
                user.ConfirmPassword = editSend.ConfirmPassword;
                user.About = editSend.About;
                user.Gender = editSend.Gender;

                blogDbContext.Profiles.Update(user);
                blogDbContext.SaveChanges();

                return RedirectToAction("MyProfile", new { id = user.ProfileId });
            }
            return View(editRequest);
        }
    }
}
