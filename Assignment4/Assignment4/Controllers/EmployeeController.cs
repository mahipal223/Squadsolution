using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment4.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly traineedb16Context _db;
        public EmployeeController(traineedb16Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employee1s.ToList());
        }
        public IActionResult Create()
        {

            List<Department1> dp = new List<Department1>();
            dp = _db.Department1s.ToList();
            ViewBag.DeparmentV = dp;

            List<Employee1> ep = new List<Employee1>();
            ep = _db.Employee1s.ToList();
            ViewBag.Empv = ep;

            var HaveKnowlist = _db.HaveKnowledge1s.Select(x => new SelectListItem()
            {
                Text = x.HaveKnowName,
                Value = x.HaveKnowId.ToString(),
            }).ToList();
            EmplyeeViewModel vm = new EmplyeeViewModel();
            vm.HaveKnowleadeof = HaveKnowlist;

            List<Designation1> dg = new List<Designation1>();
            dg = _db.Designation1s.ToList();
            ViewBag.DesiV = dg;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(EmplyeeViewModel obj)
        {
            Employee1 Emp = new Employee1();
            Emp.FirstName = obj.FirstName;
            Emp.LastName = obj.LastName;
            Emp.DepartmentId = obj.DepartmentId;
            Emp.DesignationId = obj.DesignationId;
            Emp.JoiningDate = obj.JoiningDate;
            Emp.Salary = obj.Salary;
            Emp.ReportingPerson = obj.ReportingPerson;
            HaveKnowledge1 h1 = new HaveKnowledge1();
            string havearry = "";
            for (int i = 0; i < obj.HaveKnowleadeof.Count; i++)
            {
                if (obj.HaveKnowleadeof[i].Selected == true)
                {
                    havearry += obj.HaveKnowleadeof[i].Text + ",";
                }

            }
            Emp.HaveKnow = havearry;
            _db.Employee1s.Add(Emp);
            _db.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {

            var e = _db.Employee1s.Find(id);
            if (e != null)
            {
                e.IsActive = false;
                _db.SaveChanges();
            }
            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            EmplyeeViewModel vm = new EmplyeeViewModel();
            var HaveKnowlist = _db.HaveKnowledge1s.Select(x => new SelectListItem()
            {
                Text = x.HaveKnowName,
                Value = x.HaveKnowId.ToString(),
            }).ToList();
            vm.HaveKnowleadeof = HaveKnowlist;


            List<Designation1> dg = new List<Designation1>();
            dg = _db.Designation1s.ToList();
            ViewBag.DesiV = dg;

            List<Department1> dp = new List<Department1>();
            dp = _db.Department1s.ToList();
            ViewBag.DeparmentV = dp;

            List<Employee1> ep = new List<Employee1>();
            ep = _db.Employee1s.ToList();
            ViewBag.Empv = ep;

            var x = _db.Employee1s.Find(id);


            vm.FirstName = x.FirstName;
            vm.LastName = x.LastName;
            vm.DepartmentId = x.DepartmentId;
            vm.Salary = x.Salary;
            vm.DesignationId = x.DesignationId;
            vm.JoiningDate = x.JoiningDate;
            vm.ReportingPerson = x.ReportingPerson;
            vm.EmpId = x.EmpId;
            vm.IsActive = x.IsActive;
            string templist = x.HaveKnow;
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
        public IActionResult Edit(EmplyeeViewModel obj)
        {
            Employee1 Emp = new Employee1();
            Emp.EmpId = obj.EmpId;
            Emp.FirstName = obj.FirstName;
            Emp.LastName = obj.LastName;
            Emp.DepartmentId = obj.DepartmentId;
            Emp.DesignationId = obj.DesignationId;
            Emp.JoiningDate = obj.JoiningDate;
            Emp.Salary = obj.Salary;
            Emp.IsActive = obj.IsActive;
            Emp.ReportingPerson = obj.ReportingPerson;
            string havearry = "";
            for (int i = 0; i < obj.HaveKnowleadeof.Count; i++)
            {
                if (obj.HaveKnowleadeof[i].Selected == true)
                {
                    havearry += obj.HaveKnowleadeof[i].Text + ",";
                }

            }
            Emp.HaveKnow = havearry;
            _db.Employee1s.Update(Emp);
            _db.SaveChanges();

            return RedirectToAction("SerachIndex");

        }
        public IActionResult SerachIndex()
        {

            var getSessionFirstName = HttpContext.Session.GetString("SessionEmpFirstName");
            var getSessionLastName = HttpContext.Session.GetString("SessionEmpLastName");
            var getSessionDeptId = HttpContext.Session.GetString("SessionEmpDeptId");
            string gethavavearry = HttpContext.Session.GetString("SessionHavearry");

            List<Department1> dp = new List<Department1>();
            dp = _db.Department1s.ToList();
            ViewBag.DeparmentV = dp;

            List<Employee1> ep = new List<Employee1>();
            ep = _db.Employee1s.ToList();
            ViewBag.Empv = ep;

            var HaveKnowlist = _db.HaveKnowledge1s.Select(x => new SelectListItem()
            {
                Text = x.HaveKnowName,
                Value = x.HaveKnowId.ToString(),
            }).ToList();

            EmplyeeViewModel vm = new EmplyeeViewModel();
            vm.HaveKnowleadeof = HaveKnowlist;

            List<Designation1> dg = new List<Designation1>();
            dg = _db.Designation1s.ToList();
            ViewBag.DesiV = dg;

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
                var emp1 = _db.Employee1s.Where(m => m.FirstName == vm.FirstName && m.LastName == vm.LastName || m.DepartmentId == vm.DepartmentId);
                ViewBag.viewdata = emp1;
                if (gethavavearry != null && gethavavearry != "" && gethavavearry != ",")
                {
                    var x = _db.Employee1s.Where(X => X.IsActive == true).ToList();
                    char[] spearator = { ',', ' ' };
                    String[] arry = gethavavearry.Split(spearator);
                    int[] inlist = new int[x.Count];

                    foreach (var (value, k) in x.Select((v, k) => (v, k)))
                    {
                        if (value.HaveKnow != null && value.HaveKnow != "" && value.HaveKnow != ",")
                        {
                            char[] spearator1 = { ',', ' ' };
                            String[] strlist = value.HaveKnow.Split(spearator1);

                            for (int i = 0; i < arry.Length; i++)
                            {
                                for (int j = 0; j < strlist.Length; j++)
                                {

                                    if (arry[i] != "" && strlist[j] != "")
                                    {
                                        if (arry[i] == strlist[j])
                                        {
                                            inlist[k] = value.EmpId;

                                        }
                                    }
                                }
                            }

                        }
                    }
                    for (int i = 0; i < arry.Length; i++)
                    {
                        for (int j = 0; j < vm.HaveKnowleadeof.Count; j++)
                        {
                            if (vm.HaveKnowleadeof[j].Text == arry[i])
                            {
                                vm.HaveKnowleadeof[j].Selected = true;
                            }
                        }

                    }

                    var finallist = _db.Employee1s.Where(x => inlist.Contains(x.EmpId)).Include(m => m.Department).Include(m => m.Designation).ToList(); ;
                    ViewBag.viewdata = finallist;
                }
            }
            else
            {
                ViewBag.viewdata = _db.Employee1s.Where(X => X.IsActive == true).Include(m => m.Department).Include(m => m.Designation).ToList();
            }

            return View(vm);
        }
        [HttpPost]
        public IActionResult SerachIndex(EmplyeeViewModel Empvm)
        {

            List<Department1> dp = new List<Department1>();
            dp = _db.Department1s.ToList();
            ViewBag.DeparmentV = dp;
            List<Employee1> ep = new List<Employee1>();
            ep = _db.Employee1s.ToList();
            ViewBag.Empv = ep;

            var HaveKnowlist = _db.HaveKnowledge1s.Select(x => new SelectListItem()
            {
                Text = x.HaveKnowName,
                Value = x.HaveKnowId.ToString(),
            }).ToList();
            EmplyeeViewModel vm = new EmplyeeViewModel();
            vm.HaveKnowleadeof = HaveKnowlist;

            List<Designation1> dg = new List<Designation1>();
            dg = _db.Designation1s.ToList();
            ViewBag.DesiV = dg;

            if (Empvm.FirstName != null)
            {
                var x2 = _db.Employee1s.Where(x => x.FirstName == Empvm.FirstName && x.IsActive == true);
                ViewBag.viewdata = x2;
                HttpContext.Session.SetString("SessionEmpFirstName", Empvm.FirstName);
                if (Empvm.LastName != null)
                {
                    x2 = _db.Employee1s.Where(x => x.FirstName == Empvm.FirstName && x.LastName == Empvm.LastName && x.IsActive == true);
                    ViewBag.viewdata = x2;
                    HttpContext.Session.SetString("SessionEmpLastName", Empvm.LastName);
                    if (Empvm.DepartmentId != 0)
                    {
                        x2 = _db.Employee1s.Where(x => x.FirstName == Empvm.FirstName && x.LastName == Empvm.LastName && x.DepartmentId == Empvm.DepartmentId && x.IsActive == true);
                        ViewBag.viewdata = x2;
                    }
                }
            }
            else if (Empvm.DepartmentId != 0)
            {
                var x1 = _db.Employee1s.Where(x => x.DepartmentId == Empvm.DepartmentId || x.FirstName == Empvm.FirstName || x.LastName == Empvm.LastName && x.IsActive == true);
                ViewBag.viewdata = x1;
                HttpContext.Session.SetString("SessionEmpDeptId", Empvm.DepartmentId.ToString());

            }
            var arry = new string[7];
            string havearry2 = "";
            for (int i = 0; i < Empvm.HaveKnowleadeof.Count; i++)
            {
                if (Empvm.HaveKnowleadeof[i].Selected == true)
                {
                    arry[i] = Empvm.HaveKnowleadeof[i].Text;
                    havearry2 += Empvm.HaveKnowleadeof[i].Text + ",";
                }

            }
            if (havearry2 != null && havearry2 != "," && havearry2 != "")
            {
                HttpContext.Session.SetString("SessionHavearry", havearry2);

                var x = _db.Employee1s.Where(X => X.IsActive == true).ToList();

                int[] inlist = new int[x.Count];

                foreach (var (value, k) in x.Select((v, k) => (v, k)))
                {
                    if (value.HaveKnow != null && value.HaveKnow != "" && value.HaveKnow != ",")
                    {
                        char[] spearator = { ',', ' ' };
                        String[] strlist = value.HaveKnow.Split(spearator);

                        for (int i = 0; i < strlist.Length; i++)
                        {
                            for (int j = 0; j < arry.Length; j++)
                            {

                                if (strlist[i] == arry[j])
                                {

                                    inlist[k] = value.EmpId;

                                }
                            }
                        }

                    }
                }

                var finallist = _db.Employee1s.Where(x => inlist.Contains(x.EmpId)).Include(m => m.Department).Include(m => m.Designation).ToList();
                ViewBag.viewdata = finallist;
            }
            return View(vm);
        }
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SerachIndex");
        }
    }
}