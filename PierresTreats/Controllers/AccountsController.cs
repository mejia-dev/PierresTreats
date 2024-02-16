using PierresTreats.Models;
using PierresTreats.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace PierresTreats.Controllers
{
  public class AccountsController : Controller
  {
    private readonly PierresTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountsController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresTreatsContext db)
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
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
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
  }
}