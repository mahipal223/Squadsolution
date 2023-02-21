using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Assigment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assigment1.Controllers
{

    public class EmployeeController : Controller
    {
        string baseurl = "https://localhost:7123";
        public async Task<IActionResult> Index()
        {
            List<Employee> dplist = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getdata = await client.GetAsync("/api/EmployeeAPi/");
                if (getdata.IsSuccessStatusCode)
                {
                    string result = getdata.Content.ReadAsStringAsync().Result;
                    dplist = JsonConvert.DeserializeObject<List<Employee>>(result);
                }
            }
            return View(dplist);
        }
        public async Task<IActionResult> Create()
        {

            List<Department> dplist = new List<Department>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getdata = await client.GetAsync("/api/DepartmentApi/");
                if (getdata.IsSuccessStatusCode)
                {
                    string result = getdata.Content.ReadAsStringAsync().Result;
                    ViewBag.list = JsonConvert.DeserializeObject<List<Department>>(result);
                }
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee ebj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync<Employee>("/api/EmployeeApi", ebj);
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("index");
                }

                List<Department> dplist = new List<Department>();
                using (HttpClient client1 = new HttpClient())
                {
                    client1.BaseAddress = new Uri(baseurl);
                    HttpResponseMessage getdata = await client1.GetAsync("/api/DepartmentApi/");
                    if (getdata.IsSuccessStatusCode)
                    {
                        string result1 = getdata.Content.ReadAsStringAsync().Result;
                        ViewBag.list = JsonConvert.DeserializeObject<List<Department>>(result1);
                    }
                }

                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var deletetask = client.DeleteAsync("/api/EmployeeApi/" + id.ToString());
                deletetask.Wait();
                var result = deletetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
