using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
