using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDemoWeb.Conteact;
using ProjectDemoWeb.Data;

namespace ProjectDemoWeb.Models
{

    public class EmployeeMain : IRepository
    {
       private readonly Traineedb6Context _db;
       public EmployeeMain(Traineedb6Context db)
       {
            _db=db;
       }

        public void Delete(int id)
        {
           var empId=_db.EmployeeMains.Find(id);
           _db.Remove(empId);
           _db.SaveChanges();

        }

        public IEnumerable<Data.EmployeeMain> GetAll()
        {
           //return _db.EmployeeMains.ToList();
           return _db.EmployeeMains.Include(M=>M.EmployeeFullNames).ToList();
        }

        public Data.EmployeeMain GetById(int id)
        {
            var empId=_db.EmployeeMains.Find(id);
            return empId;
        }

        public void Insert(Data.EmployeeMainFullNameViewModel employee)
        {

            Data.EmployeeMain objM=new Data.EmployeeMain();
            objM.Address=employee.Address;
            objM.CompanyLocation=employee.CompanyLocation;
            objM.ContectNo=employee.ContectNo;
            _db.EmployeeMains.Add(objM);
            _db.SaveChanges();

            // _db.EmployeeMains.Add(employee);
            // _db.SaveChanges(); 
            List<EmployeeMain> MaxEmpMain=new List<EmployeeMain>();

           
          //var result=MaxEmpMain.Max(a=>a.empId);

            Data.EmployeeFullName EmpFull=new Data.EmployeeFullName();
            EmpFull.FirstName=employee.FirstName;
            EmpFull.LastName=employee.LastName;
            EmpFull.EmpId=objM.EmpId;
            _db.EmployeeFullNames.Add(EmpFull);
            _db.SaveChanges();


            // _db.EmployeeFullNames.Add(employee.);
            // _db.SaveChanges();
        }

       

        public void Update(Data.EmployeeMain employee)
        {
            _db.Entry(employee).State=EntityState.Modified;
            _db.SaveChanges();
        }
    }


}