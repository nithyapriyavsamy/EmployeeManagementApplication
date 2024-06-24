using LeaveManagementAPI.Interfaces;
using LeaveManagementAPI.Models;
using LeaveManagementAPI.Models.DTO;

namespace LeaveManagementAPI.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepo<Leave, int> _leaveRepo;

        public LeaveService(ILeaveRepo<Leave,int> leaveRepo)
        {
            _leaveRepo = leaveRepo;
        }
        public async Task<Leave> Add(Leave leave)
        {
            leave.LeaveStatus = "Applied";
            return await _leaveRepo.Add(leave);
        }

        public async Task<Leave> Get(int key)
        {
            return await _leaveRepo.Get(key);
        }

        public async Task<List<Leave>> GetAllByEmp(int key)
        {
            return await _leaveRepo.GetAllByEmp(key);
        }

        public async Task<List<Leave>> GetAllByManager(int key)
        {
            return await _leaveRepo.GetAllByManager(key);
        }

        public async Task<Leave> Remove(int key)
        {
            return await _leaveRepo.Remove(key);
        }

        public async Task<Leave> Update(LeaveDTO leaveDTO)
        {
            Leave leave = new Leave();
            leave.Id = leaveDTO.Id;
            leave.LeaveStatus = leaveDTO.LeaveStatus;
            return await _leaveRepo.Update(leave);
        }
    }
}
