using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assigment1.Data;
using Assigment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assigment1.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employees.Include(x => x.Departments).ToList());
        }
        public IActionResult Create()
        {

            List<Department> dplist = new List<Department>();
            dplist = _db.Departments.ToList();
            ViewBag.list = dplist;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (e.EmpName != null)
            {
                if (e.DepId == 0)
                {

                    _db.Departments.Add(e.Departments);
                    _db.SaveChanges();

                    _db.Employees.Add(e);
                    _db.SaveChanges();

                }
                else
                {
                    Employee emp = new Employee();
                    emp.EmpName = e.EmpName;
                    emp.DepId = e.DepId;
                    emp.Salary = e.Salary;
                    _db.Employees.Add(emp);
                    _db.SaveChanges();
                }
                TempData["msg"] = "<script>alert('Registration succesfully')</script>";
                return RedirectToAction("index");
            }
            else
            {
                List<Department> dplist = new List<Department>();
                dplist = _db.Departments.ToList();
                ViewBag.list = dplist;
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var x = _db.Employees.Find(id);
            _db.Employees.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            List<Department> dplist = new List<Department>();
            dplist = _db.Departments.ToList();
            ViewBag.list = dplist;
            var x = _db.Employees.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(Employee od)
        {


            if (od.DepId == 0)
            {
                _db.Departments.Add(od.Departments);
                _db.SaveChanges();
                _db.Employees.Update(od);
                _db.SaveChanges();
            }
            else
            {

                Employee emp = new Employee();
                emp.EmpId = od.EmpId;
                emp.EmpName = od.EmpName;
                emp.DepId = od.DepId;
                emp.Salary = od.Salary;
                _db.Employees.Update(emp);
                _db.SaveChanges();
            }
            TempData["msg"] = "<script>alert('update succesfully')</script>";
            return RedirectToAction("index");

        }

    }
}