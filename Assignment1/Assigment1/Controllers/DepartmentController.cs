using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assigment1.Data;
using Assigment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assigment1.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly AppDbContext _db;

        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View(_db.Departments.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var x = _db.Departments.Find(id);
            _db.Departments.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var x = _db.Departments.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(Department od)
        {

            _db.Entry(od).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}