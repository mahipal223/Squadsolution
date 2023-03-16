using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDemoWeb.Data;

namespace ProjectDemoWeb.Conteact
{
    public interface IRepository
    {
        // List<T> GetAll();
        // void Add(T entity);
        // void Delete(T entity);

        IEnumerable<EmployeeMain> GetAll();
        EmployeeMain GetById(int id);
        void Insert(EmployeeMainFullNameViewModel employee);
        void Update(EmployeeMain employee);
        void Delete(int id);
        
      
    }
}