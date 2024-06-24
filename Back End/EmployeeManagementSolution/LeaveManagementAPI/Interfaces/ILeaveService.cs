using LeaveManagementAPI.Models;
using LeaveManagementAPI.Models.DTO;

namespace LeaveManagementAPI.Interfaces
{
    public interface ILeaveService
    {
        Task<Leave> Add(Leave leave);
        Task<Leave> Remove(int key);
        Task<Leave> Update(LeaveDTO leave);
        Task<Leave> Get(int key);
        Task<List<Leave>> GetAllByManager(int key);
        Task<List<Leave>> GetAllByEmp(int key);
    }
}
