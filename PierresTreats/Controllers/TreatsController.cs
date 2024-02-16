using PierresTreats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Treats";
      return View(_db.Treats.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a Treat";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat trt)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.PageTitle = "Add a Treat";
          return View(trt);
      }
      else
      {
        _db.Treats.Add(trt);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = trt.TreatId });
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
          .Include(trt => trt.FlavorTypes)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(trt => trt.TreatId == id);
      ViewBag.PageTitle = $"Treat Details - {thisTreat.TreatName} ";
      ViewBag.FlavorsCount = _db.Flavors.Count();
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      ViewBag.PageTitle = $"Edit Treat - {thisTreat.TreatName}";
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat trt)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.PageTitle = $"Edit Treat - {trt.TreatName}";
          return View(trt);
      }
      else
      {
      _db.Treats.Update(trt);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = trt.TreatId });
      }
    }

    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      ViewBag.PageTitle = $"Delete Treat - {thisTreat.TreatName}";
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(trt => trt.FlavorTypes)
        .FirstOrDefault(trt => trt.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      ViewBag.PageTitle = $"Add a Flavor of {thisTreat.TreatName}";
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat trt, int flavorId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == trt.TreatId));
      #nullable disable
      if (flavorId != 0 && joinEntity == null)
      {
        TreatFlavor newFlavor = new TreatFlavor() { FlavorId = flavorId, TreatId = trt.TreatId};
        _db.TreatFlavors.Add(newFlavor);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = trt.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int treatFlavorId)
    {
      TreatFlavor selectedTreatFlavor = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == treatFlavorId);
      _db.TreatFlavors.Remove(selectedTreatFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}