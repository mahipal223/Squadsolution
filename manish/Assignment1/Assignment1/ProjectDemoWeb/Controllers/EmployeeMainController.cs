using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDemoWeb.Conteact;
using ProjectDemoWeb.Data;
using ProjectDemoWeb.Services;

namespace ProjectDemoWeb.Controllers
{
    [Route("[controller]/[Action]")]
    public class EmployeeMainController : Controller
    {
    //    private readonly ServiceEmployeeMain _service;
    //    public EmployeeMainController(ServiceEmployeeMain service)
    //    {
    //         _service=service;
    //    }

        private readonly IRepository _repository;
        public EmployeeMainController(IRepository repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create([FromBody] EmployeeMainFullNameViewModel Empobj)
        {
            _repository.Insert(Empobj);
        }
        [HttpGet]
        public IActionResult EmployeeMainAllDisplay()
        {
            var ListAllData= _repository.GetAll();
            
            return View(ListAllData);
            
        }
        public void Delete(int id)
        {
            _repository.Delete(id);   
        }

        
    }
}