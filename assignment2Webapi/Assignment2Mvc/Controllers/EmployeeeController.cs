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
    public class EmployeeeController : Controller
    {
        string baseurl = "https://localhost:7024";
        public async Task<IActionResult> Index()
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

            return View(emp);

        }
        public async Task<IActionResult> Create()
        {
            IEnumerable<Location> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/LocationApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Location>>();
                    ViewBag.list = emp;

                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employeee e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync<Employeee>("/api/EmployeeApi", e);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            IEnumerable<Location> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/LocationApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Location>>();
                    ViewBag.list = emp;

                }
            }


            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.DeleteAsync("/api/EmployeeApi/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.DeleteAsync("/api/EmployeeApi/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public async Task<IActionResult> SelectEmp(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.DeleteAsync("/api/EmployeeApi/Isactive/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {

            IEnumerable<Location> emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.GetAsync("/api/LocationApi/");
                if (result.IsSuccessStatusCode)
                {
                    emp = await result.Content.ReadFromJsonAsync<IList<Location>>();
                    ViewBag.list = emp;

                }
            }
            Employeee em = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                var result = await client1.GetAsync("/api/EmployeeApi/" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    em = await result.Content.ReadFromJsonAsync<Employeee>();
                }
            }

            return View(em);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employeee l)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var r = await client.PutAsJsonAsync<Employeee>("/api/EmployeeApi/", l);
                if (r.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


    }
}