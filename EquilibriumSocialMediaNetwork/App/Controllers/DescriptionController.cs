using System;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
namespace App.Controllers
{
    public class DescriptionController : Controller
    {
            /*private void AddDescription()
            {
                string content = Console.ReadLine();

                Description description = new Description();
                this.userServices.AddDescription(description);
            }

            private void UpdateDescription()
            {
                string idDescription = Console.ReadLine();

                Description description = new Description();
                this.userServices.UpdateDescription(description);
            }
            private void DeleteDescription()
            {
                string idDescription = Console.ReadLine();

                this.userServices.DeleteDescription(idDescription);
            }*/
        private IUserServices userServices;
        private UserManager<User> userManager;

        public DescriptionController(IUserServices userServices, UserManager<User> userManager)
        {
            this.userServices = userServices;
            this.userManager = userManager;
        }

        [HttpGet]
        private IActionResult AddDescription()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("Index");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddDescription(Description description)
        {
            User user = await this.userManager.GetUserAsync(this.User);
            this.userServices.AddDescription(description);
            return RedirectToAction("Add Description");
        }


        [HttpPost]
        public IActionResult UpdateDescription(Description updateDescription)
        {
            this.userServices.UpdateDescription(updateDescription);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete description")]
        public IActionResult DeleteDescription(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            this.userServices.DeleteDescription(id);

            return RedirectToAction("Index");



        }
    }
}
