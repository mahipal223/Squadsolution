using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment2
{
    public class EmployeeeController : Controller
    {
        private readonly Traineedb16Context _db;
        public EmployeeeController(Traineedb16Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {


            return View(_db.Employeees.ToList());
        }
        public IActionResult Create()
        {

            List<Location> dplist = new List<Location>();
            dplist = _db.Locations.ToList();
            ViewBag.list = dplist;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employeee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employeees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction("create");
        }
        public IActionResult Edit(int id)
        {
            List<Location> dplist = new List<Location>();
            dplist = _db.Locations.ToList();
            ViewBag.list = dplist;
            var x = _db.Employeees.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(Employeee obj)
        {
            _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var x = _db.Employeees.Find(id);
            _db.Employeees.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}