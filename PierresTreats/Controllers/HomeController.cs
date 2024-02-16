using PierresTreats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresTreatsContext _db;

    public HomeController(PierresTreatsContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Home";
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("treats", _db.Treats.ToArray());
      model.Add("flavors", _db.Flavors.ToArray());
      return View(model);
    }

  }
}