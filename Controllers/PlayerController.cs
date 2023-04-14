using Microsoft.AspNetCore.Mvc;
using VaultedDAL;
using VaultedBLL;

namespace Vaulted_Reborn.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult LoginPage()
        {
            return View("Login");
        }
        public IActionResult RegisterPage()
        {
            return View("Register");
        }


        private readonly PlayerService _playerService;

        public PlayerController()
        {

            _playerService = new PlayerService(new PlayerDAO());
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_playerService.Authenticate(email, password))
            {            
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect email or password";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            if (_playerService.Register(email, password))
            {
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }
    }
}
