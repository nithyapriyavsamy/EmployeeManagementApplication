using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Interfaces
{
    public interface IUpdateService
    {
        public Task<Employee?> Update(UpdateDTO update);
        public Task<User?> UpdateStatus(StatusDTO statusDTO);
    }
}
