using Leave_Management_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_3.Repository
{
    public class LeaveApplicationRepo : ILeaveApplication
    {

        private readonly Umapandit_LeaveManagmentContext umapandit_LeaveManagmentContext;

        public LeaveApplicationRepo(Umapandit_LeaveManagmentContext umapandit_LeaveManagment)
        {
            this.umapandit_LeaveManagmentContext = umapandit_LeaveManagment;
        }

        public async Task<int> AddLeaves(LeaveApplication leaves)
        {
            var le = new LeaveApplication()
            {
                LeaveId = leaves.LeaveId,
                NoOfDays = leaves.NoOfDays,
                StartDate = leaves.StartDate,
                EndDate = leaves.EndDate,
                LeaveType = leaves.LeaveType,
                Status = leaves.Status,
                Reason = leaves.Reason,
                ManagerComments = leaves.ManagerComments
            };
            umapandit_LeaveManagmentContext.LeaveApplication.Add(le);
            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return le.LeaveId;

        }

        public async Task<int> DeleteLeaves(int id)
        {
            var ar = umapandit_LeaveManagmentContext.LeaveApplication.Where(x => x.LeaveId == id).FirstOrDefault();
            if (ar != null)
            {
                umapandit_LeaveManagmentContext.LeaveApplication.Remove(ar);
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.LeaveId;

        }

        public async Task<List<LeaveApplication>> LeaveDet()
        {
            List<LeaveApplication> leavelst = new List<LeaveApplication>();
            var ar = await umapandit_LeaveManagmentContext.LeaveApplication.ToListAsync();
            foreach (LeaveApplication le in ar)
            {
                leavelst.Add(new LeaveApplication
                {
                    LeaveId = le.LeaveId,
                    NoOfDays = le.NoOfDays,
                    StartDate = le.StartDate,
                    EndDate = le.EndDate,
                    LeaveType = le.LeaveType,
                    Status = le.Status,
                    Reason = le.Reason,
                    ManagerComments = le.ManagerComments
                });
            }

            return leavelst;

        }

        public async Task<int> UpdateLeaves(int id, LeaveApplication leaves)
        {
            var ar = umapandit_LeaveManagmentContext.LeaveApplication.Where(x => x.LeaveId == id).FirstOrDefault();
            if (ar != null)
            {

                ar.Status = leaves.Status;
                ar.LeaveType = leaves.LeaveType;
                ar.StartDate = ar.StartDate;
                ar.EndDate = ar.EndDate;
                
            }

            await umapandit_LeaveManagmentContext.SaveChangesAsync();
            return ar.LeaveId;
        }

    }
}

