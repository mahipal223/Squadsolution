using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.model.ViewModel;
using Assignment4.Models;
using Assignment4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly traineedb16Context _db;
        public EmployeeApiController(traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_db.Employee1s.ToList());
            }

            return BadRequest("Your Data in Empty");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var x = _db.Employee1s.Find(id);

            return Ok(x);
        }
        [HttpPut]
        public async Task<IActionResult> update(EmplyeeViewModel obj)
        {

            Employee1 Emp = new Employee1();
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
            Emp.EmpId = obj.EmpId;
            Emp.HaveKnow = havearry;
            _db.Employee1s.Update(Emp);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmplyeeViewModel obj)
        {
            Employee1 Emp = new Employee1();
            Emp.FirstName = obj.FirstName;
            Emp.LastName = obj.LastName;
            Emp.DepartmentId = obj.DepartmentId;
            Emp.DesignationId = obj.DesignationId;
            Emp.JoiningDate = obj.JoiningDate;
            Emp.Salary = obj.Salary;
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
            _db.Employee1s.Add(Emp);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost("search")]
        public async Task<IActionResult> searchdata(SearchViewModel sm)
        {

            if (sm.FirstName != null || sm.LastName != null || sm.DepartmentId != null || sm.HaveKnow != null || sm.JoiningDate != null)
            {
                string gethavavearry = sm.HaveKnow;
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
                    var emp1 = _db.Employee1s.Where(m => m.FirstName == sm.FirstName || m.LastName == sm.LastName || inlist.Contains(m.EmpId) || m.DepartmentId == sm.DepartmentId || m.HaveKnow == sm.HaveKnow || (m.JoiningDate >= sm.JoiningDate && m.JoiningDate <= sm.JoiningDate1) || m.JoiningDate >= sm.JoiningDate).ToList();
                    return Ok(emp1);
                }
                var emp2 = _db.Employee1s.Where(m => m.FirstName == sm.FirstName || m.LastName == sm.LastName || m.DepartmentId == sm.DepartmentId || (m.JoiningDate >= sm.JoiningDate && m.JoiningDate <= sm.JoiningDate1) || m.JoiningDate >= sm.JoiningDate).ToList();
                return Ok(emp2);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = _db.Employee1s.Find(id);
            if (emp != null)
            {
                emp.IsActive = false;
                _db.SaveChanges();
            }
            return Ok();
        }
    }
}