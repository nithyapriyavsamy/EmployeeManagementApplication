using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeService
    {
        public Task<UserDTO?> Register(EmployeeDTO employeeDTO);
        public Task<UserDTO?> Login(UserDTO userDTO);      
        public Task<Employee?> GetEmployee(UserIdDTO item);
        public Task<ICollection<ListEmployeeDTO>> GetEmployees(int id);
        public Task<User?> GetUser(UserIdDTO item);
        public Task<List<ListEmployeeDTO>?> GetAllEmployees();


    }
}
