using Leave_Management_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_3.Repository
{
    public class ManagerRepo : IManager
    {
        private readonly Umapandit_LeaveManagmentContext umapandit_LeaveManagmentContext;

        public ManagerRepo(Umapandit_LeaveManagmentContext umapandit_LeaveManagmentContext)
        {
            this.umapandit_LeaveManagmentContext = umapandit_LeaveManagmentContext;
        }

        public async Task<int> AddManager(Manager managers)
        {
            var man = new Manager()
            {
                EmpId = managers.EmpId,
                ManagerName = managers.ManagerName,
                ManagerEmailId = managers.ManagerEmailId,
                MobileNo = managers.MobileNo,
              
            };
            umapandit_LeaveManagmentContext.Manager.Add(man);
            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return man.EmpId;

        }

        public async Task<int> DeleteManager(int id)
        {
            var ar = umapandit_LeaveManagmentContext.Manager.Where(x => x.EmpId == id).FirstOrDefault();
            if (ar != null)
            {
                umapandit_LeaveManagmentContext.Manager.Remove(ar);
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.EmpId;

        }

        public async Task<List<Manager>> GetManager()
        {
            List<Manager> manlst = new List<Manager>();
            var ar = await umapandit_LeaveManagmentContext.Manager.ToListAsync();
            foreach (Manager m in ar)
            {
                manlst.Add(new Manager
                {
                    EmpId = m.EmpId,
                    ManagerName = m.ManagerName,
                    ManagerEmailId = m.ManagerEmailId,
                    MobileNo = m.MobileNo
                });
            }
            return manlst;

        }

        public async Task<int> UpdateManager(int id, Manager managers)
        {
            var ar = umapandit_LeaveManagmentContext.Manager.Where(x => x.EmpId == id).FirstOrDefault();
            if (ar != null)
            {
                ar.ManagerEmailId = managers.ManagerEmailId;
                ar.MobileNo = managers.MobileNo;
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.EmpId;
        }

    }
}

