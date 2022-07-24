using Microsoft.AspNetCore.Mvc;
using SchoolJournal.Data.Repos;
using SchoolJournal.Models;

namespace SchoolJournal.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserByEmail(model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    await _userRepository.AddUser(model.Email, model.Password);                    

                    //await Authenticate(model.Email); // аутентификация, раскомментируем позже

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUser(model.Email, model.Password);
                if (user != null)
                {
                    //await Authenticate(model.Email); // аутентификация, раскомментируем позже

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


    }
}
