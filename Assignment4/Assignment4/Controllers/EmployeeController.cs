using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult Create()
        {

            List<Department1> dp = new List<Department1>();
            dp = _db.Department1s.ToList();
            ViewBag.DeparmentV = dp;

            List<Employee1> ep = new List<Employee1>();
            ep = _db.Employee1s.ToList();
            ViewBag.Empv = ep;

            List<HaveKnowledge1> hk = new List<HaveKnowledge1>();
            hk = _db.HaveKnowledge1s.ToList();
            ViewBag.hkv = hk;

            List<Designation1> dg = new List<Designation1>();
            dg = _db.Designation1s.ToList();
            ViewBag.DesiV = dg;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee1 obj)
        {


            return View();
        }

    }
}