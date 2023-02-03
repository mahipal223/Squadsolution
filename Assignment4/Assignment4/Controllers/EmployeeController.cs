using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            string templist = x.HaveKnow;
            char[] spearator = { ',', ' ' };

            // using the method
            String[] strlist = templist.Split(spearator);

            ViewBag.HaveKnowlist = strlist;



            // foreach (var item in strlist)
            // {

            //     if (item != "")
            //     {
            //         for (int i = 0; i < strlist.Length; i++)
            //         {
            //             if (item == vm.HaveKnowleadeof[i].Text)
            //             {
            //                 vm.HaveKnowleadeof[i].Selected = true;
            //             }

            //         }
            //     }
            // }



            return View(vm);
        }

    }
}