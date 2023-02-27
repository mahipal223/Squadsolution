using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.Linq;

using System.Threading.Tasks;
using Assignment4.model.ViewModel;
using Assignment4.Models;
using Assignment4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;


namespace Assignment4Mvc.Controllers
{

    public class EmployeeController : Controller
    {
        string baseurl = "https://localhost:7073";

        public async Task<IActionResult> Create()
        {


            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DesignationApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DesiV = JsonConvert.DeserializeObject<List<Designation1>>(result);
                }
            }
            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DepartmentApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DeparmentV = JsonConvert.DeserializeObject<List<Department1>>(result);
                }
            }
            List<Employee1> emp = new List<Employee1>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var result = await client.GetAsync("/api/EmployeeApi");

                if (result.IsSuccessStatusCode)
                {
                    var temp = result.Content.ReadAsStringAsync().Result;

                    emp = JsonConvert.DeserializeObject<List<Employee1>>(temp);
                    ViewBag.Empv = emp;

                }
            }
            EmplyeeViewModel vm = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                HttpResponseMessage Res = await client1.GetAsync("/api/HaveKnowOfApi");
                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    vm = JsonConvert.DeserializeObject<EmplyeeViewModel>(result);
                }
            }



            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmplyeeViewModel emp)
        {
            using (HttpClient client6 = new HttpClient())
            {
                client6.BaseAddress = new Uri(baseurl);
                var r = await client6.PostAsJsonAsync<EmplyeeViewModel>("/api/EmployeeApi", emp);
                if (r.IsSuccessStatusCode)
                {
                    return RedirectToAction("SerachIndex");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SerachIndex()
        {
            List<Employee1> emp = new List<Employee1>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var result = await client.GetAsync("/api/EmployeeApi");

                if (result.IsSuccessStatusCode)
                {
                    var temp = result.Content.ReadAsStringAsync().Result;

                    emp = JsonConvert.DeserializeObject<List<Employee1>>(temp);

                }
            }
            ViewBag.viewdata = emp;

            List<Department1> DeptInfo = new List<Department1>();

            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DepartmentApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DeparmentV = JsonConvert.DeserializeObject<List<Department1>>(result);
                }
            }
            EmplyeeViewModel vm = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                HttpResponseMessage Res = await client1.GetAsync("/api/HaveKnowOfApi");
                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    vm = JsonConvert.DeserializeObject<EmplyeeViewModel>(result);
                }
            }

            var getSessionFirstName = HttpContext.Session.GetString("SessionEmpFirstName");
            var getSessionLastName = HttpContext.Session.GetString("SessionEmpLastName");
            var getSessionDeptId = HttpContext.Session.GetString("SessionEmpDeptId");
            string gethavavearry = HttpContext.Session.GetString("SessionHavearry");

            if (getSessionFirstName != null || getSessionLastName != null || getSessionDeptId != null || gethavavearry != null)
            {
                if (getSessionFirstName != null)
                {
                    vm.FirstName = getSessionFirstName;
                }
                if (getSessionLastName != null)
                {
                    vm.LastName = getSessionLastName;
                }
                if (getSessionDeptId != null)
                {
                    vm.DepartmentId = Int32.Parse(getSessionDeptId);
                }
                List<Employee1> emp2 = new List<Employee1>();
                SearchViewModel sm = new SearchViewModel();
                sm.FirstName = vm.FirstName;
                sm.LastName = vm.LastName;
                sm.DepartmentId = vm.DepartmentId;
                sm.JoiningDate = vm.JoiningDate;
                sm.JoiningDate1 = vm.JoiningDate1;
                sm.HaveKnow = gethavavearry;
                if (gethavavearry != null)
                {


                    char[] spearator = { ',', ' ' };

                    // using the method
                    String[] strlist = gethavavearry.Split(spearator);

                    for (int i = 0; i < strlist.Length; i++)
                    {
                        for (int j = 0; j < vm.HaveKnowleadeof.Count; j++)
                        {
                            if (vm.HaveKnowleadeof[j].Text == strlist[i])
                            {
                                vm.HaveKnowleadeof[j].Selected = true;
                            }
                        }

                    }
                }
                using (HttpClient client4 = new HttpClient())
                {
                    client4.BaseAddress = new Uri(baseurl);
                    var result = await client4.PostAsJsonAsync<SearchViewModel>("/api/EmployeeApi/search", sm);
                    if (result.IsSuccessStatusCode)
                    {
                        var temp = result.Content.ReadAsStringAsync().Result;

                        emp2 = JsonConvert.DeserializeObject<List<Employee1>>(temp);
                        ViewBag.viewdata = emp2;
                    }
                }
            }

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> SerachIndex(EmplyeeViewModel Em)
        {

            string havearry2 = "";
            for (int i = 0; i < Em.HaveKnowleadeof.Count; i++)
            {
                if (Em.HaveKnowleadeof[i].Selected == true)
                {
                    havearry2 += Em.HaveKnowleadeof[i].Text + ",";
                }
            }
            List<Employee1> emp = new List<Employee1>();
            SearchViewModel sm = new SearchViewModel();
            sm.FirstName = Em.FirstName;
            sm.LastName = Em.LastName;
            sm.DepartmentId = Em.DepartmentId;
            sm.JoiningDate = Em.JoiningDate;
            sm.JoiningDate1 = Em.JoiningDate1;
            sm.HaveKnow = havearry2;

            //session all 
            if (sm.FirstName != null)
            {
                HttpContext.Session.SetString("SessionEmpFirstName", sm.FirstName);
            }
            if (sm.LastName != null)
            {
                HttpContext.Session.SetString("SessionEmpLastName", sm.LastName);
            }
            if (sm.DepartmentId != null && sm.DepartmentId != 0)
            {
                HttpContext.Session.SetString("SessionEmpDepid", sm.DepartmentId.ToString());
            }
            if (sm.HaveKnow != null && sm.HaveKnow != "" && sm.HaveKnow != ",")
            {
                HttpContext.Session.SetString("SessionHavearry", sm.HaveKnow);


            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.PostAsJsonAsync<SearchViewModel>("/api/EmployeeApi/search", sm);
                if (result.IsSuccessStatusCode)
                {
                    var temp = result.Content.ReadAsStringAsync().Result;

                    emp = JsonConvert.DeserializeObject<List<Employee1>>(temp);
                    ViewBag.viewdata = emp;
                }

            }
            List<Department1> DeptInfo = new List<Department1>();

            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DepartmentApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DeparmentV = JsonConvert.DeserializeObject<List<Department1>>(result);
                }
            }
            EmplyeeViewModel vm = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                HttpResponseMessage Res = await client1.GetAsync("/api/HaveKnowOfApi");
                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    vm = JsonConvert.DeserializeObject<EmplyeeViewModel>(result);
                }
            }


            return View(vm);

        }
        public async Task<IActionResult> Edit(int id)
        {
            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DesignationApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DesiV = JsonConvert.DeserializeObject<List<Designation1>>(result);
                }
            }
            using (HttpClient client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseurl);

                HttpResponseMessage Res = await client2.GetAsync("/api/DepartmentApi");

                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.DeparmentV = JsonConvert.DeserializeObject<List<Department1>>(result);
                }
            }
            List<Employee1> emp = new List<Employee1>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var result = await client.GetAsync("/api/EmployeeApi");

                if (result.IsSuccessStatusCode)
                {
                    var temp = result.Content.ReadAsStringAsync().Result;

                    emp = JsonConvert.DeserializeObject<List<Employee1>>(temp);
                    ViewBag.Empv = emp;

                }
            }
            EmplyeeViewModel vm = null;
            Employee1 em = null;
            using (HttpClient client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(baseurl);
                HttpResponseMessage Res = await client1.GetAsync("/api/HaveKnowOfApi");
                if (Res.IsSuccessStatusCode)
                {
                    string result = Res.Content.ReadAsStringAsync().Result;
                    vm = JsonConvert.DeserializeObject<EmplyeeViewModel>(result);
                }
            }
            using (HttpClient client7 = new HttpClient())
            {
                client7.BaseAddress = new Uri(baseurl);
                var r = await client7.GetAsync("/api/EmployeeApi/" + id.ToString());
                if (r.IsSuccessStatusCode)
                {
                    em = await r.Content.ReadFromJsonAsync<Employee1>();
                    vm.FirstName = em.FirstName;
                    vm.LastName = em.LastName;
                    vm.JoiningDate = em.JoiningDate;
                    vm.Salary = em.Salary;
                    vm.DepartmentId = em.DepartmentId;
                    vm.DesignationId = em.DesignationId;
                    vm.HaveKnow = em.HaveKnow;
                    vm.ReportingPerson = em.ReportingPerson;
                    vm.EmpId = em.EmpId;
                }
            }

            string templist = vm.HaveKnow;
            char[] spearator = { ',', ' ' };

            // using the method
            String[] strlist = templist.Split(spearator);

            for (int i = 0; i < strlist.Length; i++)
            {
                for (int j = 0; j < vm.HaveKnowleadeof.Count; j++)
                {
                    if (vm.HaveKnowleadeof[j].Text == strlist[i])
                    {
                        vm.HaveKnowleadeof[j].Selected = true;
                    }
                }

            }

            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmplyeeViewModel emp)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var r = await client.PutAsJsonAsync<EmplyeeViewModel>("/api/EmployeeApi", emp);
                if (r.IsSuccessStatusCode)
                {
                    return RedirectToAction("SerachIndex");
                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                var result = await client.DeleteAsync("/api/EmployeeApi/" + id);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("SerachIndex");
                }
            }
            return View();

        }
        public async Task<IActionResult> Reset()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("SerachIndex");
        }
    }
}