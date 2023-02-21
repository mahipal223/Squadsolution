using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignmen1webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace assignmen1webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeApiController : ControllerBase
    {
        private readonly Traineedb16Context _db;

        public EmployeeApiController(Traineedb16Context db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _db.Employees.ToList();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Insertdata([FromBody] Employee e)
        {

            if (e.DepId == 0)
            {

                _db.Departments.Add(e.Dep);
                _db.SaveChanges();
                _db.Employees.Add(e);
                _db.SaveChanges();
                return Ok("Data Inserted");
            }
            else
            {
                Employee emp = new Employee();
                emp.EmpName = e.EmpName;
                emp.DepId = e.DepId;
                emp.Salary = e.Salary;
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return Ok("Data Inserted");
            }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _db.Employees.Find(id);
            _db.Employees.Remove(result);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                if (id != null)
                {
                    var x = _db.Employees.Find(id);
                    return Ok(x);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult update(Employee dp)
        {
            _db.Entry(dp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }
    }
}