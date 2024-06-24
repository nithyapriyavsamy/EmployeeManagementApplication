using LeaveManagementAPI.Exceptions;
using LeaveManagementAPI.Interfaces;
using LeaveManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Services
{
    public class LeaveRepo : ILeaveRepo<Leave, int>
    {
        private LeaveContext _leaveContext;

        public LeaveRepo(LeaveContext leaveContext)
        {
            _leaveContext = leaveContext;
        }
        public async Task<Leave> Add(Leave item)
        {
            try
            {
                _leaveContext.Leaves.Add(item);
                await _leaveContext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new DatabaseException();
            }
        }

        public async Task<Leave> Get(int key)
        {
            var result = await _leaveContext.Leaves.FirstOrDefaultAsync(l => l.Id == key);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<List<Leave>> GetAllByEmp(int key)
        {
            var result = await _leaveContext.Leaves.Where(l => l.Emp_Id == key).ToListAsync();
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<List<Leave>> GetAllByManager(int key)
        {
            var result = await _leaveContext.Leaves.Where(l=>l.Manager_Id==key).ToListAsync();
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Leave> Remove(int key)
        {
            var leave=await Get(key);
            if (leave != null)
            {
                try
                {
                    _leaveContext.Remove(leave);
                    await _leaveContext.SaveChangesAsync();
                    return leave;
                }
                catch
                {
                    throw new DatabaseException();
                }
            }
            return null;
        }

        public async Task<Leave> Update(Leave item)
        {
            var leave = await Get(item.Id);
            if(leave != null)
            {
                try
                {
                    /*leave.Emp_Id = item.Emp_Id;
                    leave.Manager_Id = item.Manager_Id;
                    leave.Title = item.Title;
                    leave.Duration = item.Duration;
                    leave.FromDate = item.FromDate;*/
                    leave.LeaveStatus = item.LeaveStatus;
                    await _leaveContext.SaveChangesAsync();
                    return leave;
                }
                catch(Exception ex)
                {
                    throw new DatabaseException();
                }
            }
            return null;
        }
    }
}
