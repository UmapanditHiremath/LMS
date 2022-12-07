using Leave_Management_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_3.Repository
{
    interface ILeaveApplication
    {
        Task<List<LeaveApplication>> LeaveDet();
        Task<int> AddLeaves(LeaveApplication leaves);
        Task<int> UpdateLeaves(int id, LeaveApplication leaves);
        Task<int> DeleteLeaves(int id);

    }
}
