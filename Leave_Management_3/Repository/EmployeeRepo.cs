using AutoMapper;
using Leave_Management_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_3.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly Umapandit_LeaveManagmentContext umapandit_LeaveManagmentContext;
        private readonly IMapper mapper;

        public EmployeeRepo(Umapandit_LeaveManagmentContext umapandit_LeaveManagmentContext, IMapper mapper)
        {
            this.umapandit_LeaveManagmentContext = umapandit_LeaveManagmentContext;
            this.mapper = mapper;
        }

        public async Task<int> AddEmployees(Employee employees)
        {
            var emp = new Employee()
            {
                EmpId = employees.EmpId,
                EmployeeName = employees.EmployeeName,
                EmployeeEmailId = employees.EmployeeEmailId,
                MobileNo = employees.MobileNo,
                DateJoined = employees.DateJoined,
                Department = employees.Department,
    
            };
            umapandit_LeaveManagmentContext.Employee.Add(emp);
            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return emp.EmpId;

        }

        public async Task<int> DeleteEmployees(int id)
        {
            var ar = umapandit_LeaveManagmentContext.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            if (ar != null)
            {
                umapandit_LeaveManagmentContext.Employee.Remove(ar);
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.EmpId;

        }

        public async Task<List<Employee>> GetEmployee()
        {
            List<Employee> emplst = new List<Employee>();
            var ar = await umapandit_LeaveManagmentContext.Employee.ToListAsync();
            foreach (Employee em in ar)
            {
                emplst.Add(new Employee
                {
                    EmpId = em.EmpId,
                    EmployeeName = em.EmployeeName,
                    EmployeeEmailId = em.EmployeeEmailId,
                    MobileNo = em.MobileNo,
                    DateJoined = em.DateJoined,
                    Department = em.Department,
                    
                });
            }
            return emplst;

        }

        public async Task<int> UpdateEmployees(int id, Employee employees)
        {
            var ar = umapandit_LeaveManagmentContext.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            if (ar != null)
            {
                ar.EmployeeEmailId = employees.EmployeeEmailId;
                ar.MobileNo = employees.MobileNo;
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.EmpId;
        }
    }

}
    

