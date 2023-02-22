using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignement3.model;
using assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assignment3Mvc.Controllers
{
    public class RegistrationController : Controller
    {
        string baseurl = "https://localhost:7255";

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginViewModel r1)
        {
            string email = r1.Email;
            string password = r1.Password;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync<loginViewModel>("/api/UserApi/Login", r1);
                if (result.IsSuccessStatusCode)
                {
                    var result2 = result.Content.ReadAsStringAsync().Result;
                    var rs = JsonConvert.DeserializeObject<Registration>(result2);
                    HttpContext.Session.SetString("loginemail", rs.Email);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("loginemail") != null)
            {

                string email = HttpContext.Session.GetString("loginemail");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseurl);
                    var result = await client.GetAsync("/api/UserApi/" + email);
                    if (result.IsSuccessStatusCode)
                    {
                        var r1 = result.Content.ReadAsStringAsync().Result;
                        var rs = JsonConvert.DeserializeObject<Registration>(r1);
                        ViewBag.firstname = rs.FirstName;
                        ViewBag.lastname = rs.LastName;
                        ViewBag.dataadded = rs.DateAdded;
                        ViewBag.lastupadted = rs.LastUpadated;
                        return View();
                    }
                }


            }
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Update()
        {
            if (HttpContext.Session.GetString("loginemail") != null)

            {
                string email = HttpContext.Session.GetString("loginemail");
                Registration rs = null;
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(baseurl);
                    var result = await client.GetAsync("/api/UserApi/" + email);
                    if (result.IsSuccessStatusCode)
                    {
                        rs = await result.Content.ReadFromJsonAsync<Registration>();
                    }

                }
                return View(rs);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(Registration r)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PutAsJsonAsync<Registration>("/api/UserApi", r);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Registration rs)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync<Registration>("/api/UserApi", rs);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}