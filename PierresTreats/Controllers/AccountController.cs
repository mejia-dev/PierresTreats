using PierresTreats.Models;
using PierresTreats.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace PierresTreats.Controllers
{
  public class AccountController : Controller
  {
    private readonly PierresTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresTreatsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Accounts";
      return View();
    }

    public IActionResult Register()
    {
      ViewBag.PageTitle = "Create an Account";
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        @ViewBag.PageTitle = "Create an Account";
        return View(model);
      }
      else
      {
        ApplicationUser newUser = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
    }

    public ActionResult Login(string ReturnUrl)
    {
      if (ReturnUrl != null)
      {
        @ViewBag.ErrorMessage = "You must be logged in to perform this action.";
        @ViewBag.LoginRedirect = ReturnUrl;
      }
      @ViewBag.PageTitle = "Login to Your Account";
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model, string RedirectUrl)
    {
      if (!ModelState.IsValid)
      {
        @ViewBag.PageTitle = "Login to Your Account";
        return View(model);
      }
      else
      {
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          if (RedirectUrl != null)
          {
            return Redirect($"..{RedirectUrl}");
          }
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
          return View(model);
        }
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}