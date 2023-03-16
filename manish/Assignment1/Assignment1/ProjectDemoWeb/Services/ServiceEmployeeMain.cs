using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDemoWeb.Conteact;
using ProjectDemoWeb.Data;

namespace ProjectDemoWeb.Services
{
    public class ServiceEmployeeMain
    {
        private readonly IRepository _repositry;
        public ServiceEmployeeMain(IRepository repositry)
        {
            _repositry=repositry;
        }
        
        public void EmployeeDataInsert(EmployeeMainFullNameViewModel empobj1)
        {
            _repositry.Insert(empobj1);
            
        }

        public async Task<IEnumerable<EmployeeMain>> EmployeeMainAll()
        {
            return  _repositry.GetAll();
            
        }

        
    }
}