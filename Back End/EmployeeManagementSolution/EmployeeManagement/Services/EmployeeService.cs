using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo<Employee, int> _employeeRepo;
        private readonly IEmployeeRepo<User, int> _userRepo;
        private readonly ITokenGenerate _tokenGenerate;

        public EmployeeService(IEmployeeRepo<Employee, int> employeeRepo,
                                IEmployeeRepo<User, int> userRepo,
                                ITokenGenerate tokenGenerate)
        {
            _employeeRepo = employeeRepo;
            _userRepo = userRepo;
            _tokenGenerate = tokenGenerate;
        }
        public async Task<UserDTO?> Register(EmployeeDTO employeeDTO)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            employeeDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password ?? "1234"));
            employeeDTO.Users.PasswordKey = hmac.Key;
            employeeDTO.Users.Role = "Employee";
            employeeDTO.Users.EmployeeState = "Inactive";
            var userResult = await _userRepo.Add(employeeDTO.Users);
            if (userResult == null) return null;
            employeeDTO.EmployeeId = userResult.UserId;
            var employeeResult = await _employeeRepo.Add(employeeDTO);
            if (userResult != null && employeeResult != null)
            {
                user = new UserDTO();
                user.UserId = employeeResult.EmployeeId;
                user.Role = userResult.Role;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO?> Login(UserDTO userDTO)
        {
            var userData = await _userRepo.Get(userDTO.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                userDTO = new UserDTO();
                userDTO.UserId = userData.UserId;
                userDTO.Role = userData.Role;
                userDTO.Token = _tokenGenerate.GenerateToken(userDTO);
            }
            return userDTO;
        }

        public async Task<Employee?> GetEmployee(UserIdDTO item)
        {
            var employee = await _employeeRepo.Get(item.UserId);
            if (employee != null)
                return employee;
            return null;
        }

        public async Task<User?> GetUser(UserIdDTO item)
        {
            var user = await _userRepo.Get(item.UserId);
            if (user != null)
                return user;
            return null;
        }

        public async Task<ICollection<ListEmployeeDTO>> GetEmployees(int id)
        {
            var users = await _userRepo.GetAll();
            var employees = new List<ListEmployeeDTO>();
            if (users == null)
            {
                return null;
            }
            foreach (var user in users)
            {
                if (user.ManagerId == id)
                {
                    var employee = await _employeeRepo.Get(user.UserId);
                    if (employee != null)
                    {
                        var employeeDTO = ConvertIntoDTO(employee,user);
                        employees.Add(employeeDTO);
                    }
                }
            }
            return employees;
        }

        private ListEmployeeDTO ConvertIntoDTO(Employee employee,User user)
        {
            ListEmployeeDTO employeeDTO = new ListEmployeeDTO();
            employeeDTO.EmployeeId = employee.EmployeeId;
            employeeDTO.Name = employee.Name;
            employeeDTO.Address = employee.Address;
            employeeDTO.Phone = employee.Phone;
            employeeDTO.Status = user.EmployeeState;
            employeeDTO.Age=employee.Age;
            employeeDTO.Gender= employee.Gender;
            return employeeDTO;
        }

        public async Task<List<ListEmployeeDTO>?> GetAllEmployees()
        {
            List<ListEmployeeDTO> listEmployeeDTOs = new List<ListEmployeeDTO>();
            var employees=await _employeeRepo.GetAll();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var user = await _userRepo.Get(employee.EmployeeId);
                    if (user != null)
                    {
                        var employeeDTO = ConvertIntoDTO(employee, user);
                        listEmployeeDTOs.Add(employeeDTO);
                    }
                }
                return listEmployeeDTOs;
            }
            return null;
        }
    }

}

       
   