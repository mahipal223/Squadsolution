using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment2Mvc.Controllers
{
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    public class LocationController : Controller
    {
        string baseurl = "https://localhost:7024";
        public async Task<IActionResult> Index()
        {
            IEnumerable<Location> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/LocationApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Location>>();
                }
            }

            return View(emp);

        }
        public async Task<IActionResult> Create()
        {

            IEnumerable<Employeee> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/EmployeeApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Employeee>>();
                }
            }
            ViewBag.dataListLoactionV = emp;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Location l)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync("/api/LocationApi/", l);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.DeleteAsync("/api/LocationApi/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<Employeee> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/EmployeeApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Employeee>>();
                }
            }
            ViewBag.dataListLoactionV = emp;

            Location loc = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                var result = await client1.GetAsync("/api/LocationApi/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    loc = await result.Content.ReadFromJsonAsync<Location>();
                }
            }

            return View(loc);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Location l)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var r = await client.PutAsJsonAsync<Location>("/api/LocationApi/", l);
                if (r.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}