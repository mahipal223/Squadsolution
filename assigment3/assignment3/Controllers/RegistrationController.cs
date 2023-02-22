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
                ViewBag.logindata = (_db.Registrations.Where(m => m.Email == x));

                foreach (var items in ViewBag.logindata)
                {
                    ViewBag.firstName1 = DecryptString(items.FirstName);
                    ViewBag.lastName1 = DecryptString(items.LastName);
                    return View();
                }
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
                obj.Email = EnryptString(obj.Email);
                obj.Password = EnryptString(obj.Password);

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
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loginemail");
            return RedirectToAction("login");
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

                rs.FirstName = EnryptString(obj.FirstName);
                rs.LastName = EnryptString(obj.LastName);
                rs.Email = EnryptString(obj.Email);
                rs.Password = EnryptString(obj.Password);
                rs.DateOfBirth = obj.DateOfBirth;
                rs.ContactNo = EnryptString(obj.ContactNo);
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

        public IActionResult Update(int id)
        {
            var x = _db.Registrations.Find(id);
            Registration rs = new Registration();
            rs.RecId = id;
            rs.FirstName = DecryptString(x.FirstName);
            rs.LastName = DecryptString(x.LastName);
            rs.ContactNo = DecryptString(x.ContactNo);
            rs.Email = DecryptString(x.Email);
            rs.Password = DecryptString(x.Password);
            rs.DateAdded = x.DateAdded;
            rs.LastUpadated = x.LastUpadated;
            return View(rs);
        }
        [HttpPost]
        public IActionResult Update(Registration obj)
        {

            Registration rs = new Registration();
            rs.RecId = obj.RecId;
            rs.FirstName = EnryptString(obj.FirstName);
            rs.LastName = EnryptString(obj.LastName);
            rs.Email = EnryptString(obj.Email);
            rs.Password = EnryptString(obj.Password);
            rs.DateOfBirth = obj.DateOfBirth;
            rs.ContactNo = EnryptString(obj.ContactNo);
            rs.LastUpadated = DateTime.Now;
            rs.DateAdded = obj.DateAdded;
            _db.Registrations.Update(rs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "" + fe;
            }
            return decrypted;
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

    }
}