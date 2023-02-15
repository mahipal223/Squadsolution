using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Assigment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assigment1.Controllers
{

    public class DepartmentController : Controller
    {
        string baseurl = "https://localhost:7123";
        public async Task<IActionResult> Index()
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
                    dplist = JsonConvert.DeserializeObject<List<Department>>(result);
                }
            }
            return View(dplist);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department dp)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var PostTTask = client.PostAsJsonAsync<Department>("/api/DepartmentApi/", dp);
                PostTTask.Wait();
                var result = PostTTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("index");
                }

            }
            return View();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var deletetask = client.DeleteAsync("/api/DepartmentApi/" + id.ToString());
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