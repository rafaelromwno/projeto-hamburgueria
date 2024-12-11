using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationHamburgueriaMvc.ViewModels;

namespace WebApplicationHamburgueriaMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Credenciais inválidas.");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (result.Succeeded)
            {
                // Valida o ReturnUrl para evitar open redirects
                if (string.IsNullOrEmpty(loginVM.ReturnUrl) || !Url.IsLocalUrl(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(loginVM.ReturnUrl);
            }

            // Para evitar informações detalhadas sobre o motivo da falha
            ModelState.AddModelError("", "Credenciais inválidas.");
            return View(loginVM);
        }


        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registroVM.UserName
                };

                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Registro", "Falha ao realizar o registro!");
                }
            }

            return View(registroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LoginViewModel registroVM)
        {
            HttpContext.Session.Clear(); // remove todos os valores (conteúdos) dos objetos na Session (A sessão com a mesma chave ainda continua viva)
            HttpContext.User = null;
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
