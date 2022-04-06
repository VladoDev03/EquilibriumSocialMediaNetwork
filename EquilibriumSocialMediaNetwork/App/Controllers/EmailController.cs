using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace App.Controllers
{
    public class EmailController : Controller
    {
        private IEmailServices emailServices;
        private IUserServices userServices;

        public EmailController(
            IEmailServices emailServices,
            IUserServices userServices)
        {
            this.emailServices = emailServices;
            this.userServices = userServices;
        }

        [HttpGet("/ConfirmEmail/{id}")]
        public IActionResult Index(string id)
        {
            string email = emailServices.GetEmailById(id).To;
            string userId = userServices.GetUserByEmail(email).Id;

            userServices.ConfirmAccount(userId);

            return RedirectToAction("Profile", "User");
        }
    }
}
