using PierresTreats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public FlavorsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Flavors";
      return View(_db.Flavors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a Flavor";
      return View();
    }
    [HttpPost]
    public ActionResult Create(Flavor flvr)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.PageTitle = "Add a Flavor";
          return View(flvr);
      }
      else
      {
        _db.Flavors.Add(flvr);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = flvr.FlavorId });
      }
    }

    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
          .Include(flvr => flvr.TreatTypes)
          .ThenInclude(join => join.Treat)
          .FirstOrDefault(flvr => flvr.FlavorId == id);
      ViewBag.PageTitle = $"Flavor Details - {thisFlavor.FlavorName} ";
      ViewBag.TreatsCount = _db.Treats.Count();
      return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flvr => flvr.FlavorId == id);
      ViewBag.PageTitle = $"Edit Flavor - {thisFlavor.FlavorName}";
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flvr)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.PageTitle = $"Edit Flavor - {flvr.FlavorName}";
          return View(flvr);
      }
      else
      {
      _db.Flavors.Update(flvr);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flvr => flvr.FlavorId == id);
      ViewBag.PageTitle = $"Delete Flavor - {thisFlavor.FlavorName}";
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flvr => flvr.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors
        .Include(flvr => flvr.TreatTypes)
        .FirstOrDefault(flvr => flvr.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatFullName");
      ViewBag.PageTitle = $"Add a Treat in {thisFlavor.FlavorName} Flavor";
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flvr, int treatId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flvr.FlavorId));
      #nullable disable
      if (treatId != 0 && joinEntity == null)
      {
        TreatFlavor newTreatFlavor = new TreatFlavor() { TreatId = treatId, FlavorId = flvr.FlavorId};
        _db.TreatFlavors.Add(newTreatFlavor);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flvr.FlavorId });
    }

    [HttpPost]
    public ActionResult DeleteTreat(int treatFlavorId)
    {
      TreatFlavor selectedTreatFlavor = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == treatFlavorId);
      _db.TreatFlavors.Remove(selectedTreatFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}