using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace assignment3.Controllers
{

    public class RegistrationController : Controller
    {
        private readonly traineedb16Context _db;
        public RegistrationController(traineedb16Context db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("loginemail") != null)
            {
                ViewBag.loginSessionEmail = HttpContext.Session.GetString("loginemail");
                string x = HttpContext.Session.GetString("loginemail");
                ViewBag.logindata = _db.Registrations.Where(m => m.Email == x);
                return View();
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("loginemail") != null)
            {
                return View("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Registration obj)
        {
            if (obj.Email != null && obj.Password != null)
            {
                var students = _db.Registrations.Where(m => m.Email == obj.Email && m.Password == obj.Password).FirstOrDefault();
                if (students != null)
                {
                    HttpContext.Session.SetString("loginemail", obj.Email.ToString());
                    HttpContext.Session.SetString("loginid", obj.RecId.ToString());
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Registration obj)
        {
            Registration rs = new Registration();

            if (ModelState.IsValid)
            {
                rs.FirstName = obj.FirstName;
                rs.LastName = obj.LastName;
                rs.Email = obj.Email;
                rs.Password = obj.Password;
                rs.DateOfBirth = obj.DateOfBirth;
                rs.ContactNo = obj.ContactNo;
                rs.DateAdded = DateTime.Now;
                _db.Registrations.Add(rs);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("loginemail") != null)
            {
                var x = _db.Registrations.Find(id);
                return View(x);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            if (HttpContext.Session.GetString("loginemail") != null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}