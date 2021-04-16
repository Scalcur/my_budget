using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using my_budget.ViewModels;
using my_budget.Models;
using my_budget.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace my_budget.Controllers
{
    [ApiController]
    [Route("test/[controller]")]
    public class AccountController : Controller
    {
        private readonly IMongoCollection<ClientModel> _users;
        
        public AccountController(IAppOption settings)
        {
            var client = new MongoClient(settings.ClientSettings.ConnectionString);
            
            var database = client.GetDatabase(settings.ClientSettings.DatabaseName);

            _users = database.GetCollection<ClientModel>(settings.ClientSettings.Clients);
        }

        [Authorize]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content("не аутентифицирован");
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
                ClientModel user = _users.Find<ClientModel>(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(model.Email);
 
                    return RedirectToAction("Index", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
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
                ClientModel user = _users.Find<ClientModel>(u => u.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    
                    _users.InsertOne(new ClientModel {ClientName=model.UserName, Email = model.Email, Password = model.Password});
 
                    await Authenticate(model.Email);
 
                    return RedirectToAction("Index", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
 
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}